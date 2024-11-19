using ASM.Core.Entities;
using ASM.Database.Data;
using ASM.Services.Interfaces;
using ASM.Core.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ASM.Application.Helper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace ASM.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AssetManagementDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;

        public AccountController
            (AssetManagementDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IAuthService authService,
            IEmailService emailService)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
            _emailService = emailService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto request)
        {
            var user = new ApplicationUser()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Email,
                Email = request.Email
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                var defaultRole = _context.Roles.FirstOrDefault(x => x.Name.ToLower() == "requester");
                var lastUser = _context.Users.OrderBy(x => x.Id).LastOrDefault();

                if (defaultRole is null || lastUser is null)
                {
                    return BadRequest(new { succeeded = false, error = result.Errors });
                }

                IdentityUserRole<int> userRole = new()
                {
                    RoleId = defaultRole.Id,
                    UserId = lastUser.Id
                };

                await _context.UserRoles.AddAsync(userRole);
                await _context.SaveChangesAsync();

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                if (string.IsNullOrEmpty(lastUser.UserName) || string.IsNullOrEmpty(lastUser.Email))
                {
                    return BadRequest(new { succeeded = false, error = result.Errors });
                }

                if (_emailService.ConfirmEmail(lastUser, token))
                {
                    return Ok(result);
                }

                return BadRequest(new { succeeded = false, error = result.Errors });
            }

            return BadRequest(result);
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmationEmail(int userId, string token)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            if (user is null)
            {
                return BadRequest("User Not Found");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                user.EmailConfirmed = true;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                return Ok("Email confirmed.");
            }

            return BadRequest(result);
        }

        [HttpPost("resend-confirm-email")]
        public async Task<IActionResult> ResendConfirmationEmail(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user is null)
            {
                return Unauthorized("Invalid email.");
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            if (_emailService.ConfirmEmail(user, token))
            {
                return Ok("Send confirmation email succeed.");
            }

            return BadRequest("Send confirmation email failed.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto request)
        {
            var user = await _userManager.FindByNameAsync(request.Email);
            if (user is null)
            {
                return Unauthorized("Invalid username or password.");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                return Unauthorized("Invalid username or password.");
            }

            if (_emailService.TwoFactorAuth(request.Email, _authService.GenerateVerifyCode(user.Id.ToString())))
            {
                return Ok(new { UserId = user.Id, IsVerifyCode = false });
            }

            return BadRequest("Send verify code failed.");
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user is null)
            {
                return Unauthorized("User not found.");
            }

            var token = _authService.GenerateJwtToken(user);
            var roleId = _context.UserRoles.FirstOrDefault(x => x.UserId == user.Id)?.RoleId;

            return Ok(new { AccessToken = token, RoleId = roleId });
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto request)
        {
            // Get the user ID from the claims
            var userId = _userManager.GetUserId(HttpContext.User);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID not found in token.");
            }

            // Get the currently authenticated user
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
            {
                return Unauthorized("User not found.");
            }

            // Attempt to change the password
            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if (!result.Succeeded)
            {
                // Return errors if password change failed
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return BadRequest(new { Error = $"Password change failed: {errors}" });
            }

            return Ok("Password changed successfully.");
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user is null)
            {
                return BadRequest("User Not Found");
            }

            var newPassword = CommonHelper.GenerateRandomPassword(12);

            if (!_emailService.ResetPassword(email, newPassword))
            {
                return BadRequest("Send mail reset password failed.");
            }

            // Generate a password reset token
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            if (!result.Succeeded)
            {
                return BadRequest("Reset password failed.");
            }

            return Ok("Reset password succeed.");
        }

        [HttpGet("signin-google-url")]
        public IActionResult GetGoogleSignInUrl()
        {
            // Creating the URL for Google Login using the properties generated
            var googleSignInUrl = Url.Action("LoginWithGoogle", "Account", null, Request.Scheme);

            return Ok(new { SignInUrl = googleSignInUrl });
        }

        [HttpGet("login-by-google")]
        public IActionResult LoginWithGoogle(string returnUrl = "/")
        {
            var redirectUrl = Url.Action("GoogleCallback", "Account", new { ReturnUrl = returnUrl }, Request.Scheme);
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(GoogleDefaults.AuthenticationScheme, redirectUrl);
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet("google-callback")]
        public async Task<IActionResult> GoogleCallback()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (!result.Succeeded)
            {
                return Unauthorized("Google authentication failed.");
            }

            // Get user information from Google
            var email = result.Principal.FindFirstValue(ClaimTypes.Email);

            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email is null.");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
            {
                user ??= new ApplicationUser()
                {
                    UserName = result.Principal.FindFirstValue(ClaimTypes.Email),
                    Email = result.Principal.FindFirstValue(ClaimTypes.Email),
                    EmailConfirmed = true
                };

                var createResult = await _userManager.CreateAsync(user);
                if (!createResult.Succeeded)
                {
                    return BadRequest("Could not create user account.");
                }

                var defaultRole = _context.Roles.FirstOrDefault(x => x.Name == "Client");

                if (defaultRole is null)
                {
                    return BadRequest(result);
                }

                IdentityUserRole<int> userRole = new()
                {
                    RoleId = defaultRole.Id,
                    UserId = user.Id
                };

                await _context.UserRoles.AddAsync(userRole);

                // Create the user login information for Google
                var info = new UserLoginInfo(
                    loginProvider: GoogleDefaults.AuthenticationScheme, // The external provider (Google)
                    providerKey: result.Principal.FindFirstValue(ClaimTypes.NameIdentifier), // The unique identifier from Google
                    displayName: "Google" // Display name for the provider
                );

                // Add the external login to the user account
                var addLoginResult = await _userManager.AddLoginAsync(user, info);
                if (!addLoginResult.Succeeded)
                {
                    return BadRequest("Failed to link Google login to user account.");
                }
            }

            await _signInManager.SignInAsync(user, isPersistent: false);

            var token = _authService.GenerateJwtToken(user);
            var roleId = _context.UserRoles.FirstOrDefault(x => x.UserId == user.Id)?.RoleId;

            return Ok(new
            {
                AccessToken = token,
                RoleId = roleId
            });
        }

        [HttpGet("send-verification-code")]
        public IActionResult SendVerifyCode(int userId, string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email is empty.");
            }

            if (_emailService.TwoFactorAuth(email, _authService.GenerateVerifyCode(userId.ToString())))
            {
                return Ok(new { UserId = userId, IsSendMail = true });
            }

            return BadRequest("Send verify code failed.");

        }

        [HttpGet("verify-code")]
        public async Task<IActionResult> VerifyCode(int userId, string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return BadRequest("Verification code is empty.");
            }

            if (_authService.CheckVerifyCode(userId.ToString(), code))
            {
                VerificationCodeStoreHelper.RemoveVerificationCode(userId.ToString());

                // Get the currently authenticated user
                var user = await _userManager.FindByIdAsync(userId.ToString());
                if (user is null)
                {
                    return Unauthorized("User not found.");
                }

                var token = _authService.GenerateJwtToken(user);
                var roleId = _context.UserRoles.FirstOrDefault(x => x.UserId == user.Id)?.RoleId;

                return Ok(new { AccessToken = token, UserId = userId, RoleId = roleId });
            }

            return BadRequest("Code is incorrect.");
        }
    }
}

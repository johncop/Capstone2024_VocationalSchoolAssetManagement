using System.Security.Claims;
using ASM.Core.DTOs.User;
using ASM.Core.Entities;
using ASM.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ASM.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager, IMapper mapper, IHttpContextAccessor httpContextAccessor, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _roleManager = roleManager;
        }

        public async Task<UserResponseDTO> GetCurrentUserAsync()
        {
            var user = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
            return _mapper.Map<UserResponseDTO>(user);
        }

        public async Task<UserResponseDTO> GetByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return _mapper.Map<UserResponseDTO>(user);
        }

        public async Task<UserResponseDTO> GetByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return _mapper.Map<UserResponseDTO>(user);
        }

        public async Task<UserResponseDTO> GetByUsernameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return _mapper.Map<UserResponseDTO>(user);
        }

        public async Task<ApplicationUser> GetByRole(string role)
        {
            var isRoleExists = await _roleManager.RoleExistsAsync("Manager");
            if (!isRoleExists)
            {
                _roleManager.CreateAsync(new IdentityRole<int> { Name = "Manager" });
                return null;
            }

            var userInRole = await _userManager.GetUsersInRoleAsync(role);
            return userInRole.Count == 0 ? null : userInRole.FirstOrDefault();
        }
    }
}

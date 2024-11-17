using ASM.Application.Shared;
using ASM.Core.DTOs;
using ASM.Core.Entities;
using ASM.Database.Data;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASM.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseApi
    {
        private readonly AssetManagementDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UserController(AssetManagementDbContext context,
               UserManager<ApplicationUser> userManager,
               SignInManager<ApplicationUser> signInManager,
               IMapper mapper) : base(mapper)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        [Authorize]
        public IActionResult GetAll()
        {
            var users = _context.Users.ToList();
            return Ok(new { data = users });
        }

        [HttpGet("{userId:int}")]
        //[Authorize(Roles = "Admin")]
        [Authorize]
        public IActionResult Get(int userId)
        {
            var user = _context.Users.Where(x => x.Id == userId).FirstOrDefault();
            return Ok(new { data = user });
        }

        [HttpPut("{userId:int}")]
        [Authorize]
        public async Task<IActionResult> Update(int userId, UserUpdateDto userUpdateDto)
        {
            var user = _context.Users.Where(x => x.Id == userId).FirstOrDefault();
            if(user is null)
            {
                return BadRequest("User not found.");
            }

            user.FirstName = userUpdateDto.FirstName;
            user.LastName = userUpdateDto.LastName;
            user.PhoneNumber = userUpdateDto.PhoneNumber;
            user.Address = userUpdateDto.Address;

            _context.Users.Update(user);
            if (await _context.SaveChangesAsync() > 0)
            {
                return Ok("Update user succeed.");
            }

            return BadRequest("Update user failed.");
        }
    }
}

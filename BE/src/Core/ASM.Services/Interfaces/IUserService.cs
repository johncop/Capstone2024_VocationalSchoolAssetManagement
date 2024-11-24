using ASM.Core.DTOs.User;
using ASM.Core.Entities;

namespace ASM.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDTO> GetCurrentUserAsync();
        Task<UserResponseDTO> GetByIdAsync(string userId);
        Task<UserResponseDTO> GetByEmailAsync(string email);
        Task<UserResponseDTO> GetByUsernameAsync(string username);
        Task<ApplicationUser> GetByRole(string role);
    }
}

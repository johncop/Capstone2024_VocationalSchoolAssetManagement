using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ASM.Core.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        public string Address { get; set; }
    }
}

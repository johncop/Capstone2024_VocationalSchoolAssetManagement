using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace ASM.Domain.Entities
{
    public class Category : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }
}

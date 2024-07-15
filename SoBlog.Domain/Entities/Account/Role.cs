using SoBlog.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace SoBlog.Domain.Entities.Account
{
    public class Role : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string DisplayTitle { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string SystemTitle { get; set; }

        public ICollection<User>? Users { get; set; }
        public ICollection<RolePermission>? RolePermissions { get; set; }
    }
}

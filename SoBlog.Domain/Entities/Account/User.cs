using SoBlog.Domain.Entities.Blog;
using SoBlog.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoBlog.Domain.Entities.Account
{
    public class User : BaseEntity
    {
        [MaxLength(250)]
        public string? FirstName { get; set; }

        [MaxLength(250)]
        public string? LastName { get; set; }

        [MaxLength(500)]
        public string? FullName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string EmailActiveCode {  get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [MaxLength(250)]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string AvatarName { get; set; }

        public long RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public Role? Role { get; set; }

        public ICollection<Comment>? Comments { get; set; }
    }
}

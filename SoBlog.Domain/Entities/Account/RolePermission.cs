using SoBlog.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoBlog.Domain.Entities.Account
{
    public class RolePermission : BaseEntity
    {
        public long RoleId {  get; set; }
        [ForeignKey(nameof(RoleId))]
        public Role? Role { get; set; } 

        public long PermissionId { get; set; }
        [ForeignKey(nameof(PermissionId))]
        public Permission? Permission { get; set; }
    }
}

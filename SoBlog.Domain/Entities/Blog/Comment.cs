using SoBlog.Domain.Entities.Account;
using SoBlog.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBlog.Domain.Entities.Blog
{
    public class Comment : BaseEntity
    {
        [Required]
        public string Text {  get; set; }

        public long PostId {  get; set; }
        [ForeignKey(nameof(PostId))]
        public Post? Post { get; set; }

        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

        public bool IsAccepted {  get; set; }

    }
}

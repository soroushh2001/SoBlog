using SoBlog.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBlog.Domain.Entities.Blog
{
    public class Tag: BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string DisplayTitle { get; set; }

        public ICollection<PostTag>? PostTags { get; set; }

    }
}

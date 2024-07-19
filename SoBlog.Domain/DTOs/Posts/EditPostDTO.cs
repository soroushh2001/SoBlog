using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBlog.Domain.DTOs.Posts
{
    public class EditPostDTO
    {
        public long Id { get; set; }

        public long AuthorId {  get; set; }

        [Display(Name = "اسلاگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کیند")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Slug { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کیند")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "زمان برای مطالعه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کیند")]
        public int TimeToRead { get; set; }

        [Display(Name = "متن خبر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کیند")]
        public string Text { get; set; }

        public string ImageName {  get; set; }

        [Display(Name = "پین")]
        public bool IsPinned { get; set; }

        [Display(Name = "پیشنهادی")]

        public bool IsProposed { get; set; }

        [Display(Name = "انتشار")]
        public bool IsPublished { get; set; }

        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کیند")]
        public long CategoryId { get; set; }

        [Display(Name = "تگ ها")]
        [Required(ErrorMessage = "لطفا {0} را وارد کیند")]
        public List<string>? Tags { get; set; }
    }
}

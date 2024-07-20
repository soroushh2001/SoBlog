using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBlog.Domain.DTOs.Categories
{
	public class EditCategoryDTO 
	{
		public long Id { get; set; }

		[Display(Name = "عنوان نمایشی")]
		[Required(ErrorMessage = "لطفا {0} را وارد کیند")]
		[MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		public string DisplayTitle { get; set; }

		[Display(Name = "عنوان سیستمی")]
		[Required(ErrorMessage = "لطفا {0} را وارد کیند")]
		[MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		public string SystemTitle { get; set; }

		[Display(Name = "رنگ")]
		[Required(ErrorMessage = "لطفا {0} را وارد کیند")]
		[MaxLength(50)]
		public string Color { get; set; }

		public string ImageName{  get; set; }

	}
}

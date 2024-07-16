using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBlog.Domain.DTOs.Account
{
	public class RegisterUserDTO
	{
		[Display(Name = "ایمیل")]
		[Required(ErrorMessage = "لطفا {0} را وارد کیند")]
		[MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		[EmailAddress(ErrorMessage = "ساختار ایمیل وارد شده صحیح نمی باشد!")]
		public string Email { get; set; }

		[Display(Name = "کلمه عبور")]
		[Required(ErrorMessage = "لطفا {0} را وارد کیند")]
		[MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		public string Password { get; set; }

		[Display(Name = "تکرار کلمه عبور")]
		[Required(ErrorMessage = "لطفا {0} را وارد کیند")]
		[MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		[Compare(nameof(Password),ErrorMessage ="تکرار کلمه عبور با کلمه عبور وارد شده مغایرت دارد!")]
		public string ConfirmPassword {  get; set; }
	}

	public enum RegisterUserResult 
	{
		UserExisted,
		Success
	}

}

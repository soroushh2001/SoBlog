using System.ComponentModel.DataAnnotations;

namespace SoBlog.Domain.DTOs.Account
{
	public class LoginUserDTO
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

		public bool RememberMe {  get; set; }
	}

	public enum LoginUserResult
	{
		UserNotExisted,
		EmailNotActivated,
		Success
	}

}

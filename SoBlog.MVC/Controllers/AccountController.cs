using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SoBlog.Application.Convertors;
using SoBlog.Application.Interfaces;
using SoBlog.Application.Senders;
using SoBlog.Domain.DTOs.Account;
using System.Security.Claims;

namespace SoBlog.MVC.Controllers
{
    public class AccountController : BaseController
	{
		private readonly IAccountService _accountService;
		private readonly IEmailSender _emailSender;
		private readonly IViewRenderService _viewRenderService;

        public AccountController(IAccountService accountService, IEmailSender emailSender, IViewRenderService viewRenderService)
        {
            _accountService = accountService;
            _emailSender = emailSender;
            _viewRenderService = viewRenderService;
        }

        #region Register

        [HttpGet("register")]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(RegisterUserDTO register)
		{
			if (ModelState.IsValid) 
			{
				var result = await _accountService.RegisterUser(register);
				switch (result)
				{
					case RegisterUserResult.UserExisted:
						ModelState.AddModelError("Email", "کاربری با این مشخصات قبلاً ثبت نام کرده است!");
						return View(register);
					case RegisterUserResult.Success:
						var user = await _accountService.GetUserByEmail(register.Email);
						TempData[SuccessMessage] = "ثبت نام با موفقیت انجام شد";
						TempData[InfoMessage] = "ایمیلی حاوی لینک فعالسازی برای شما ارسال شد";
						var body = await _viewRenderService.RenderToStringAsync("_EmailActiveCode", user);
					   _emailSender.Send(register.Email, "فعالسازی حساب کاربری", body);
						return RedirectToAction("Login");
				}
			}

			return View(register);
		}

		#endregion

		#region Activate Account

		[HttpGet("activate-account/{emailActiveCode}")]
		public async Task<IActionResult> ActivateAccount(string emailActiveCode) 
		{
			var result = await _accountService.ActivateUser(emailActiveCode);

			if (result)
			{
				TempData[SuccessMessage] = "حساب کاربری شما با موفقیت فعال شد";
			}
			else
			{
				return NotFound();
			}

			return Redirect("/login");
		}

        #endregion

        #region Login

        [HttpGet("login")]
		public IActionResult Login(string returnUrl = "")
		{
            var result = new LoginUserDTO();

            if (!string.IsNullOrEmpty(returnUrl))
            {
                result.ReturnUrl = returnUrl;
            }

            return View(result);
        }

		[HttpPost("login")]
		public async Task<IActionResult> Login(LoginUserDTO login)
		{
			if (ModelState.IsValid) 
			{
				var result = await _accountService.CheckUserForLogin(login);
				switch (result)
				{
					case LoginUserResult.UserNotExisted:
						ModelState.AddModelError("Email", "کاربری با این مشخصات یافت نشد");
						return View(login);
					case LoginUserResult.EmailNotActivated:
						ModelState.AddModelError("Email", "لطفا حساب کاربری خود را فعال کنید");
						return View(login);
					case LoginUserResult.Success:
						var user = await _accountService.GetUserByEmail(login.Email);

						var claims = new List<Claim>
						{
							new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
							new Claim(ClaimTypes.Name, user.Email),
							new Claim(ClaimTypes.Email, user.Email)
						};

						var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
						var principal = new ClaimsPrincipal(identity);
						var properties = new AuthenticationProperties
						{
							IsPersistent = login.RememberMe
						};

						await HttpContext.SignInAsync(principal, properties);
						TempData[SuccessMessage] = "خوش آمدید";
                        if (!string.IsNullOrEmpty(login.ReturnUrl))
                        {
                            return Redirect(login.ReturnUrl);
                        }
                        return Redirect("/");
				}
			}
			return View(login);
		}

		#endregion
	}
}

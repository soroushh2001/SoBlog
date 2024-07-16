using Microsoft.AspNetCore.Mvc;
using SoBlog.Application.Interfaces;
using SoBlog.MVC.SiteExtensions;

namespace SoBlog.MVC.ViewComponents
{
	public class SiteHeaderViewComponent : ViewComponent
	{
		private readonly IAccountService _accountService;
		public SiteHeaderViewComponent(IAccountService accountService)
		{
			_accountService	= accountService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var user = await _accountService.GetUserById(HttpContext.User.GetUserId());
            return View("SiteHeader",user);
		}
	}
}

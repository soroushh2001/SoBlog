using Microsoft.AspNetCore.Mvc;
using SoBlog.Application.Interfaces;
using SoBlog.MVC.SiteExtensions;

namespace SoBlog.MVC.Areas.Admin.ViewComponents
{
    public class AdminHeaderViewComponent : ViewComponent
    {
        private readonly IAccountService _accountService;

        public AdminHeaderViewComponent(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _accountService.GetUserById(HttpContext.User.GetUserId());
            return View("AdminHeader", user);
        }
    }
}

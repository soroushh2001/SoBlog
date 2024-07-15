using Microsoft.AspNetCore.Mvc;

namespace SoBlog.MVC.Areas.Admin.ViewComponents
{
    public class AdminHeaderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("AdminHeader");
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace SoBlog.MVC.ViewComponents
{
    public class SiteFooterViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("SiteFooter");
        }
    }
}

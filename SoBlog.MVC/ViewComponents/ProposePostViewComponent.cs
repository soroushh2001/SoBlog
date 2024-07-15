using Microsoft.AspNetCore.Mvc;

namespace SoBlog.MVC.ViewComponents
{
    public class ProposePostViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("ProposePost");
        }
    }
}

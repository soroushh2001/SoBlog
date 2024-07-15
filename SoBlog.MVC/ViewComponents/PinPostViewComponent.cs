using Microsoft.AspNetCore.Mvc;

namespace SoBlog.MVC.ViewComponents
{
    public class PinPostViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("PinPost");                                                                              
        }
    }
}

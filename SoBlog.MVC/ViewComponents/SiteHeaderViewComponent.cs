using Microsoft.AspNetCore.Mvc;

namespace SoBlog.MVC.ViewComponents
{
	public class SiteHeaderViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("SiteHeader");
		}
	}
}

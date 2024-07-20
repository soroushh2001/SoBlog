using Microsoft.AspNetCore.Mvc;
using SoBlog.Application.Interfaces;

namespace SoBlog.MVC.ViewComponents
{
	public class SidebarViewComponent : ViewComponent
	{
		private readonly ICategoryService _categoryService;
		public SidebarViewComponent(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var cat = await _categoryService.ShowCategoryInIndex();
			return View("Sidebar", cat);
		}
	}
}

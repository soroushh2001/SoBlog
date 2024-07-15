﻿using Microsoft.AspNetCore.Mvc;

namespace SoBlog.MVC.ViewComponents
{
    public class TrendingViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Trending");
        }
    }
}

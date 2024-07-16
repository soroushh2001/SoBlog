using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SoBlog.Application.Interfaces;
using SoBlog.Domain.DTOs.Categories;

namespace SoBlog.MVC.Areas.Admin.Controllers
{
	public class CategoryController : AdminBaseController
	{
		private readonly ICategoryService _categoryService;
		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet("categories")]
		public async Task<IActionResult> Index()
		{
			return View(await _categoryService.GetAllCategories());
		}

		[HttpGet("categories/add")]
		public IActionResult AddCategory()
		{
			return View();
		}
		[HttpPost("categories/add")]
		public async Task<IActionResult> AddCategory(AddCategoryDTO addCategory)
		{
			if (ModelState.IsValid)
			{
				await _categoryService.CreateCategory(addCategory);
				TempData[SuccessMessage] = "دسته بندی جدید اضافه شد";
				return RedirectToAction("Index");
			}
			return View(addCategory);
		}

		[HttpGet("categories/edit/{id}")]
		public async Task<IActionResult> EditCategory(long id)
		{
			var result = await _categoryService.FillEditCategoryDTO(id);

			if (result == null) return NotFound();

			return View(result);
		}

		[HttpPost("categories/edit/{id}")]
		public async Task<IActionResult> EditCategory(EditCategoryDTO edit)
		{
			
			if (ModelState.IsValid)
			{
				var result = await _categoryService.EditCategory(edit);
				if (result)
				{
					TempData[SuccessMessage] = "دسته بندی ویرایش شد";
					return RedirectToAction("Index");
				}
				return View(edit);
			}


			return View(edit);
		}
	}
}

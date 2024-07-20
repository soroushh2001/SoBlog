using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SoBlog.Application.Extensions;
using SoBlog.Application.Interfaces;
using SoBlog.Application.Statics;
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
		public async Task<IActionResult> AddCategory(AddCategoryDTO addCategory, IFormFile image)
		{
			if (ModelState.IsValid)
			{
				if (image == null) 
				{ 
					TempData[ErrorMessage] = "لطفا عکس را وارد کنید";
					return View(addCategory); 
				}

				var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(image.FileName);

				image.UploadFile(imageName, PathTools.CategoryImageServerPath);
				await _categoryService.CreateCategory(addCategory,imageName);
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
		public async Task<IActionResult> EditCategory(EditCategoryDTO edit, IFormFile? image)
		{
			
			if (ModelState.IsValid)
			{
				if (image != null)
				{
					var oldImage = PathTools.CategoryImageServerPath + edit.ImageName;

                    if (System.IO.File.Exists(oldImage))
                    {
                        System.IO.File.Delete(oldImage);
                    }

                    string imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(image.FileName);
                    image.UploadFile(imageName, PathTools.CategoryImageServerPath);
					await _categoryService.EditCategory(edit, imageName);
                    TempData[SuccessMessage] = "دسته بندی ویرایش شد";
                    return RedirectToAction("Index");
                }

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

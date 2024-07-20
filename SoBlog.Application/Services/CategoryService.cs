using SoBlog.Application.Interfaces;
using SoBlog.Domain.DTOs.Categories;
using SoBlog.Domain.Entities.Blog;
using SoBlog.Domain.Interfaces;

namespace SoBlog.Application.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;
		public CategoryService(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public async Task<bool> CreateCategory(AddCategoryDTO addCategory, string imageName)
		{
			var newCategory = new Category
			{
				Color = addCategory.Color,
				DisplayTitle = addCategory.DisplayTitle,
				CreatedDate = DateTime.Now,
				SystemTitle = addCategory.SystemTitle,
				UpdatedDate = DateTime.Now,
				Image = imageName
			};
			await _categoryRepository.AddCategory(newCategory);
			await _categoryRepository.SaveChanges();
			return true;
		}

		public async Task<IEnumerable<Category>?> GetAllCategories()
		{
			return await _categoryRepository.GetAllCategories();
		}

		public async Task<EditCategoryDTO?> FillEditCategoryDTO(long categoryId)
		{
			var getCategory = await _categoryRepository.GetCategoryById(categoryId);
			if(getCategory == null)  return null;

			return new EditCategoryDTO
			{ 
				DisplayTitle = getCategory.DisplayTitle,
				Color = getCategory.Color,
				Id = getCategory.Id,
				SystemTitle = getCategory.SystemTitle,
				ImageName =  getCategory.Image
			};
		}

		public async Task<bool> EditCategory(EditCategoryDTO editCategory, string? imageName = null)
		{
			var getCategory = await _categoryRepository.GetCategoryById(editCategory.Id);
			if(getCategory == null) return false;

			getCategory.DisplayTitle = editCategory.DisplayTitle;
			getCategory.Color = editCategory.Color;
			getCategory.UpdatedDate = DateTime.Now;
			getCategory.SystemTitle = editCategory.SystemTitle;
			if (imageName != null)
			{
				getCategory.Image = imageName;
			}
			_categoryRepository.UpdateCategory(getCategory);
			await _categoryRepository.SaveChanges();
			return true;
		}

		public async Task<IEnumerable<ShowCategoryInIndex>> ShowCategoryInIndex()
		{
			var cat = await _categoryRepository.GetAllCategories();
			return cat.Select(c => new ShowCategoryInIndex
			{
				Id = c.Id,
				Image = c.Image,
				Name = c.DisplayTitle

			}).ToList();
		}

    }
}

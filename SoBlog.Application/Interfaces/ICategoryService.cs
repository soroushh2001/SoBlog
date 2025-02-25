﻿using SoBlog.Domain.DTOs.Categories;
using SoBlog.Domain.Entities.Blog;

namespace SoBlog.Application.Interfaces
{
	public interface ICategoryService
	{
		Task<bool> CreateCategory(AddCategoryDTO addCategory, string imageName);
		Task<IEnumerable<Category>?> GetAllCategories();
		Task<EditCategoryDTO?> FillEditCategoryDTO(long categoryId);
		Task<bool> EditCategory(EditCategoryDTO editCategory, string? imageName = null);
		Task<IEnumerable<ShowCategoryInIndex>> ShowCategoryInIndex();
	}
}

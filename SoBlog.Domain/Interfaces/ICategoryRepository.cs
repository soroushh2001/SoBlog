using SoBlog.Domain.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBlog.Domain.Interfaces
{
	public interface ICategoryRepository
	{
		Task<IEnumerable<Category>> GetAllCategories();
		Task<Category?> GetCategoryById(long id);
		Task AddCategory(Category category);
		void UpdateCategory(Category category);
		Task SaveChanges();
	}
}

using Microsoft.EntityFrameworkCore;
using SoBlog.Domain.Entities.Blog;
using SoBlog.Domain.Interfaces;
using SoBlog.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBlog.Infra.Data.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly SoBlogDbContext _context;
		public CategoryRepository(SoBlogDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Category>> GetAllCategories()
		{
			return await _context.Categories.ToListAsync();
		}

		public async Task<Category?> GetCategoryById(long id)
		{
			return await _context.Categories.FindAsync(id);
		}


		public async Task AddCategory(Category category)
		{
			await _context.Categories.AddAsync(category);
		}

		public void UpdateCategory(Category category)
		{
			_context.Categories.Update(category);
		}

		public async Task SaveChanges()
		{
			await _context.SaveChangesAsync();
		}
	}
}

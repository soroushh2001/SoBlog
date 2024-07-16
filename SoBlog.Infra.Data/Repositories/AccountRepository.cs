using Microsoft.EntityFrameworkCore;
using SoBlog.Domain.Entities.Account;
using SoBlog.Domain.Interfaces;
using SoBlog.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBlog.Infra.Data.Repositories
{
	public class AccountRepository : IAccountRepository
	{
		private readonly SoBlogDbContext _context;

		public AccountRepository(SoBlogDbContext context)
		{
			_context = context;
		}

		public async Task<bool> IsUserExistedByEmail(string email)
		{
			return await _context.Users.AnyAsync(u => u.Email == email.Trim().ToLower());
		}

		public async Task<User?> GetUserByEmail(string email)
		{
			return await _context.Users.SingleOrDefaultAsync(u => u.Email == email.Trim().ToLower());
		}

		public async Task<User?> GetUserByEmailActiveCode(string emailActiveCode)
		{
			return await _context.Users.SingleOrDefaultAsync(u => u.EmailActiveCode == emailActiveCode);
		}

		public async Task<User?> GetUserById(long id)
		{
			return await _context.Users.FindAsync(id);
		}

        public async Task AddUser(User user)
		{
			await _context.Users.AddAsync(user);
		}

		public void UpdateUser(User user)
		{
			_context.Users.Update(user);
		}


        public async Task SaveChanges()
		{
			await _context.SaveChangesAsync();
		}

	}
}

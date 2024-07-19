using SoBlog.Domain.Entities.Account;

namespace SoBlog.Domain.Interfaces
{
	public interface IAccountRepository 
	{
		Task<bool> IsUserExistedByEmail(string email);
		Task<User?> GetUserByEmail(string email);
		Task<User?> GetUserByEmailActiveCode(string emailActiveCode);
		Task<User?> GetUserById(long id);
		Task<string>GetUserFullNameById(long id);
		Task AddUser(User  user);
		void UpdateUser(User user);
		Task SaveChanges();
	}
}

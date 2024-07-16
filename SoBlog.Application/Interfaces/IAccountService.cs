using SoBlog.Domain.DTOs.Account;
using SoBlog.Domain.Entities.Account;

namespace SoBlog.Application.Interfaces
{
	public interface IAccountService
	{
		Task<RegisterUserResult> RegisterUser(RegisterUserDTO register);
		Task<User?> GetUserByEmail(string email);
		Task<User?> GetUserById(long id);
		Task<bool> ActivateUser(string emailActiveCode);
		Task<LoginUserResult> CheckUserForLogin(LoginUserDTO login);
	}
}

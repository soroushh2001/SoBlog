using BCrypt.Net;
using SoBlog.Application.Interfaces;
using SoBlog.Domain.DTOs.Account;
using SoBlog.Domain.Entities.Account;
using SoBlog.Domain.Interfaces;

namespace SoBlog.Application.Services
{
	public class AccountService : IAccountService
	{
		private readonly IAccountRepository _accountRepository;

		public AccountService(IAccountRepository accountRepository)
		{
			_accountRepository = accountRepository;
		}

		public async Task<RegisterUserResult> RegisterUser(RegisterUserDTO register)
		{
			if (await _accountRepository.IsUserExistedByEmail(register.Email.Trim().ToLower()))
				return RegisterUserResult.UserExisted;



			var newUser = new User
			{
				Email = register.Email,
				AvatarName = "",
				CreatedDate = DateTime.Now,
				RoleId = 1,
				Password = BCrypt.Net.BCrypt.HashPassword(register.Password),
				UpdatedDate = DateTime.Now,
				EmailActiveCode = Guid.NewGuid().ToString("N"),
			};

			await _accountRepository.AddUser(newUser);
			await _accountRepository.SaveChanges();

			return RegisterUserResult.Success;

		}

		public async Task<User?> GetUserByEmail(string email)
		{
			return await _accountRepository.GetUserByEmail(email);
		}

		public async Task<User?> GetUserById(long id)
		{
			return await _accountRepository.GetUserById(id);
		}

        public async Task<bool> ActivateUser(string emailActiveCode)
		{
			var user = await _accountRepository.GetUserByEmailActiveCode(emailActiveCode);
			if (user == null || user.IsDeleted) return false;

			user.IsEmailConfirmed = true;
			user.EmailActiveCode = Guid.NewGuid().ToString("N");
			_accountRepository.UpdateUser(user);
			await _accountRepository.SaveChanges();
			return true;
		}

		public async Task<LoginUserResult> CheckUserForLogin(LoginUserDTO login)
		{
			var user = await _accountRepository.GetUserByEmail(login.Email.Trim().ToLower());
			if (user == null || user.IsDeleted ) return LoginUserResult.UserNotExisted;
			var hasPassword = BCrypt.Net.BCrypt.Verify(login.Password, user.Password);
			if (!hasPassword) return LoginUserResult.UserNotExisted;
			if (!user.IsEmailConfirmed) return LoginUserResult.EmailNotActivated;
			return LoginUserResult.Success;
		}


	}
}

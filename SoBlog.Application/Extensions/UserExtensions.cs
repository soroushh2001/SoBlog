using SoBlog.Domain.Entities.Account;
using System.Security.Claims;

namespace SoBlog.MVC.SiteExtensions
{
	public static class UserExtensions
	{
		public static long GetUserId(this ClaimsPrincipal claimsPrincipal)
		{
			var identifier = claimsPrincipal.Claims.SingleOrDefault(s => s.Type == ClaimTypes.NameIdentifier);

			if (identifier == null) return 0;

			return long.Parse(identifier.Value);
		}

		public static string GetUserDisplayName(this User user)
		{
			if (!string.IsNullOrEmpty(user.FirstName) && !string.IsNullOrEmpty(user.LastName))
			{
				return $"{user.FirstName} {user.LastName}";
			}

			var email = user.Email.Split("@")[0];

			return email;
		}
	}
}

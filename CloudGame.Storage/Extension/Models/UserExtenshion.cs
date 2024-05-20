using CloudGame.Storage.Models;

namespace CloudGame.Storage.Extension.Models;

public static class UserExtenshion
{
	public static string GetNameUserTariff(this User user)
	{
		return string.Join("", (new string[] {
			user.NameUser,
			user.Tariff
		}).Where(x => !string.IsNullOrEmpty(x)));
	}
}
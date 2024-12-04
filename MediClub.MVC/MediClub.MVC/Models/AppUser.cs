using Microsoft.AspNetCore.Identity;

namespace MediClub.MVC.Models;

public class AppUser: IdentityUser
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
}

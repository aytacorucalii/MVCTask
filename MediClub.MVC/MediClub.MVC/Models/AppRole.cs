using Microsoft.AspNetCore.Identity;

namespace MediClub.MVC.Models;

public class AppRole:IdentityRole
{
	public string Description {  get; set; }

}

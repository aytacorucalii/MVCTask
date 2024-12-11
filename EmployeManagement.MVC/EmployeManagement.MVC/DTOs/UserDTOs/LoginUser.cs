using System.ComponentModel.DataAnnotations;

namespace EmployeManagement.MVC.DTOs.UserDTOs;

public class LoginUser
{
    [Required]
    [Display(Prompt = "Email or username")]
    public string EmailOrUsername { get; set; }
    [DataType(DataType.Password)]
    [Display(Prompt = "Password")]
    public string Password { get; set; }
    [Required]
    public bool IsPersistent { get; set; }

}

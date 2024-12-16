using System.ComponentModel.DataAnnotations;

namespace GameStorePr.MVC.DTOs.UserDTOs;

public class CreateUserDTO
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    [Display(Prompt = "First Name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Surname is required.")]
    [StringLength(100, ErrorMessage = "Surname cannot exceed 100 characters.")]
    [Display(Prompt = "Last Name")]
    public string Surname { get; set; }

    [Required(ErrorMessage = "Username is required.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters.")]
    [Display(Prompt = "Username")]
    public string Username { get; set; }

    [Display(Prompt = "Age")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
    [Display(Prompt = "Password")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Confirm Password is required.")]
    [StringLength(100, MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
    [Display(Prompt = "Confirm Password")]
    public string Confirmpassword { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [DataType(DataType.EmailAddress)]
    [Display(Prompt = "Email Address")]
    public string Email { get; set; }
}

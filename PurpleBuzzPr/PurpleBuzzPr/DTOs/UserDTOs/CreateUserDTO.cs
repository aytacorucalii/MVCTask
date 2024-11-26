using System.ComponentModel.DataAnnotations;

namespace PurpleBuzzPr.DTOs.UserDTOs;

public class CreateUserDTO
{
    [Required]
    [MinLength(2, ErrorMessage = "Name must be minimum 2 chars")]
    [MaxLength(50)]
    [Display(Prompt = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Name must be minimum 2 chars")]
    [MaxLength(50)]
    [Display(Prompt = "Last Name")]
    public string LastName { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    [Display(Prompt = "Email")]
    public string Email { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 30 chars")]
    [Display(Prompt = "Username")]
    public string Username { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Prompt = "Password")]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    [Display(Prompt = "Confirm Password")]
    public string ConfirmPassword { get; set; }
}

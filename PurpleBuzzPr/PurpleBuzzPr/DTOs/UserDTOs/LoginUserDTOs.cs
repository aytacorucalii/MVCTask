using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace PurpleBuzzPr.DTOs.UserDTOs;

public class LoginUserDTOs
{
    [Required]
    [Display(Prompt ="Email or username")]
    public string EmailOrUsername { get; set; }
    [DataType(DataType.Password)]
    [Display(Prompt = "Password")]
    public string Password { get; set; }
    [Required]
    public bool IsPersistent { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.DTOs;
public class Register : AccountBase
{
    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; }
    
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
    [Required]
    public string? ConfirmPassword { get; set; }
}

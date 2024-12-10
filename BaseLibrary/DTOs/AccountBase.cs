using System.ComponentModel.DataAnnotations;


namespace BaseLibrary.DTOs;
public class AccountBase
{
    [DataType(DataType.EmailAddress)]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [Required(ErrorMessage = "Email address is required")]
    public string? Email { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
}

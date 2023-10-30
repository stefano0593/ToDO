using System.ComponentModel.DataAnnotations;

namespace Todo.API.Controllers.Accounts.Contracts;

public class LoginRequest
{
    [Required] public string Email { get; set; }
    [Required] public string Password { get; set; }
}
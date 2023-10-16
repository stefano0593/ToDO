using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Todo.Domain.Shared.Validators;

namespace Todo.API.Controllers.Accounts.Contracts.Requests;

public class UserSignupRequest
{
    [Required]
    [MaxLength(RuleConstants.AccountNameMaxLength)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(RuleConstants.AccountNameMaxLength)]
    public string LastName { get; set; } = null!;
    
    [Required] 
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;

    public string? PictureUrl { get; set; }
}
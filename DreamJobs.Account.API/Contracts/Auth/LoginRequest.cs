using System.ComponentModel.DataAnnotations;

namespace DreamJobs.Account.API.Contracts.Auth;

public class LoginRequest
{
    [Required] [EmailAddress] public string Email { get; set; }
    [Required] public string Password { get; set; }
}
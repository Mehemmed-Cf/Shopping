using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Shopping.Application.Modules.AccountModule.Commands.SigninCommand
{
    public class SigninRequest : IRequest<ClaimsPrincipal>
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }
    }
} 

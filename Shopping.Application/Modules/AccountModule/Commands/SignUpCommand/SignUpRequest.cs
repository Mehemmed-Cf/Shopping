using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Shopping.Application.Modules.AccountModule.Commands.SignUpCommand
{
    public class SignUpRequest : IRequest<ClaimsPrincipal>
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }
    }
}

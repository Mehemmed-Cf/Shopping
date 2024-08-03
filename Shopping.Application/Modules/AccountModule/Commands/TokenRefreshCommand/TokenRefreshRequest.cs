using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Shopping.Application.Modules.AccountModule.Commands.TokenRefreshCommand
{
    public class TokenRefreshRequest : IRequest<TokenRefreshRequestDto>
    {
        [FromHeader]
        public string RefreshToken { get; set; }
    }
}

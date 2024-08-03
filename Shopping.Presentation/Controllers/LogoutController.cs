using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping.Application.Modules.AccountModule.Commands.SignOutCommand;
using Shopping.Domain.Models.Entities.Membership;
using Shopping.Infrastructure.Abstracts;

namespace Shopping.Presentation.Controllers
{
    public class LogoutController : Controller
    {
        private readonly IMediator mediator;
        private readonly IConfiguration configuration;
        private readonly IJwtService jwtService;
        private readonly DbContext db;
        private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signinManager;
        private readonly IAuthenticationSchemeProvider schemeProvider;

        public LogoutController(IMediator mediator, IConfiguration configuration, IJwtService jwtService, DbContext db, Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager, SignInManager<AppUser> signinManager, IAuthenticationSchemeProvider schemeProvider)
        {
            this.mediator = mediator;
            this.configuration = configuration;
            this.jwtService = jwtService;
            this.db = db;
            this.userManager = userManager;
            this.signinManager = signinManager;
            this.schemeProvider = schemeProvider;
        }

        [HttpPost]
        public async Task<IActionResult> Signout()
        {
            var response = await mediator.Send(new SignOutRequest());

            if (response)
            {
                TempData["LogOutMessage"] = System.Web.HttpUtility.JavaScriptStringEncode("You were logged Out thanks to my ? .... ? level coding skills");
                return RedirectToAction(nameof(Index), "Home");
            }
            else
            {
                TempData["LogOutFailMessage"] = System.Web.HttpUtility.JavaScriptStringEncode("I was not able to log you out, did you do something wrong?");
                return RedirectToAction(nameof(Index), "Home");
            }
        }
    }
}

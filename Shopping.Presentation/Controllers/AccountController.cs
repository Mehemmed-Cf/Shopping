using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping.Application.Modules.AccountModule.Commands.SigninCommand;
using Shopping.Application.Modules.AccountModule.Commands.TokenRefreshCommand;
using Shopping.Domain.Models.Entities.Membership;
using Shopping.Infrastructure.Abstracts;
using Shopping.Application.Modules.AccountModule.Commands.SignOutCommand;
using System.Text.Encodings.Web;
using Shopping.Application.Modules.AccountModule.Commands.SignUpCommand;
using Shopping.Application.Repositories;

namespace Shopping.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator mediator;
        private readonly IConfiguration configuration;
        private readonly IJwtService jwtService;
        private readonly DbContext db;
        private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signinManager;
        private readonly IAuthenticationSchemeProvider schemeProvider;
        private readonly IUserRepository userRepository;

        public AccountController(IMediator mediator, IConfiguration configuration, IJwtService jwtService, DbContext db, Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager, SignInManager<AppUser> signinManager, IAuthenticationSchemeProvider schemeProvider, IUserRepository userRepository)
        {
            this.mediator = mediator;
            this.configuration = configuration;
            this.jwtService = jwtService;
            this.db = db;
            this.userManager = userManager;
            this.signinManager = signinManager;
            this.schemeProvider = schemeProvider;
            this.userRepository = userRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Signin(SigninRequest request)
        {
            if(ModelState.IsValid)
            {
                var principal = await mediator.Send(request);
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            TempData["LogInError"] = System.Web.HttpUtility.JavaScriptStringEncode("You are not Mentally Ill enaugh to Log");
            return RedirectToAction(nameof(LoginController.Index), "Login");
        }

        [HttpGet]
        [AllowAnonymous]

        public async Task<IActionResult> Signout()
        {
            var response = await mediator.Send(new SignOutRequest());

            if (response)
            {
                return RedirectToAction(nameof(Index), "Home");
            }
            else
            {
                return RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpPost]
        [Route("account/signup")]
        [AllowAnonymous]
        public async Task<IActionResult> Signup(SignUpRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var principal = await mediator.Send(request);
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return RedirectToAction(nameof(SignupController.Index), "SignUp");

            //return View(request);
        }

        [HttpPost("refresh-token")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken([FromRoute] TokenRefreshRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Org.BouncyCastle.Crypto.Generators;
using Shopping.Application.Modules.ProductsModule.Queries.ProductGetAllQuery;
using Shopping.Application.Modules.UsersModule.Queries.GetAllQuery;
using Shopping.Presentation.Helpers;

namespace Shopping.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class UsersController : Controller
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Admin/users")]
        public async Task<IActionResult> Index(UserGetAllRequest request)
        {
            var response = await mediator.Send(request);

            if (RouteHelper.IsJsonRequest(HttpContext))
            {
                return Json(response);
            }

            return View(response);
        }
    }
}

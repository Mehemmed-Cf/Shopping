using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping.Application.Modules.ProductsModule.Queries.ProductGetByIdQuery;

namespace Shopping.Presentation.Controllers
{
    public class ProductDetailsController : Controller
    {
        private readonly IMediator mediator;

        public ProductDetailsController(
        IMediator mediator)
        {
            this.mediator = mediator;
        }

        [AllowAnonymous]
        [Route("ProductDetails/{id}")]
        public async Task<IActionResult> Index([FromRoute] ProductGetByIdRequest request)
        {
            try
            {
                var response = await mediator.Send(request);

                if (response == null)
                {
                    return View("~/Views/NotFound/Index.cshtml");
                    //return Ok();
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View("~/Views/NotFound/Index.cshtml");
               // return Ok();
            }
        }
    }
}

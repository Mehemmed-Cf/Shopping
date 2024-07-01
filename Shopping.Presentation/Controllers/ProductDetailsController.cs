using Azure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopping.Application.Modules.ProductsModule.Queries.ProductGetByIdQuery;
using Shopping.Application.Repositories;

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

        [Route("ProductDetails/{id}")]
        public async Task<IActionResult> Index([FromRoute] ProductGetByIdRequest request)
        {
            try
            {
                var response = await mediator.Send(request);

                //if (response == null)
                //{
                //    return View("~/Views/NotFound/Index.cshtml");
                //}

                return View(response);
            }
            catch (Exception ex)
            {
                return View();
                //return View("~/Views/NotFound/Index.cshtml");
            }
        }
    }
}

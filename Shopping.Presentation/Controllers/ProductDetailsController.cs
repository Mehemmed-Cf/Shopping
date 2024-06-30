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
            var response = await mediator.Send(request);

            if (response == null)
            {
                return NotFound(); // Redirect to NotFound page if product is not found
            }

            return View(response);
        }
    }
}

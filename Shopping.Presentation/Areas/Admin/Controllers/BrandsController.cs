using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopping.Application.Modules.BrandsModule.Commands.BrandAddCommand;
using Shopping.Application.Modules.BrandsModule.Commands.BrandEditCommand;
using Shopping.Application.Modules.BrandsModule.Commands.BrandRemoveCommand;
using Shopping.Application.Modules.BrandsModule.Queries.BrandGetAllQuery;
using Shopping.Application.Modules.BrandsModule.Queries.BrandGetByIdQuery;

namespace Shopping.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandsController : Controller
    {
        private readonly IMediator mediator;

        public BrandsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(BrandGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> Details([FromRoute] BrandGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BrandAddRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit([FromRoute] BrandGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BrandEditRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Remove([FromRoute] BrandRemoveRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
    }
}

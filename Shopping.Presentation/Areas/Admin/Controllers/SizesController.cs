using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopping.Application.Modules.SizesModule.Commands.SizeAddCommand;
using Shopping.Application.Modules.SizesModule.Commands.SizeEditCommand;
using Shopping.Application.Modules.SizesModule.Commands.SizeRemoveCommand;
using Shopping.Application.Modules.SizesModule.Queries.SizeGetAllQuery;
using Shopping.Application.Modules.SizesModule.Queries.SizeGetByIdQuery;

namespace Shopping.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SizesController : Controller
    {
        private readonly IMediator mediator;

        public SizesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(SizeGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> Details([FromRoute] SizeGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SizeAddRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit([FromRoute] SizeGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SizeEditRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Remove([FromRoute] SizeRemoveRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
    }
}

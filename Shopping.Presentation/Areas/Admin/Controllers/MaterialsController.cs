using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopping.Application.Modules.MaterialsModule.Commands.MaterialAddCommand;
using Shopping.Application.Modules.MaterialsModule.Commands.MaterialEditCommand;
using Shopping.Application.Modules.MaterialsModule.Commands.MaterialRemoveCommand;
using Shopping.Application.Modules.MaterialsModule.Queries.MaterialGetAllQuery;
using Shopping.Application.Modules.MaterialsModule.Queries.MaterialGetByIdQuery;

namespace Shopping.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MaterialsController : Controller
    {
        private readonly IMediator mediator;

        public MaterialsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(MaterialGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> Details([FromRoute] MaterialGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MaterialAddRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit([FromRoute] MaterialGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MaterialEditRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Remove([FromRoute] MaterialRemoveRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
    }
}

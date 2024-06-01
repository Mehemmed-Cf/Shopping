using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopping.Application.Modules.ColorsModule.Commands.ColorAddCommand;
using Shopping.Application.Modules.ColorsModule.Commands.ColorEditCommand;
using Shopping.Application.Modules.ColorsModule.Commands.ColorRemoveCommand;
using Shopping.Application.Modules.ColorsModule.Queries.ColorGetAllQuery;
using Shopping.Application.Modules.ColorsModule.Queries.ColorGetByIdQuery;

namespace Shopping.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorsController : Controller
    {
        private readonly IMediator mediator;
        //private readonly IValidator<ColorAddRequest> colorAddValidator;

        public ColorsController(IMediator mediator) //IValidator<ColorAddRequest> colorAddValidator
        {
            this.mediator = mediator;
            //this.colorAddValidator = colorAddValidator;
        }

        public async Task<IActionResult> Index(ColorGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> Details([FromRoute] ColorGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ColorAddRequest request)
        {

            /* var response = colorAddValidator.Validate(request);


            if (!response.IsValid)
            {
                return BadRequest(response);
            } */

            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit([FromRoute] ColorGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ColorEditRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Remove([FromRoute] ColorRemoveRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
    }
}

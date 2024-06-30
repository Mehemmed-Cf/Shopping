using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopping.Application.Modules.SubscribersModule.Commands.SubscriberAddCommand;
using Shopping.Application.Modules.SubscribersModule.Commands.SubscriberEditCommand;
using Shopping.Application.Modules.SubscribersModule.Commands.SubscriberRemoveCommand;
using Shopping.Application.Modules.SubscribersModule.Queries.SubscriberGetAllQuery;
using Shopping.Application.Modules.SubscribersModule.Queries.SubscriberGetByEmailQuery;
using Shopping.Application.Modules.SubscribersModule.Queries.SubscriberGetByIdQuery;

namespace Shopping.Presentation.Areas.Admin.Controllers
{
    [Area("admin")]
    public class SubscribersController : Controller
    {
        private readonly IMediator mediator;

        public SubscribersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(SubscriberGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return Json(response);
        }

        public async Task<IActionResult> Details([FromRoute] SubscriberGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpGet("/Admin/subscribers/{email}")]
        public async Task<IActionResult> Email(string email)
        {
            var request = new SubscriberGetByEmailRequest { Email = email };
            var response = await mediator.Send(request);

            if (response == null)
            {
                return NotFound(); // Handle case where subscriber with given email is not found
            }

            return Ok(response); // Return JSON response
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubscriberAddRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit([FromRoute] SubscriberGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SubscriberEditRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Remove([FromRoute] SubscriberRemoveRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
    }
}

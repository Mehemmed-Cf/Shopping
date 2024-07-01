using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopping.Application.Modules.SubscribersModule.Commands.SubscriberAddCommand;
using Shopping.Application.Modules.SubscribersModule.Commands.SubscriberEditCommand;
using Shopping.Application.Modules.SubscribersModule.Commands.SubscriberRemoveCommand;
using Shopping.Application.Modules.SubscribersModule.Queries.SubscriberGetAllQuery;
using Shopping.Application.Modules.SubscribersModule.Queries.SubscriberGetByEmailQuery;
using Shopping.Application.Modules.SubscribersModule.Queries.SubscriberGetByIdQuery;
using Shopping.Presentation.Helpers;

namespace Shopping.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
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

            if (RouteHelper.IsJsonRequest(HttpContext))
            {
                return Json(response);
            }

            return View(response);
        }

        public async Task<IActionResult> Details([FromRoute] SubscriberGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpGet("/Admin/subscribers/{email}")]
        public async Task<IActionResult> Email(string email)
        {
            //var request = new SubscriberGetByEmailRequest { Email = email };
            //var response = await mediator.Send(request);

            //if (response == null)
            //{
            //    return NotFound();
            //}

            if(RouteHelper.IsJsonRequest(HttpContext))
            {
                //return Json(response);

                return Ok(new
                {
                    exist = false
                });
            }

            return View(null);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> Create(string email)
        {
            await mediator.Send(new SubscriberAddRequest
            {
                Email = email
            });
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

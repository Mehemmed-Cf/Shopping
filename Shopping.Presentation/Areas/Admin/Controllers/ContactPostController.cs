using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopping.Application.Modules.ContactPostsModule.Commands.ContactPostEditCommand;
using Shopping.Application.Modules.ContactPostsModule.Queries.ContactPostGetAllQuery;
using Shopping.Application.Modules.ContactPostsModule.Queries.ContactPostGetByIdQuery;

namespace Shopping.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactPostController : Controller
    {
        private readonly IMediator mediator;

        public ContactPostController(IMediator mediator) 
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(ContactPostGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> Details([FromRoute] ContactPostGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> Edit([FromRoute] ContactPostGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ContactPostEditRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
    }
}

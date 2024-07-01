using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopping.Application.Modules.ContactPostsModule.Commands.ContactPostApplyCommand;
using Shopping.Application.Modules.ProductsModule.Queries.ProductGetAllQuery;
using Shopping.Application.Repositories;

namespace Shopping.Presentation.Controllers
{
    public class ContactPostController : Controller
    {
        private readonly IMediator mediator;

        public ContactPostController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            if (Request.Headers["Accept"].ToString().Contains("application/json"))
            {
                // Return JSON response
                return Ok(new { message = "JSON response" });
            }
            else
            {
                // Return View response
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactPostApplyRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.FullName))
            {
                ModelState.AddModelError("FullName", "Ad doldurulmayib");
            }

            if (string.IsNullOrWhiteSpace(request.Email))
            {
                ModelState.AddModelError("Email", "Email doldurulmayib");
            }

            if (string.IsNullOrWhiteSpace(request.Subject))
            {
                ModelState.AddModelError("Subject", "Subject doldurulmayib");
            }

            if (string.IsNullOrWhiteSpace(request.Content))
            {
                ModelState.AddModelError("Message", "Message doldurulmayib");
            }

            if (ModelState.IsValid)
            {
                await mediator.Send(request);

                TempData["SuccessMessage"] = "Submission successful. Approved with a 'Dexter Morgan' level of precision!";

                return RedirectToAction(nameof(Index));

                //return Json(new
                //{
                //    error = false,
                //    message = "",
                //    errors = new Dictionary<string, IEnumerable<string>>()
                //});
            }

            //List< KeyValuePair<string,ModelStateEntry> > 

            var errors = ModelState.Select(m => new
            {
                Property = m.Key,
                Messages = m.Value.Errors.Select(m => m.ErrorMessage)
            })
                .ToDictionary(m => m.Property, v => v.Messages);

            return BadRequest(new
            {
                error = true,
                message = "Xəta var",
                errors = errors
            });
        }
    }
}
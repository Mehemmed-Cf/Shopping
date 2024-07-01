using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopping.Application.Modules.ProductsModule.Queries.ProductGetAllQuery;
using Shopping.Application.Repositories;
using Shopping.Application.Modules.SubscribersModule.Commands.SubscriberAddCommand;
using Shopping.Application.Modules.SubscribersModule.Queries.SubscriberGetByEmailQuery;

namespace Shopping.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IColorRepository _colorRepository;
        private readonly ISizeRepository _sizeRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly ISubscriberRepository subscriberRepository;
        private readonly IMediator mediator;

        public HomeController(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IBrandRepository brandRepository,
            IColorRepository colorRepository,
            ISizeRepository sizeRepository,
            IMaterialRepository materialRepository,
            ISubscriberRepository subscriberRepository,
            IMediator mediator)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
            _colorRepository = colorRepository;
            _sizeRepository = sizeRepository;
            _materialRepository = materialRepository;
            this.subscriberRepository = subscriberRepository;
            this.mediator = mediator;
        }

        private void PopulateViewBags()
        {
            ViewBag.Categories = _categoryRepository.GetAll();
            ViewBag.Brands = _brandRepository.GetAll();
            ViewBag.Sizes = _sizeRepository.GetAll();
            ViewBag.Colors = _colorRepository.GetAll();
            ViewBag.Materials = _materialRepository.GetAll();
        }

        public async Task<IActionResult> Index(ProductGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        //[HttpGet("/Admin/Subscribers/{email}")]
        public async Task<IActionResult> CheckEmailExists(string email)
        {
            try
            {
                var subscriber = await subscriberRepository.GetByEmailAsync(email); // Implement this method in your repository
                if (subscriber != null)
                {
                    return Ok(new { exists = true });
                }
                else
                {
                    return Ok(new { exists = false });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        [HttpPost("/Admin/Subscribers")]
        public async Task<IActionResult> Subscribe([FromBody] SubscriberAddRequest request)
        {
            try
            {
                var existingSubscriber = await mediator.Send(new SubscriberGetByEmailRequest { Email = request.Email });

                if (existingSubscriber != null)
                {
                    ModelState.AddModelError("Email", "You are already subscribed.");
                    return Json(new { Message = "You are already subscribed." });
                }

                var response = await mediator.Send(request);
                return Json(new { Message = "Subscription successful" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }
    }
}

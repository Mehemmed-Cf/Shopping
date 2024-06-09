using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopping.Application.Modules.BlogPostsModule.Commands.BlogPostAddCommand;
using Shopping.Application.Modules.BlogPostsModule.Commands.BlogPostEditCommand;
using Shopping.Application.Modules.BlogPostsModule.Commands.BlogPostRemoveCommand;
using Shopping.Application.Modules.BlogPostsModule.Queries.BlogPostGetAllQuery;
using Shopping.Application.Modules.BlogPostsModule.Queries.BlogPostGetByIdQuery;
using Shopping.Application.Repositories;

namespace Shopping.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogPostsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IColorRepository _colorRepository;
        private readonly ISizeRepository _sizeRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IMediator mediator;

        public BlogPostsController(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IMediator mediator)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            this.mediator = mediator;
        }

        private void PopulateViewBags()
        {
            ViewBag.Categories = _categoryRepository.GetAll();
        }

        public async Task<IActionResult> Index(BlogPostGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> Details([FromRoute] BlogPostGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public IActionResult Create()
        {
            PopulateViewBags();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] BlogPostAddRequest request)
        {
            if (!ModelState.IsValid)
            {
                PopulateViewBags();
                return View(request);
            }

            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit([FromRoute] BlogPostGetByIdRequest request)
        {
            PopulateViewBags();

            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] BlogPostEditRequest request)
        {
            if (!ModelState.IsValid)
            {
                PopulateViewBags();
                return View(request);
            }

            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Remove([FromRoute] BlogPostRemoveRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
    }
}

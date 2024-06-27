using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopping.Application.Modules.ProductsModule.Commands.ProductAddCommand;
using Shopping.Application.Modules.ProductsModule.Commands.ProductEditCommand;
using Shopping.Application.Modules.ProductsModule.Commands.ProductRemoveCommand;
using Shopping.Application.Modules.ProductsModule.Queries.ProductGetAllQuery;
using Shopping.Application.Modules.ProductsModule.Queries.ProductGetByIdQuery;
using Shopping.Application.Repositories;

namespace Shopping.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IColorRepository _colorRepository;
        private readonly ISizeRepository _sizeRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IMediator mediator;

        public ProductsController(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IBrandRepository brandRepository,
            IColorRepository colorRepository,
            ISizeRepository sizeRepository,
            IMaterialRepository materialRepository,
            IMediator mediator)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
            _colorRepository = colorRepository;
            _sizeRepository = sizeRepository;
            _materialRepository = materialRepository;
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

        public async Task<IActionResult> Index(ProductGetAllRequest request) //, bool IsJson = false
        {
            var response = await mediator.Send(request);
/*
            if (IsJson == true)
            {
                return Json(response);
            }*/

            return View(response);
        }

        public async Task<IActionResult> Details([FromRoute] ProductGetByIdRequest request)
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
        public async Task<IActionResult> Create([FromForm] ProductAddRequest request)
        {
            if (!ModelState.IsValid)
            {
                PopulateViewBags();
                return View(request);
            }

            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit([FromRoute] ProductGetByIdRequest request)
        {
            PopulateViewBags();

            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] ProductEditRequest request)
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
        public async Task<IActionResult> Remove([FromRoute] ProductRemoveRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
    }
}

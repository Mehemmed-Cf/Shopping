using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopping.Application.Modules.ProductsModule.Queries.ProductGetAllQuery;
using Shopping.Application.Repositories;

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
        private readonly IMediator mediator;

        public HomeController(
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

        public async Task<IActionResult> Index(ProductGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }
    }
}

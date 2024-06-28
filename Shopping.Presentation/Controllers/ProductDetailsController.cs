using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopping.Application.Modules.ProductsModule.Queries.ProductGetByIdQuery;
using Shopping.Application.Repositories;

namespace Shopping.Presentation.Controllers
{
    public class ProductDetailsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IColorRepository _colorRepository;
        private readonly ISizeRepository _sizeRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IMediator mediator;

        public ProductDetailsController(
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

        [Route("ProductDetails/{id}")]
        public async Task<IActionResult> Index([FromRoute] ProductGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

/*        public async Task<IActionResult> Index([FromRoute] int id)
        {
            var request = new ProductGetByIdRequest { Id = id };
            var response = await mediator.Send(request);
            return View(response);
        }*/

        //[HttpGet("{id}")]
/*        public async Task<IActionResult> Index([FromRoute] ProductGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }*/
    }
}

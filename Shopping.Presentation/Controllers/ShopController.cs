using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopping.Application.Modules.ProductsModule.Queries.ProductGetAllQuery;
using Shopping.Application.Repositories;
using Shopping.Presentation.Helpers;

namespace Shopping.Presentation.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IColorRepository _colorRepository;
        private readonly ISizeRepository _sizeRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IMediator mediator;

        public ShopController(
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

        public async Task<IActionResult> Index(ProductGetAllRequest request, decimal? priceFrom, decimal? priceTo, string SortBy)
        {
            var response = await mediator.Send(request);

            if (priceFrom.HasValue && priceTo.HasValue)
            {
                response = response.Where(p => p.Price >= priceFrom.Value && p.Price <= priceTo.Value);
            }

            switch (SortBy) 
            {
                case "title-ascending":
                    response = response.OrderBy(p => p.Title);
                    break;
                case "title-descending":
                    response = response.OrderByDescending(p => p.Title);
                    break;
                case "price-ascending":
                    response = response.OrderBy(p => p.Price);
                    break;
                case "price-descending":
                    response = response.OrderByDescending(p => p.Price);
                    break;
                case "created-ascending":
                    response = response.OrderBy(p => p.CreatedAt);
                    break;
                case "created-descending":
                    response = response.OrderByDescending(p => p.CreatedAt);
                    break;
                default:
                    response = response.OrderBy(p => p.Title); // Default sort order
                    break;
            }

            if (RouteHelper.IsJsonRequest(HttpContext))
            {
                return Json(response);
            }

            return View(response);
        }
    }
}

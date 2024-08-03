using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping.Application.Modules.BlogPostsModule.Queries.BlogPostGetAllQuery;
using Shopping.Application.Repositories;

namespace Shopping.Presentation.Controllers
{
    public class BlogController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMediator mediator;

        public BlogController(
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

        [AllowAnonymous]
        public async Task<IActionResult> Index(BlogPostGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Shopping.Presentation.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

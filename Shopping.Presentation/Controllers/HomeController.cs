using Microsoft.AspNetCore.Mvc;

namespace Shopping.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

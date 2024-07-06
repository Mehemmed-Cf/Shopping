using Microsoft.AspNetCore.Mvc;

namespace Shopping.Presentation.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

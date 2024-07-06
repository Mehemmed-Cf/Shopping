using Microsoft.AspNetCore.Mvc;

namespace Shopping.Presentation.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Shopping.Presentation.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

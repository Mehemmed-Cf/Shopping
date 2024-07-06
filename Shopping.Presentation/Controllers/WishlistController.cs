using Microsoft.AspNetCore.Mvc;

namespace Shopping.Presentation.Controllers
{
    public class WishlistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

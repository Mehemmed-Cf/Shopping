using Microsoft.AspNetCore.Mvc;

namespace Shopping.Presentation.Controllers
{
    public class NotFoundController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Shopping.Presentation.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

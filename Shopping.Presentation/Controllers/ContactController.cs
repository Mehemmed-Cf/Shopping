using Microsoft.AspNetCore.Mvc;

namespace Shopping.Presentation.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

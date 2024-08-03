using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Shopping.Presentation.Controllers
{
    public class CheckoutController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}

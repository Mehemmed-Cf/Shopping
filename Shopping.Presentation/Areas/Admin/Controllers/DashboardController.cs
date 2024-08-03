using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Shopping.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        //[Authorize(Policy = "home.index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
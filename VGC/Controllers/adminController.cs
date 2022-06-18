using Microsoft.AspNetCore.Mvc;

namespace VGC.Controllers
{
    public class adminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

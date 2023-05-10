using Microsoft.AspNetCore.Mvc;

namespace Hotel_Walker.Controllers
{
    public class AboutsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

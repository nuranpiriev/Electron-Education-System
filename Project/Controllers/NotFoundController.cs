using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class NotFoundController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

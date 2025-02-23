using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers;

public class CourseController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

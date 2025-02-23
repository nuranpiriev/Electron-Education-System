using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers;

public class TeamController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

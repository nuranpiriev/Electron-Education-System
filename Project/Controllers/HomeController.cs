using Microsoft.AspNetCore.Mvc;
using Project.Services.Abstractions;
using Project.ViewModels;

namespace Project.Controllers;

public class HomeController : Controller
{
    readonly ICourseService _courseService;
    readonly ITeacherService _teacherService;
    readonly ISliderItemService _sliderItemService;

    public HomeController(ICourseService courseService, ITeacherService teacherService, ISliderItemService sliderItemService)
    {
        _courseService = courseService;
        _teacherService = teacherService;
        _sliderItemService = sliderItemService;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            HomeVM VM = new()
            {
                Sliders = await _sliderItemService.GetSliderItemViewItemsAsync(),
                Courses = await _courseService.GetCourseViewItemsAsync(),
                Teachers = await _teacherService.GetTeacherViewItemsAsync()
            };

            return View(VM);
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }
}


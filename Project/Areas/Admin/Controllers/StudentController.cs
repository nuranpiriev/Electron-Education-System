using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.DTOs;
using Project.DTOs.StudentDTOs;
using Project.Services.Abstractions;
using Project.Services.Concretes;

namespace Project.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StudentController : Controller
    {
        readonly IStudentService _service;
        readonly ICourseService _courseService;

        public StudentController(IStudentService service, ITeacherService teacherService, ICourseService courseService)
        {
            _service = service;
            _courseService = courseService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<StudentListItemDTO> list = await _service.GetStudentListItemsAsync();

                return View(list);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }

        public async Task<IActionResult> Create()
        {
            try
            {
               ViewData["Courses"] = new SelectList(await _courseService.GetCourseListItemsAsync(), "Id", "Name"); 
                return View();
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Courses"] = new SelectList(await _courseService.GetCourseListItemsAsync(), "Id", "Name");
                return View(dto);
            }

            try
            {
                await _service.CreateAsync(dto);
                await _service.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (BaseException ex)
            {
               ViewData["Courses"] = new SelectList(await _courseService.GetCourseListItemsAsync(), "Id", "Name");
                ModelState.AddModelError("CustomError", ex.Message);
                return View(dto);
            }
            catch (Exception)
            {
                ViewData["Courses"] = new SelectList(await _courseService.GetCourseListItemsAsync(), "Id", "Name");
                ModelState.AddModelError("CustomError", "Something went wrong!");
                return View(dto);
            }
        }

        public async Task<IActionResult> Update(int id)
        {
            try
            {
               ViewData["Courses"] = new SelectList(await _courseService.GetCourseListItemsAsync(), "Id", "Name"); 
                return View(await _service.GetByIdForUpdateAsync(id));
            }
            catch (BaseException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(StudentUpdateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Courses"] = new SelectList(await _courseService.GetCourseListItemsAsync(), "Id", "Name");
                return View(dto);
            }

            try
            {
                await _service.UpdateAsync(dto);
                await _service.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (BaseException ex)
            {
                ViewData["Courses"] = new SelectList(await _courseService.GetCourseListItemsAsync(), "Id", "Name");
                ModelState.AddModelError("CustomError", ex.Message);
                return View(dto);
            }
            catch (Exception)
            {
                ViewData["Courses"] = new SelectList(await _courseService.GetCourseListItemsAsync(), "Id", "Name");
                ModelState.AddModelError("CustomError", "Something went wrong!");
                return View(dto);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                await _service.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (BaseException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var student = await _service.GetStudentDetailsAsync(id);
                return View(student);
            }
            catch (BaseException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }
    }

}

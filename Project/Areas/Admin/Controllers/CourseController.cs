using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.DTOs.CourseDTOs;
using Project.DTOs.CourseDTOs.Project.DTOs.CourseDTOs;
using Project.Services.Abstractions;
using Project.Services.Concretes;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CourseController : Controller
    {
        readonly ICourseService _service;
        readonly ITeacherService _teacherService;
        readonly IMapper _mapper;

        public CourseController(ICourseService service, ITeacherService teacherService, IMapper mapper)
        {
            _service = service;
            _teacherService = teacherService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<CourseListItemDTO> list = await _service.GetCourseListItemsAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                ViewData["Teachers"] = new SelectList(await _teacherService.GetTeacherListItemsAsync(), "Id", "FullName");
                return View();
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Teachers"] = new SelectList(await _teacherService.GetTeacherListItemsAsync(), "Id", "FullName");
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
                ViewData["Teachers"] = new SelectList(await _teacherService.GetTeacherListItemsAsync(), "Id", "FullName");
                ModelState.AddModelError("CustomError", ex.Message);
                return View(dto);
            }
            catch (Exception)
            {
                ViewData["Teachers"] = new SelectList(await _teacherService.GetTeacherListItemsAsync(), "Id", "FullName");
                ModelState.AddModelError("CustomError", "Something went wrong!");
                return View(dto);
            }
        }

        public async Task<IActionResult> Update(int id)
        {
            try
            {
                ViewData["Teachers"] = new SelectList(await _teacherService.GetTeacherListItemsAsync(), "Id", "FullName");
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
        public async Task<IActionResult> Update(CourseUpdateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Teachers"] = new SelectList(await _teacherService.GetTeacherListItemsAsync(), "Id", "FullName");
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
                ViewData["Teachers"] = new SelectList(await _teacherService.GetTeacherListItemsAsync(), "Id", "FullName");
                ModelState.AddModelError("CustomError", ex.Message);
                return View(dto);
            }
            catch (Exception)
            {
                ViewData["Teachers"] = new SelectList(await _teacherService.GetTeacherListItemsAsync(), "Id", "FullName");
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
            
            
                var course = await _service.GetCourseDetailsAsync(id);
                return View(course); 
            
            
        }

    }
}
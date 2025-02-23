using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.DTOs.AttendanceDTOs;
using Project.Models;
using Project.Repository.Abstraction;
using Project.Services.Abstractions;
using Project.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AttendanceController : Controller
    {
        private readonly IAttendanceService _attendanceService;
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public AttendanceController(
            IAttendanceService attendanceService,
            ICourseService courseService,
            IMapper mapper)
        {
            _attendanceService = attendanceService;
            _courseService = courseService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var attendances = await _attendanceService.GetAttendanceListItemsAsync();
            return View(attendances);
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                var availableCourses = await _courseService.GetAvailableCoursesAsync();
                ViewData["Courses"] = new SelectList(availableCourses, "Id", "Name");

                return View();
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }

        public async Task<IActionResult> CreateAttendance(int courseId)
        {
            if (courseId <= 0)
            {
                ModelState.AddModelError("CourseId", "Select a valid course!");
                var courses = await _courseService.GetCourseListItemsAsync();
                ViewData["Courses"] = new SelectList(courses, "Id", "Name");
                return View("Create");
            }

            var course = await _courseService.GetByIdWithOtherAsync(courseId);
            if (course == null)
            {
                ModelState.AddModelError("CourseId", "Course not found!");
                var courses = await _courseService.GetCourseListItemsAsync();
                ViewData["Courses"] = new SelectList(courses, "Id", "Name");
                return View("Create");
            }

            var dto = new AttendanceCreateDTO
            {
                CourseId = courseId,
                Students = course.Students.Select(s => new AttendanceRecordDTO
                {
                    StudentId = s.Id,
                    StudentName = s.FullName,
                    Status = true 
                }).ToList()
            };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAttendance(AttendanceCreateDTO dto)
        {
           



            try
            {
                await _attendanceService.CreateAsync(dto);
                await _attendanceService.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (BaseException ex)
            {
                ModelState.AddModelError("CustomError", ex.Message);
                return View(dto);
            }
            catch (Exception)
            {
                ModelState.AddModelError("CustomError", "Something went wrong!");
                return View(dto);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var attendance = await _attendanceService.GetByIdWithOtherAsync(id);
                if (attendance == null)
                {
                    return NotFound("Attendance not found!");
                }

                var dto = _mapper.Map<AttendanceViewDTO>(attendance);
                return View(dto);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Details action:");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                return BadRequest($"Something went wrong: {ex.Message}");
            }
        }

        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var dto = await _attendanceService.GetByIdForUpdateAsync(id);
                return View(dto);
            }
            catch (BaseException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong: {ex.Message}");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AttendanceUpdateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            try
            {
                await _attendanceService.UpdateAsync(dto);
                await _attendanceService.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (BaseException ex)
            {
                Console.WriteLine("Error in Update (POST):");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                ModelState.AddModelError("CustomError", ex.Message);
                return View(dto);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Update (POST):");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                ModelState.AddModelError("CustomError", "Something went wrong!");
                return View(dto);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _attendanceService.DeleteAsync(id);
                await _attendanceService.SaveChangesAsync();
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
    }
}
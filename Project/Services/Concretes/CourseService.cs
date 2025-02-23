using AutoMapper;
using Project.DTOs.CourseDTOs;
using Project.DTOs.CourseDTOs.Project.DTOs.CourseDTOs;
using Project.Models;
using Project.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using Project.Services.Abstractions;
using Project.Utilities;

namespace Project.Services.Concretes
{
    public class CourseService : ICourseService
    {
        readonly IRepository<Course> _repository;
        readonly IRepository<Teacher> _teacherRepository;
        readonly IMapper _mapper;


        public CourseService(IRepository<Course> repository, IMapper mapper, IRepository<Teacher> teacherRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _teacherRepository = teacherRepository;
        }

        public async Task<Course> GetByIdAsync(int id) => await _repository.GetByIdAsync(id) ?? throw new BaseException();

        public async Task<Course> GetByIdWithOtherAsync(int id)
        {
            return await _repository.GetByIdAsync(
                id,
                c => c.Students,
                c => c.Teacher,
                c => c.Attendances

            ) ?? throw new BaseException();
        }


        public async Task<CourseUpdateDTO> GetByIdForUpdateAsync(int id) => _mapper.Map<CourseUpdateDTO>(await GetByIdAsync(id));

        public async Task<ICollection<CourseListItemDTO>> GetCourseListItemsAsync()
        {
            var courses = await _repository.GetAllAsync(c=>c.Teacher);
            return _mapper.Map<ICollection<CourseListItemDTO>>(courses);
        }

        public async Task<ICollection<CourseViewItemDTO>> GetCourseViewItemsAsync()
        {
            var courses = await _repository.GetAllAsync(c => c.Students, c=>c.Teacher);
            return _mapper.Map<ICollection<CourseViewItemDTO>>(courses);
        }

        public async Task CreateAsync(CourseCreateDTO dto)
        {
            if (await _teacherRepository.GetByIdAsync(dto.TeacherId) is null) throw new BaseException("Teacher not found!");
            Course course = _mapper.Map<Course>(dto);
            course.ImageUrl = await dto.Image.SaveAsync("courses");
            course.CreatedAt = DateTime.Now;

            await _repository.CreateAsync(course);
        }

        public async Task UpdateAsync(CourseUpdateDTO dto)
        {
            if (await _teacherRepository.GetByIdAsync(dto.TeacherId) is null) throw new BaseException("Teacher not found!");
            Course oldCourse = await GetByIdAsync(dto.Id);
            Course course = _mapper.Map<Course>(dto);
            course.CreatedAt = oldCourse.CreatedAt;
            course.UpdatedAt = DateTime.Now;
            course.ImageUrl = dto.Image is not null ? await dto.Image.SaveAsync("courses") : oldCourse.ImageUrl;

            _repository.Update(course);
            if (dto.Image is not null) File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "courses", oldCourse.ImageUrl));
        }
        public async Task<ICollection<CourseListItemDTO>> GetAvailableCoursesAsync()
        {
            var courses = await _repository.GetAllAsync(c => c.Attendances);
            var availableCourses = courses.Where(c => c.Attendances.Count < c.LessonCount).ToList();

            return _mapper.Map<ICollection<CourseListItemDTO>>(availableCourses);
        }

        public async Task DeleteAsync(int id)
        {
            Course course = await GetByIdWithOtherAsync(id);

            if (course.Students.Count != 0) throw new BaseException("This Course has Students!");

            _repository.Delete(course);
            File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "courses", course.ImageUrl));
        }

        public async Task<Course> GetCourseDetailsAsync(int id)
        {
            return await _repository.GetByIdForDetailsAsync(
                id,
                query => query.Include(c => c.Students),
                query => query.Include(c => c.Teacher),
                query => query.Include(c => c.Attendances)
                    .ThenInclude(a => a.AttendanceRecords) 
            ) ?? throw new BaseException("Course not found!");
        }




        public async Task<int> SaveChangesAsync() => await _repository.SaveChangesAsync();
    }
}
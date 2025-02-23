using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.DTOs.StudentDTOs;
using Project.Models;
using Project.Repository.Abstraction;
using Project.Services.Abstractions;
using Project.Utilities;

namespace Project.Services.Concretes
{
    public class StudentService : IStudentService
    {
        readonly IRepository<Student> _repository;
        readonly IRepository<Course> _courseRepository;
        readonly IMapper _mapper;

        public StudentService(IRepository<Student> repository, IMapper mapper, IRepository<Teacher> teacherRepository, IRepository<Course> courseRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        public async Task<Student> GetByIdAsync(int id) => await _repository.GetByIdAsync(id, s => s.Course,s =>s.Course.Teacher) ?? throw new BaseException();

        public async Task<StudentUpdateDTO> GetByIdForUpdateAsync(int id) => _mapper.Map<StudentUpdateDTO>(await GetByIdAsync(id));

        public async Task<ICollection<StudentListItemDTO>> GetStudentListItemsAsync()
        {
            var students = await _repository.GetAllAsync(s => s.Course,s => s.Course.Teacher);
            return _mapper.Map<ICollection<StudentListItemDTO>>(students);
        }

        public async Task<ICollection<StudentViewItemDTO>> GetStudentViewItemsAsync()
        {
            var students = await _repository.GetAllAsync(s => s.Course,c=>c.Course.Teacher);
            return _mapper.Map<ICollection<StudentViewItemDTO>>(students);
        }

        public async Task CreateAsync(StudentCreateDTO dto)
        {
            if (await _courseRepository.GetByIdAsync(dto.CourseId) is null) throw new BaseException("Course not found!");

            Student student = _mapper.Map<Student>(dto);
            student.ImageURL = await dto.Image.SaveAsync("students");
            student.CreatedAt = DateTime.Now;

            await _repository.CreateAsync(student);
        }

        public async Task UpdateAsync(StudentUpdateDTO dto)
        {
            if (await _courseRepository.GetByIdAsync(dto.CourseId) is null) throw new BaseException("Course not found!");

            Student oldStudent = await GetByIdAsync(dto.Id);
            Student student = _mapper.Map<Student>(dto);
            student.CreatedAt = oldStudent.CreatedAt;
            student.UpdatedAt = DateTime.Now;
            student.ImageURL = dto.Image is not null ? await dto.Image.SaveAsync("students") : oldStudent.ImageURL;

            _repository.Update(student);

            if (dto.Image is not null) File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "students", oldStudent.ImageURL));
        }

        public async Task DeleteAsync(int id)
        {
            Student student = await GetByIdAsync(id);

            _repository.Delete(student);

            File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "students", student.ImageURL));
        }

        public async Task<Student> GetStudentDetailsAsync(int id)
        {
            return await _repository.GetByIdForDetailsAsync(
                id,
                query => query.Include(s => s.Course)
                              .ThenInclude(c => c.Teacher),
                query => query.Include(s => s.AttendanceRecords)
                              .ThenInclude(ar => ar.Attendance)
                              .ThenInclude(a => a.Course)
            ) ?? throw new BaseException("Student not found!");
        }

        public async Task<int> SaveChangesAsync() => await _repository.SaveChangesAsync();
    }

}

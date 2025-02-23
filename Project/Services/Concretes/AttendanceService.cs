using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.Contexts;
using Project.DTOs.AttendanceDTOs;
using Project.DTOs.CourseDTOs;
using Project.Models;
using Project.Repository.Abstraction;
using Project.Services.Abstractions;
using Project.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Services.Concretes
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IRepository<Attendance> _repository;
        private readonly IRepository<Course> _courseRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public AttendanceService(
            IRepository<Attendance> repository,
            IRepository<Course> courseRepository,
            IMapper mapper,
            AppDbContext context)
        {
            _repository = repository;
            _courseRepository = courseRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<Attendance> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id) ?? throw new BaseException("Attendance not found!");
        }

        public async Task<Attendance> GetByIdWithOtherAsync(int id)
        {
            var attendance = await _repository.GetByIdAsync(id,
                a => a.Course,
                a => a.AttendanceRecords);   

            if (attendance == null)
            {
                throw new BaseException("Attendance not found!");
            }

            foreach (var record in attendance.AttendanceRecords)
            {
                await _context.Entry(record).Reference(ar => ar.Student).LoadAsync();
            }

            return attendance;
        }

        public async Task<AttendanceCreateDTO> GetByIdForCreateAsync(int courseId)
        {
            var course = await _courseRepository.GetByIdAsync(courseId, c => c.Students);
            if (course == null)
            {
                throw new BaseException("Course not found!");
            }

            var dto = new AttendanceCreateDTO
            {
                CourseId = courseId,
                Students = course.Students.Select(s => new AttendanceRecordDTO
                {
                    StudentId = s.Id,
                    Status = false   
                }).ToList()
            };

            return dto;
        }

        public async Task<AttendanceUpdateDTO> GetByIdForUpdateAsync(int id)
        {
            try
            {
                var attendance = await GetByIdWithOtherAsync(id);
                if (attendance == null)
                {
                    throw new BaseException("Attendance not found!");
                }

                return _mapper.Map<AttendanceUpdateDTO>(attendance);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetByIdForUpdateAsync:");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                throw new BaseException("Something went wrong while fetching attendance for update!");
            }
        }

        public async Task<ICollection<AttendanceListItemDTO>> GetAttendanceListItemsAsync()
        {
            var attendances = await _repository.GetAllAsync(a => a.Course, a => a.AttendanceRecords);
            return _mapper.Map<ICollection<AttendanceListItemDTO>>(attendances);
        }

        public async Task CreateAsync(AttendanceCreateDTO dto)
        {
            var course = await _courseRepository.GetByIdAsync(dto.CourseId, c => c.Attendances, c => c.Students);
            if (course == null)
            {
                throw new BaseException("Course not found!");
            }

            int nextLessonNumber = 1;
            if (course.Attendances != null && course.Attendances.Any())
            {
                nextLessonNumber = course.Attendances.Max(a => a.LessonNumber) + 1;
            }

            if (nextLessonNumber > course.LessonCount)
            {
                throw new BaseException("All lessons for this course have already been attended!");
            }

            var attendance = _mapper.Map<Attendance>(dto);
            attendance.LessonNumber = nextLessonNumber;
            attendance.Date = DateTime.Now;
            attendance.AttendanceRecords = dto.Students.Select(s => new AttendanceRecord
            {
                StudentId = s.StudentId,
                IsPresent = s.Status
            }).ToList();

            await _repository.CreateAsync(attendance);
        }



        public async Task UpdateAsync(AttendanceUpdateDTO dto)
        {
            try
            {
                var attendance = await GetByIdWithOtherAsync(dto.Id);

                foreach (var record in attendance.AttendanceRecords.ToList())
                {
                    _context.AttendanceRecords.Remove(record);
                }

                attendance.AttendanceRecords = dto.Students.Select(s => new AttendanceRecord
                {
                    StudentId = s.StudentId,
                    IsPresent = s.Status
                }).ToList();

                _repository.Update(attendance);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UpdateAsync:");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                throw new BaseException("Something went wrong while updating the attendance!");
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var attendance = await GetByIdWithOtherAsync(id);

                foreach (var record in attendance.AttendanceRecords.ToList())
                {
                    _context.AttendanceRecords.Remove(record);
                }

                _repository.Delete(attendance);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in DeleteAsync:");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                throw new BaseException("Something went wrong while deleting the attendance!");
            }
        }


        

        public async Task<int> SaveChangesAsync() => await _repository.SaveChangesAsync();
    }
}
using AutoMapper;
using Project.DTOs.TeacherDTOs;
using Project.Models;
using Project.Repository.Abstraction;
using Project.Services.Abstractions;
using Project.Utilities;

namespace Project.Services.Concretes
{
    public class TeacherService : ITeacherService
    {
        readonly IRepository<Teacher> _repository;
        readonly IMapper _mapper;

        public TeacherService(IRepository<Teacher> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Teacher> GetByIdAsync(int id) => await _repository.GetByIdAsync(id) ?? throw new BaseException();

        public async Task<Teacher> GetByIdWithOtherAsync(int id) => await _repository.GetByIdAsync(id, t => t.Courses) ?? throw new BaseException();

        public async Task<TeacherUpdateDTO> GetByIdForUpdateAsync(int id) => _mapper.Map<TeacherUpdateDTO>(await GetByIdAsync(id));

        public async Task<ICollection<TeacherListItemDTO>> GetTeacherListItemsAsync()
        {
            var teachers = await _repository.GetAllAsync();
            return _mapper.Map<ICollection<TeacherListItemDTO>>(teachers);
        }

        public async Task<ICollection<TeacherViewItemDTO>> GetTeacherViewItemsAsync()
        {
            var teachers = await _repository.GetAllAsync(t => t.Courses);
            return _mapper.Map<ICollection<TeacherViewItemDTO>>(teachers);
        }

        public async Task CreateAsync(TeacherCreateDTO dto)
        {
            Teacher teacher = _mapper.Map<Teacher>(dto);
            teacher.ImageURL = await dto.Image.SaveAsync("teachers");
            teacher.CreatedAt = DateTime.Now;

            await _repository.CreateAsync(teacher);
        }

        public async Task UpdateAsync(TeacherUpdateDTO dto)
        {
            Teacher oldTeacher = await GetByIdAsync(dto.Id);
            Teacher teacher = _mapper.Map<Teacher>(dto);
            teacher.CreatedAt = oldTeacher.CreatedAt;
            teacher.UpdatedAt = DateTime.Now;
            teacher.ImageURL = dto.Image is not null ? await dto.Image.SaveAsync("teachers") : oldTeacher.ImageURL;

            _repository.Update(teacher);

            if (dto.Image is not null) File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "teachers", oldTeacher.ImageURL));
        }

        public async Task DeleteAsync(int id)
        {
            Teacher teacher = await GetByIdWithOtherAsync(id);

            if (teacher.Courses.Count != 0) throw new BaseException("This Teacher has Students!");

            _repository.Delete(teacher);
        }

        public async Task<int> SaveChangesAsync() => await _repository.SaveChangesAsync();
    }

}

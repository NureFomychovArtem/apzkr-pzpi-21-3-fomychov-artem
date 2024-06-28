using BLL.DTO;

namespace BLL.Service.Interfaces
{
    public interface ITeacherService
    {
        Task<TeacherDTO> GetTeacherByClassIdAsync(int id);
        Task<TeacherDTO> GetByIdAsync(int id);
        Task<IEnumerable<TeacherDTO>> GetAllAsync();
        Task<IEnumerable<TeacherDTO>> GetAllByYearAsync(int year);
        Task<TeacherDTO> CreateAsync(CreateTeacherDTO data);
        Task UpdateAsync(int id, UpdateTeacherDTO data);
        Task DeleteAsync(int id);
    }
}
using BLL.DTO;

namespace BLL.Service.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<UserDTO>> GetStudentsByClassIdAsync(int id);
        Task<StudentDTO> GetByIdAsync(int id);
        Task<IEnumerable<StudentDTO>> GetAllAsync();
        Task<IEnumerable<StudentDTO>> GetAllByYearAsync(int year);
        Task<StudentDTO> CreateAsync(CreateStudentDTO data);
        Task UpdateAsync(int id, UpdateStudentDTO data);
        Task DeleteAsync(int id);
    }
}
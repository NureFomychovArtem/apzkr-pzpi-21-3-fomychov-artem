using BLL.DTO;

namespace BLL.Service.Interfaces
{
    public interface IClassService
    {
        Task<IEnumerable<ClassDTO>> GetAllAsync();
        Task<ClassDTO> GetClassByStudentIdAsync(int id);
        Task<ClassDTO> GetByIdAsync(int id);
        Task<ClassDTO> CreateAsync(CreateClassDTO data);
        Task UpdateAsync(int id, UpdateClassDTO data);
        Task DeleteAsync(int id);
    }
}
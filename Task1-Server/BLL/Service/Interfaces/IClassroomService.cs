using BLL.DTO;

namespace BLL.Service.Interfaces
{
    public interface IClassroomService
    {
        Task<IEnumerable<ClassroomDTO>> GetAllAsync();
        Task<ClassroomDTO> GetByIdAsync(int id);
        Task<ClassroomDTO> CreateAsync(CreateClassroomDTO data);
        Task UpdateAsync(int id, UpdateClassroomDTO data);
        Task DeleteAsync(int id);
    }
}
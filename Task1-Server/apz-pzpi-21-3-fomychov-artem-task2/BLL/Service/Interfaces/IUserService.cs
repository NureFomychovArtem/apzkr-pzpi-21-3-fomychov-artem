using BLL.DTO;

namespace BLL.Service.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<UserDTO> GetByIdAsync(int id);
        Task<UserDTO> CreateAsync(CreateUserDTO data);
        Task UpdateAsync(int id, UpdateUserDTO data);
        Task DeleteAsync(int id);
    }
}
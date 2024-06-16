using BLL.DTO;

namespace BLL.Service.Interfaces
{
    public interface IRequestService
    {
        Task<IEnumerable<RequestDTO>> GetAllAsync();
        Task<RequestDTO> GetByIdAsync(int id);
        Task<RequestDTO> CreateAsync(CreateRequestDTO data);
        Task UpdateAsync(int id, UpdateRequestDTO data);
        Task DeleteAsync(int id);
    }
}
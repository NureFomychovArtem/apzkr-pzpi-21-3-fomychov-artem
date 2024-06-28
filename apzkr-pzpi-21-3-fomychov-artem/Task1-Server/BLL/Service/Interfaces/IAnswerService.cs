using BLL.DTO;

namespace BLL.Service.Interfaces
{
    public interface IAnswerService
    {
        Task<IEnumerable<AnswerDTO>> GetAllAsync();
        Task<AnswerDTO> GetByIdAsync(int id);
        Task<AnswerDTO> CreateAsync(CreateAnswerDTO data);
        Task UpdateAsync(int id, UpdateAnswerDTO data);
        Task DeleteAsync(int id);
    }
}
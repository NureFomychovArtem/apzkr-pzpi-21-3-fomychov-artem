using BLL.DTO;

namespace BLL.Service.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDTO>> GetAllAsync();
        Task<AccountDTO> GetByIdAsync(int id);
        Task<AccountDTO> LoginAsync(LoginAccountDTO data);
        Task<AccountDTO> CreateAsync(CreateAccountDTO data);
        Task UpdateAsync(int id, UpdateAccountDTO data);
        Task DeleteAsync(int id);
    }
}
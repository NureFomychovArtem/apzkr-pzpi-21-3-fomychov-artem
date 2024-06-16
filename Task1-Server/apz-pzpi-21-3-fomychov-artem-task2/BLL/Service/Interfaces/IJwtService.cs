using DAL.Entities;

namespace BLL.Service.Interfaces
{
    public interface IJwtService
    {
        string CreateToken(Account data);
    }
}
using BLL.Mappings;

namespace BLL.DTO
{
    public class AccountDTO : IMapFrom<DAL.Entities.Account>
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }
        public UserDTO User { get; set; }
    }
}
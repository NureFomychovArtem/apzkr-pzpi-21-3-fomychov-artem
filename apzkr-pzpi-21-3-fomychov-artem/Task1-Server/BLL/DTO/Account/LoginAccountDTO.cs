using BLL.Mappings;

namespace BLL.DTO

{
    public class LoginAccountDTO : IMapFrom<DAL.Entities.Account>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
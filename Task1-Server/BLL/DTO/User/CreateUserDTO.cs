using BLL.Mappings;

namespace BLL.DTO
{
    public class CreateUserDTO : IMapTo<DAL.Entities.User>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Fingerprint { get; set; }
        public CreateAccountDTO Account { get; set; }
    }
}
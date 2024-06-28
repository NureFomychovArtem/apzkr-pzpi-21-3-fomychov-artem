using AutoMapper;
using BLL.Mappings;
using DAL.Entities;

namespace BLL.DTO
{
    public class UserDTO : IMapFrom<DAL.Entities.User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public RoleName RoleName { get; set; }
        public RoleDTO Role { get; set; }

        public void MapFrom(Profile profile)
        {
            profile.CreateMap<DAL.Entities.User, UserDTO>()
                .ForMember(dest => dest.Role, src => src.MapFrom(otp => otp.Role));
        }
    }
}
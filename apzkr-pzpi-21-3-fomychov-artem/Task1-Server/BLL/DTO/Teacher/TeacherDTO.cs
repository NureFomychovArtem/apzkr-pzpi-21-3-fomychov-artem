using AutoMapper;
using BLL.Mappings;

namespace BLL.DTO
{
    public class TeacherDTO : IMapFrom<DAL.Entities.Teacher>
    {
        public int Id { get; set; }
        public UserDTO User { get; set; }
        public ClassDTO Class { get; set; }


        public void MapFrom(Profile profile)
        {
            profile.CreateMap<DAL.Entities.Teacher, TeacherDTO>()
                .ForMember(dest => dest.User, src => src.MapFrom(otp => otp.User))
                .ForMember(dest => dest.Class, src => src.MapFrom(otp => otp.Class));
        }
    }
}
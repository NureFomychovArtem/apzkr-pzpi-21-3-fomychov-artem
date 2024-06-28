using AutoMapper;
using BLL.Mappings;

namespace BLL.DTO
{
    public class ClassDTO : IMapFrom<DAL.Entities.Class>
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public int StartYear { get; set; }
        public SchoolDTO School { get; set; }
        public IEnumerable<UserDTO>? Students { get; set; }

        public void MapFrom(Profile profile)
        {
            profile.CreateMap<DAL.Entities.Class, ClassDTO>()
                .ForMember(dest => dest.School, src => src.MapFrom(otp => otp.School));
        }
    }
}
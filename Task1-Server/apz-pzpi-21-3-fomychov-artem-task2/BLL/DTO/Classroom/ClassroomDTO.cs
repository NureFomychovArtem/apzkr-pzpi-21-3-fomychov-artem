using AutoMapper;
using BLL.Mappings;

namespace BLL.DTO
{
    public class ClassroomDTO : IMapFrom<DAL.Entities.Classroom>
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public SchoolDTO School { get; set; }

        public void MapFrom(Profile profile)
        {
            profile.CreateMap<DAL.Entities.Classroom, ClassroomDTO>()
                .ForMember(dest => dest.School, src => src.MapFrom(otp => otp.School));
        }
    }
}
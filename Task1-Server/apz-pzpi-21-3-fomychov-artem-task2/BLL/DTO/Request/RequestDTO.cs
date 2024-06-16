using AutoMapper;
using BLL.Mappings;

namespace BLL.DTO
{
    public class RequestDTO : IMapFrom<DAL.Entities.Request>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public UserDTO Author { get; set; }
        public ClassroomDTO Classroom { get; set; }
        public DateTime Date { get; set; }

        public void MapFrom(Profile profile)
        {
            profile.CreateMap<DAL.Entities.Request, RequestDTO>()
                .ForMember(dest => dest.Author, src => src.MapFrom(otp => otp.Author))
                .ForMember(dest => dest.Classroom, src => src.MapFrom(otp => otp.Classroom));
        }
    }
}
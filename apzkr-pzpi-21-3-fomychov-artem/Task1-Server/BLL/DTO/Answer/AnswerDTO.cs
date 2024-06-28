using AutoMapper;
using BLL.Mappings;
using static DAL.Entities.Answer;

namespace BLL.DTO
{
    public class AnswerDTO : IMapFrom<DAL.Entities.Answer>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public AnswerStatus Status { get; set; }
        public UserDTO Author { get; set; }
        public RequestDTO Request { get; set; }

        public void MapFrom(Profile profile)
        {
            profile.CreateMap<DAL.Entities.Answer, AnswerDTO>()
                .ForMember(dest => dest.Author, src => src.MapFrom(otp => otp.Author))
                .ForMember(dest => dest.Request, src => src.MapFrom(otp => otp.Request));
        }
    }
}
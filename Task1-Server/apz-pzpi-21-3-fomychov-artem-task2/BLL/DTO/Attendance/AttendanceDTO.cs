using AutoMapper;
using BLL.Mappings;

namespace BLL.DTO
{
    public class AttendanceDTO : IMapFrom<DAL.Entities.Attendance>
    {
        public int Id { get; set; }
        public UserDTO User { get; set; }
        public DateTime Time { get; set; }
        public float Temperature { get; set; }

        public void MapFrom(Profile profile)
        {
            profile.CreateMap<DAL.Entities.Attendance, AttendanceDTO>()
                .ForMember(dest => dest.User, src => src.MapFrom(otp => otp.User));
        }
    }
}
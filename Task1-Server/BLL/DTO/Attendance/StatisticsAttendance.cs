using AutoMapper;

namespace BLL.DTO
{
    public class StatisticsAttendance
    {
        public UserDTO User { get; set; }
        public float TemperatureAverage { get; set; }
        public float TemperatureMax { get; set; }
        public float TemperatureMin { get; set; }
        public DateTime TimeAverage { get; set; }
        public DateTime TimeMax { get; set; }
        public DateTime TimeMin { get; set; }
    }
}
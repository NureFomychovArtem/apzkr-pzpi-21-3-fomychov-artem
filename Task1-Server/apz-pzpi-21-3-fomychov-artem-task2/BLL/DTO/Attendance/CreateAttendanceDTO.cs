namespace BLL.DTO
{
    public class CreateAttendanceDTO
    {
        public string Fingerprint { get; set; }
        public DateTime Time { get; set; }
        public float Temperature { get; set; }
    }
}
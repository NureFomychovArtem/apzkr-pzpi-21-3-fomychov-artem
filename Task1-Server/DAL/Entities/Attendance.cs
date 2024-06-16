namespace DAL.Entities
{
    public class Attendance
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime Time { get; set; }
        public float Temperature { get; set; }
    }
}
namespace DAL.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
        public int StudyYeart { get; set; }
    }
}
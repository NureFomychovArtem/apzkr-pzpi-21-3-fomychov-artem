namespace DAL.Entities
{
    public class Classroom
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
    }
}
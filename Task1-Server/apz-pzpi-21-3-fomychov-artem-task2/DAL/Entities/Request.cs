namespace DAL.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
        public DateTime Date { get; set; }
    }
}
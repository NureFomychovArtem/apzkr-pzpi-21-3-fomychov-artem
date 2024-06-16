namespace DAL.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public int StartYear { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
    }
}
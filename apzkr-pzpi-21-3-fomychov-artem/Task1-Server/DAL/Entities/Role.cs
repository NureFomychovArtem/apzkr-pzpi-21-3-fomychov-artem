namespace DAL.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public RoleName Name { get; set; }
        public bool EditStudent { get; set; }
        public bool EditTeacher { get; set; }
        public bool EditSchool { get; set; }
        public bool VisitMark { get; set; }
        public bool ChangingRoles { get; set; }
    }

    public enum RoleName
    {
        Student,
        Director,
        Teacher,
        Security,
        Worker
    }
}
namespace DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fingerprint { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
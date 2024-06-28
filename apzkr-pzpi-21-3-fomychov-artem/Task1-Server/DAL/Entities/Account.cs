using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Account
    {
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
    }
}
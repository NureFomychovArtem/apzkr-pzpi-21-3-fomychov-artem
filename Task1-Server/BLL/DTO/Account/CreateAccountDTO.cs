using BLL.Mappings;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    public class CreateAccountDTO : IMapTo<DAL.Entities.Account>
    {
        [Required(ErrorMessage = "Login is required")]
        [MinLength(5, ErrorMessage = "Login must be at least 5 characters long")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }
    }
}
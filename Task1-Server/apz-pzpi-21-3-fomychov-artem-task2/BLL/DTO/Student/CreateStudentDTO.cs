using BLL.Mappings;

namespace BLL.DTO
{
    public class CreateStudentDTO : IMapTo<DAL.Entities.Student>
    {
        public int UserId { get; set; }
        public int ClassId { get; set; }
    }
}
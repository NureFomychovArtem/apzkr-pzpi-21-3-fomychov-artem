using BLL.Mappings;

namespace BLL.DTO
{
    public class CreateTeacherDTO : IMapTo<DAL.Entities.Teacher>
    {
        public int UserId { get; set; }
        public int ClassId { get; set; }
        public int ClassroomId { get; set; }
    }
}
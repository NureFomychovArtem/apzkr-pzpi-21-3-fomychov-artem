using BLL.Mappings;

namespace BLL.DTO
{
    public class CreateClassroomDTO : IMapTo<DAL.Entities.Classroom>
    {
        public int Number { get; set; }
        public int SchoolId { get; set; }
    }
}
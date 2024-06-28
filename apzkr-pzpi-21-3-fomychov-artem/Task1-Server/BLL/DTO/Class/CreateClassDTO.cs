using BLL.Mappings;

namespace BLL.DTO
{
    public class CreateClassDTO : IMapTo<DAL.Entities.Class>
    {
        public string ClassName { get; set; }
        public int StartYear { get; set; }
        public int SchoolId { get; set; }
    }
}
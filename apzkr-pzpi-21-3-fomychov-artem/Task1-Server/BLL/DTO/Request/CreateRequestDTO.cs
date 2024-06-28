using BLL.Mappings;

namespace BLL.DTO
{
    public class CreateRequestDTO : IMapTo<DAL.Entities.Request>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public int ClassroomId { get; set; }
    }
}
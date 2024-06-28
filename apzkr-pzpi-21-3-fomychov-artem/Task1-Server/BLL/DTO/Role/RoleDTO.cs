using BLL.Mappings;
using DAL.Entities;

namespace BLL.DTO
{
    public class RoleDTO : IMapFrom<DAL.Entities.Role>
    {
        public int Id { get; set; }
        public RoleName Name { get; set; }
        public bool EditStudent { get; set; }
        public bool EditTeacher { get; set; }
        public bool EditSchool { get; set; }
        public bool VisitMark { get; set; }
        public bool ChangingRoles { get; set; }
    }
}
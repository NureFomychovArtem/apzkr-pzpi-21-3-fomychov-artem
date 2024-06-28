using BLL.Mappings;
using static DAL.Entities.Answer;

namespace BLL.DTO
{
    public class CreateAnswerDTO : IMapTo<DAL.Entities.Answer>
    {
        public string Description { get; set; }
        public AnswerStatus Status { get; set; }
        public int AuthorId { get; set; }
        public int RequestId { get; set; }
    }
}
using static DAL.Entities.Answer;

namespace BLL.DTO
{
    public class UpdateAnswerDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public AnswerStatus Status { get; set; }
    }
}
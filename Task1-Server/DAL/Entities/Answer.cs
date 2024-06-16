namespace DAL.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public AnswerStatus Status { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public int RequestId { get; set; }
        public Request Request { get; set; }
        public DateTime Date { get; set; }

        public enum AnswerStatus
        {
            Approved,
            Refused
        }
    }
}
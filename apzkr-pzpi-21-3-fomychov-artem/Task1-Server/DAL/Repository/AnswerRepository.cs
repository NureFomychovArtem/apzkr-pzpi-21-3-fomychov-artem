using DAL.Data;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace DAL.Repository
{
    public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(DBContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Answer>> GetAllAsync()
        {
            var answers = await base.GetAllAsync();

            foreach (var answer in answers)
            {
                await LoadRelatedDataAsync(answer, x => x.Author);
                await LoadRelatedDataAsync(answer, x => x.Request);
                await LoadRelatedDataAsync(answer.Request, x => x.Classroom);
                await LoadRelatedDataAsync(answer.Request.Classroom, x => x.School);
                await LoadRelatedDataAsync(answer.Author, x => x.Role);

            }

            return answers;
        }

        public async Task<Answer> GetByIdAsync(int id)
        {
            var answer = await base.GetByIdAsync(id)
                ?? throw new Exception("Answer was not found");//Об'єкт не знайдено

            await LoadRelatedDataAsync(answer, x => x.Author);
            await LoadRelatedDataAsync(answer, x => x.Request);
            await LoadRelatedDataAsync(answer.Request, x => x.Classroom);
            await LoadRelatedDataAsync(answer.Request.Classroom, x => x.School);
            await LoadRelatedDataAsync(answer.Author, x => x.Role);

            return answer;
        }
    }
}
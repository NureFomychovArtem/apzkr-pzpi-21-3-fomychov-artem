using DAL.Data;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace DAL.Repository
{
    public class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        public RequestRepository(DBContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Request>> GetAllAsync()
        {
            var requests = await base.GetAllAsync();

            foreach (var request in requests)
            {
                await LoadRelatedDataAsync(request, x => x.Author);
                await LoadRelatedDataAsync(request, x => x.Classroom);
                await LoadRelatedDataAsync(request.Classroom, x => x.School);
                await LoadRelatedDataAsync(request.Author, x => x.Role);
            }

            return requests;
        }

        public async Task<Request> GetByIdAsync(int id)
        {
            var request = await base.GetByIdAsync(id)
                ?? throw new Exception("Request was not found");//Об'єкт не знайдено

            await LoadRelatedDataAsync(request, x => x.Author);
            await LoadRelatedDataAsync(request, x => x.Classroom);
            await LoadRelatedDataAsync(request.Classroom, x => x.School);
            await LoadRelatedDataAsync(request.Author, x => x.Role);

            return request;
        }
    }
}
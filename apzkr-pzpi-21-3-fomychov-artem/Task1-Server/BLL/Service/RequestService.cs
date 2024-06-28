using AutoMapper;
using BLL.DTO;
using BLL.Service.Interfaces;
using DAL.Data;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace BLL.Service
{
    public class RequestService : IRequestService
    {
        private readonly DBContext _dbContext;
        private readonly IRequestRepository _requestRepository;
        private readonly IUserRepository _userRepository;
        private readonly IClassroomRepository _classroomRepository;

        private readonly IMapper _mapper;
        public RequestService(
            DBContext dbContext,
            IRequestRepository requestRepository,
            IUserRepository userRepository,
            IClassroomRepository classroomRepository,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _requestRepository = requestRepository;
            _userRepository = userRepository;
            _classroomRepository = classroomRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Отримати список запитів
        /// </summary>
        public async Task<IEnumerable<RequestDTO>> GetAllAsync()
        {
            var requests = await _requestRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RequestDTO>>(requests);
        }

        /// <summary>
        /// Отримати запит за його ID
        /// </summary>
        public async Task<RequestDTO> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Incorrect Id");
            }

            var request = await _requestRepository.GetByIdAsync(id)
                ?? throw new Exception("Object was not found");

            return _mapper.Map<RequestDTO>(request);
        }

        /// <summary>
        /// Створити новий запит
        /// </summary>
        public async Task<RequestDTO> CreateAsync(CreateRequestDTO data)
        {
            var author = await _userRepository.GetByIdAsync(data.AuthorId)
                ?? throw new Exception("Author was not found");
            var classroom = await _classroomRepository.GetByIdAsync(data.ClassroomId)
                ?? throw new Exception("Classroom was not found");

            var request = _mapper.Map<Request>(data);
            request.Date = DateTime.Now;

            await _requestRepository.CreateAsync(request);
            request.Author = author;
            request.Classroom = classroom;

            var result = _mapper.Map<RequestDTO>(request);

            return result;
        }

        /// <summary>
        /// Оновити запит
        /// </summary>
        public async Task UpdateAsync(int id, UpdateRequestDTO data)
        {
            if (id <= 0 || id != data.Id)
            {
                throw new Exception("Incorrect Id");
            }

            var request = await _requestRepository.GetByIdAsync(id)
                ?? throw new Exception("Request was not found");

            if (!string.IsNullOrWhiteSpace(data.Title))
            {
                request.Title = data.Title;
            }
            if (!string.IsNullOrWhiteSpace(data.Description))
            {
                request.Description = data.Description;
            }

            _requestRepository.Update(request);
        }

        /// <summary>
        /// Видалити запит
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Incorrect Id");
            }

            var request = await _requestRepository.GetByIdAsync(id)
                ?? throw new Exception("Request was not found");

            _requestRepository.Delete(request);
        }
    }
}
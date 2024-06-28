using AutoMapper;
using BLL.DTO;
using BLL.Service.Interfaces;
using DAL.Data;
using DAL.Entities;
using DAL.Repository;
using DAL.Repository.Interfaces;

namespace BLL.Service
{
    public class AnswerService : IAnswerService
    {
        private readonly DBContext _dbContext;
        private readonly IAnswerRepository _answerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;
        public AnswerService(
            DBContext dbContext,
            IAnswerRepository answerRepository,
            IUserRepository userRepository,
            IRequestRepository requestRepository,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _answerRepository = answerRepository;
            _userRepository = userRepository;
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Отримати список відповідей
        /// </summary>
        public async Task<IEnumerable<AnswerDTO>> GetAllAsync()
        {
            var answers = await _answerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AnswerDTO>>(answers);
        }

        /// <summary>
        /// Отримати відповідь за його ID
        /// </summary>
        public async Task<AnswerDTO> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Incorrect Id");
            }

            var answer = await _answerRepository.GetByIdAsync(id)
                ?? throw new Exception("Object was not found");

            return _mapper.Map<AnswerDTO>(answer);
        }

        /// <summary>
        /// Створити нову відповідь
        /// </summary>
        public async Task<AnswerDTO> CreateAsync(CreateAnswerDTO data)
        {
            var author = await _userRepository.GetByIdAsync(data.AuthorId)
                ?? throw new Exception("Author was not found");
            var request = await _requestRepository.GetByIdAsync(data.RequestId)
                ?? throw new Exception("Request was not found");

            var answer = _mapper.Map<Answer>(data);
            await _answerRepository.CreateAsync(answer);

            answer.Author = author;
            answer.Request = request;

            return _mapper.Map<AnswerDTO>(answer);
        }

        /// <summary>
        /// Оновити відповідь
        /// </summary>
        public async Task UpdateAsync(int id, UpdateAnswerDTO data)
        {
            if (id <= 0 || id != data.Id)
            {
                throw new Exception("Incorrect Id");
            }

            var answer = await _answerRepository.GetByIdAsync(id)
                ?? throw new Exception("Object was not found");

            if (data.Status != null)
            {
                answer.Status = data.Status;
            }
            if (!string.IsNullOrWhiteSpace(data.Description))
            {
                answer.Description = data.Description;
            }

            _answerRepository.Update(answer);
        }

        /// <summary>
        /// Видалити відповідь
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Incorrect Id");
            }

            var answer = await _answerRepository.GetByIdAsync(id)
                ?? throw new Exception("Answer was not found");

            _answerRepository.Delete(answer);
        }
    }
}
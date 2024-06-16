using AutoMapper;
using BLL.DTO;
using BLL.Service.Interfaces;
using DAL.Data;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace BLL.Service
{
    public class ClassroomService : IClassroomService
    {
        private readonly DBContext _dbContext;
        private readonly IClassroomRepository _classroomRepository;
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper _mapper;
        public ClassroomService(
            DBContext dbContext,
            IClassroomRepository classroomRepository,
            ISchoolRepository schoolRepository,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _classroomRepository = classroomRepository;
            _schoolRepository = schoolRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Отримати список приміщень
        /// </summary>
        public async Task<IEnumerable<ClassroomDTO>> GetAllAsync()
        {
            var classrooms = await _classroomRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClassroomDTO>>(classrooms);
        }

        /// <summary>
        /// Отримати приміщення за його ID
        /// </summary>
        public async Task<ClassroomDTO> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Incorrect Id");
            }

            var classroom = await _classroomRepository.GetByIdAsync(id)
                ?? throw new Exception("Classroom was not found");

            return _mapper.Map<ClassroomDTO>(classroom);
        }

        /// <summary>
        /// Створити нову приміщення
        /// </summary>
        public async Task<ClassroomDTO> CreateAsync(CreateClassroomDTO data)
        {
            var check = await _classroomRepository.GetAllAsync();

            if (check.Where(x => x.Number == data.Number && x.SchoolId == data.SchoolId).Any())
            {
                throw new Exception("Object already exist!");
            }

            var school = await _schoolRepository.GetByIdAsync(data.SchoolId)
                ?? throw new Exception("School was not found");

            var classroom = _mapper.Map<Classroom>(data);
            await _classroomRepository.CreateAsync(classroom);

            classroom.School = school;
            return _mapper.Map<ClassroomDTO>(classroom);
        }

        /// <summary>
        /// Оновити приміщення
        /// </summary>
        public async Task UpdateAsync(int id, UpdateClassroomDTO data)
        {
            if (id <= 0 || id != data.Id)
            {
                throw new Exception("Incorrect Id");
            }

            var classroom = await _classroomRepository.GetByIdAsync(id)
                ?? throw new Exception("Object was not found");

            if (data.Number != null)
            {
                classroom.Number = data.Number;
            }

            _classroomRepository.Update(classroom);
        }

        /// <summary>
        /// Видалити приміщення
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Incorrect Id");//Неправильний id
            }

            var classroom = await _classroomRepository.GetByIdAsync(id)
                ?? throw new Exception("Object was not found");//Об'єкт не знайдено

            _classroomRepository.Delete(classroom);
        }
    }
}
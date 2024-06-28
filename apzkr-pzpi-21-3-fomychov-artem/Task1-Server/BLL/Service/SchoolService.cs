using AutoMapper;
using BLL.DTO;
using BLL.Service.Interfaces;
using DAL.Data;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace BLL.Service
{
    public class SchoolService : ISchoolService
    {
        private readonly DBContext _dbContext;
        private readonly ISchoolRepository _schoolRepository;
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;
        public SchoolService(
            DBContext dbContext,
            ISchoolRepository schoolRepository,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _schoolRepository = schoolRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Отримати список закладів
        /// </summary>
        public async Task<IEnumerable<SchoolDTO>> GetAllAsync()
        {
            var schools = await _schoolRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<SchoolDTO>>(schools);
        }

        /// <summary>
        /// Отримати заклад за його ID
        /// </summary>
        public async Task<SchoolDTO> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Incorrect Id");
            }

            var school = await _schoolRepository.GetByIdAsync(id)
                ?? throw new Exception("Object was not found");

            return _mapper.Map<SchoolDTO>(school);
        }

        /// <summary>
        /// Створити новий заклад
        /// </summary>
        public async Task<SchoolDTO> CreateAsync(CreateSchoolDTO data)
        {
            var check = await _schoolRepository.GetAllAsync();

            if (check.Where(x => x.Name == data.Name).Any())
            {
                throw new Exception("Object already exist!");
            }

            var school = _mapper.Map<School>(data);
            await _schoolRepository.CreateAsync(school);

            return _mapper.Map<SchoolDTO>(school);
        }

        /// <summary>
        /// Оновити заклад
        /// </summary>
        public async Task UpdateAsync(int id, UpdateSchoolDTO data)
        {
            if (id <= 0)
            {
                throw new Exception("Incorrect Id");
            }

            var school = await _schoolRepository.GetByIdAsync(id);

            if (school == null)
            {
                throw new Exception("Object was not found");
            }

            if (!string.IsNullOrWhiteSpace(data.Name))
            {
                school.Name = data.Name;
            }
            if (!string.IsNullOrWhiteSpace(data.Address))
            {
                school.Address = data.Address;
            }
            if (!string.IsNullOrWhiteSpace(data.Region))
            {
                school.Region = data.Region;
            }
            if (!string.IsNullOrWhiteSpace(data.District))
            {
                school.District = data.District;
            }

            _schoolRepository.Update(school);
        }

        /// <summary>
        /// Видалити заклад
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Incorrect Id");//Неправильний id
            }

            var school = await _schoolRepository.GetByIdAsync(id);

            if (school == null)
            {
                throw new Exception("Object was not found");//Об'єкт не знайдено
            }

            _schoolRepository.Delete(school);
        }
    }
}
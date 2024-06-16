using AutoMapper;
using BLL.DTO;
using BLL.Service.Interfaces;
using DAL.Data;
using DAL.Entities;
using DAL.Repository;
using DAL.Repository.Interfaces;

namespace BLL.Service
{
    public class ClassService : IClassService
    {
        private readonly DBContext _dbContext;
        private readonly IClassRepository _classRepository;
        private readonly IStudentService _studentService;
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper _mapper;
        public ClassService(
            DBContext dbContext,
            IClassRepository classRepository,
            IStudentService studentService,
            ISchoolRepository schoolRepository,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _classRepository = classRepository;
            _studentService = studentService;
            _schoolRepository = schoolRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Отримати список класів
        /// </summary>
        public async Task<IEnumerable<ClassDTO>> GetAllAsync()
        {
            var classes = await _classRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<ClassDTO>>(classes);

            foreach (var classDTO in result)
            {
                classDTO.Students = await _studentService.GetStudentsByClassIdAsync(classDTO.Id);
            }

            return result;
        }

        /// <summary>
        /// Отримати клас учня
        /// </summary>
        public async Task<ClassDTO> GetClassByStudentIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Incorrect Id");
            }

            int currentYear = DateTime.Now.Month <= 7 ? DateTime.Now.Year - 1 : DateTime.Now.Year;

            var students = await _studentService.GetAllAsync();

            var student = students.FirstOrDefault(x => x.User.Id == id && x.Class.StartYear == currentYear)
                ?? throw new Exception("Student was not found");

            var classData = await _classRepository.GetByIdAsync(student.Class.Id)
                ?? throw new Exception("Class was not found");

            student.Class.Students = await _studentService.GetStudentsByClassIdAsync(student.Class.Id);

            return student.Class;
        }

        /// <summary>
        /// Отримати клас за його ID
        /// </summary>
        public async Task<ClassDTO> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Incorrect Id");
            }

            var @class = await _classRepository.GetByIdAsync(id)
                ?? throw new Exception("Object was not found");

            var classDTO = _mapper.Map<ClassDTO>(@class);
            classDTO.Students = await _studentService.GetStudentsByClassIdAsync(classDTO.Id);

            return classDTO;
        }

        /// <summary>
        /// Створити новий клас
        /// </summary>
        public async Task<ClassDTO> CreateAsync(CreateClassDTO data)
        {
            var check = await _classRepository.GetAllAsync();

            if (check.Where(x => x.ClassName == data.ClassName).Any())
            {
                throw new Exception("Object already exist!");
            }

            var school = await _schoolRepository.GetByIdAsync(data.SchoolId)
                ?? throw new Exception("School was not found");

            var createdClass = _mapper.Map<Class>(data);
            await _classRepository.CreateAsync(createdClass);
            createdClass.School = school;

            var result = _mapper.Map<ClassDTO>(createdClass);

            return result;
        }

        /// <summary>
        /// Оновити клас
        /// </summary>
        public async Task UpdateAsync(int id, UpdateClassDTO data)
        {
            if (id <= 0 || id != data.Id)
            {
                throw new Exception("Incorrect Id");
            }

            var updatedClass = await _classRepository.GetByIdAsync(id)
                ?? throw new Exception("Object was not found");

            if (!string.IsNullOrWhiteSpace(data.ClassName))
            {
                updatedClass.ClassName = data.ClassName;
            }
            if (data.StartYear != null)
            {
                updatedClass.StartYear = data.StartYear;
            }

            _classRepository.Update(updatedClass);
        }

        /// <summary>
        /// Видалити клас
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Incorrect Id");//Неправильний id
            }

            var deletedClass = await _classRepository.GetByIdAsync(id)
                ?? throw new Exception("Object was not found");//Об'єкт не знайдено

            _classRepository.Delete(deletedClass);
        }
    }
}
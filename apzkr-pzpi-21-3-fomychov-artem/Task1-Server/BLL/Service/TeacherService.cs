using AutoMapper;
using BLL.DTO;
using BLL.Service.Interfaces;
using DAL.Data;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace BLL.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly DBContext _dbContext;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IClassRepository _classRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public TeacherService(
            DBContext dbContext,
            ITeacherRepository teacherRepository,
            IClassRepository classRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _teacherRepository = teacherRepository;
            _classRepository = classRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// Отримати вчителя класу
        /// </summary>
        public async Task<TeacherDTO> GetTeacherByClassIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Incorrect Id");
            }

            var teacher = (await _teacherRepository.GetAllAsync()).FirstOrDefault(x => x.ClassId == id)
                ?? throw new Exception("Teacher was not found!");

            return _mapper.Map<TeacherDTO>(teacher);
        }

        /// <summary>
        /// Отримати список вчителів та класів
        /// </summary>
        public async Task<IEnumerable<TeacherDTO>> GetAllAsync()
        {
            var teachers = await _teacherRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TeacherDTO>>(teachers);
        }

        /// <summary>
        /// Отримати вчителя за його ID
        /// </summary>
        public async Task<TeacherDTO> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Incorrect Id");
            }

            var teacher = await _teacherRepository.GetByIdAsync(id)
                ?? throw new Exception("Object was not found");

            return _mapper.Map<TeacherDTO>(teacher);
        }

        /// <summary>
        /// Отримати список вчителів певного року
        /// </summary>
        public async Task<IEnumerable<TeacherDTO>> GetAllByYearAsync(int year)
        {
            var teachers = await _teacherRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TeacherDTO>>(teachers.Where(x => x.StudyYeart == year));
        }

        /// <summary>
        /// Додати вчителя до класу
        /// </summary>
        public async Task<TeacherDTO> CreateAsync(CreateTeacherDTO data)
        {
            int currentYear = DateTime.Now.Month <= 7 ? DateTime.Now.Year - 1 : DateTime.Now.Year;

            var user = await _userRepository.GetByIdAsync(data.UserId);
            if (user.Role.Name != RoleName.Teacher && user.Role.Name != RoleName.Director)
                throw new Exception("User is not a teacher or director");

            var @class = await _classRepository.GetByIdAsync(data.ClassId)
                ?? throw new Exception("Class is not a teacher or director");

            var check = await _teacherRepository.GetAllAsync();

            if (check.Where(x => x.StudyYeart == currentYear && x.UserId == data.UserId).Any())
            {
                throw new Exception("The teacher is already have a class!");
            }

            var teacher = _mapper.Map<Teacher>(data);
            teacher.StudyYeart = currentYear;

            await _teacherRepository.CreateAsync(teacher);

            return _mapper.Map<TeacherDTO>(teacher);
        }

        /// <summary>
        /// Оновити вчителя
        /// </summary>
        public async Task UpdateAsync(int id, UpdateTeacherDTO data)
        {
            if (id <= 0 || id != data.Id)
            {
                throw new Exception("Incorrect Id");
            }

            var teacher = await _teacherRepository.GetByIdAsync(id);

            if (teacher == null)
            {
                throw new Exception("Teacher was not found");
            }

            if ((await _classRepository.GetByIdAsync(data.ClassId)) != null)
            {
                teacher.ClassId = data.ClassId;
            }

            _teacherRepository.Update(teacher);
        }

        /// <summary>
        /// Видалити вчителя
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Incorrect Id");//Неправильний id
            }

            var teacher = await _teacherRepository.GetByIdAsync(id);

            _teacherRepository.Delete(teacher);
        }
    }
}
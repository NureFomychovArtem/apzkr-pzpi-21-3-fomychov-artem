using AutoMapper;
using BLL.DTO;
using BLL.Service.Interfaces;
using DAL.Data;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace BLL.Service
{
    public class StudentService : IStudentService
    {
        private readonly DBContext _dbContext;
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public StudentService(
            DBContext dbContext,
            IStudentRepository studentRepository,
            IClassRepository classRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _studentRepository = studentRepository;
            _classRepository = classRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Отримати учнів класу
        /// </summary>
        public async Task<IEnumerable<UserDTO>> GetStudentsByClassIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Incorrect Id");
            }

            var students = (await _studentRepository.GetAllAsync()).Where(x => x.ClassId == id).ToList();

            List<User> users = new List<User>();

            foreach (var student in students)
            {
                users.Add(student.User);
            }

            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        /// <summary>
        /// Отримати список учнів та класів
        /// </summary>
        public async Task<IEnumerable<StudentDTO>> GetAllAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StudentDTO>>(students);
        }

        /// <summary>
        /// Отримати учня за його ID
        /// </summary>
        public async Task<StudentDTO> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Incorrect Id");
            }

            var student = await _studentRepository.GetByIdAsync(id)
                ?? throw new Exception("Object was not found");

            return _mapper.Map<StudentDTO>(student);
        }

        /// <summary>
        /// Отримати список учнів певного року
        /// </summary>
        public async Task<IEnumerable<StudentDTO>> GetAllByYearAsync(int year)
        {
            var students = await _studentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StudentDTO>>(students.Where(x => x.StudyYeart == year));
        }

        /// <summary>
        /// Додати учня до класу
        /// </summary>
        public async Task<StudentDTO> CreateAsync(CreateStudentDTO data)
        {
            int currentYear = DateTime.Now.Month <= 7 ? DateTime.Now.Year - 1 : DateTime.Now.Year;

            var user = await _userRepository.GetByIdAsync(data.UserId);
            if (user.Role.Name != RoleName.Student)
                throw new Exception("User is not a student");

            var check = await _studentRepository.GetAllAsync();
            if (check.Where(x => x.StudyYeart == currentYear && x.UserId == data.UserId).Any())
            {
                throw new Exception("The student is already in class!");
            }

            var student = _mapper.Map<Student>(data);
            student.StudyYeart = currentYear;

            await _studentRepository.CreateAsync(student);
            student.User = user;

            return _mapper.Map<StudentDTO>(student);
        }

        /// <summary>
        /// Оновити учня
        /// </summary>
        public async Task UpdateAsync(int id, UpdateStudentDTO data)
        {
            if (id <= 0 || id != data.Id)
            {
                throw new Exception("Incorrect Id");
            }

            var student = await _studentRepository.GetByIdAsync(id);

            if (student == null)
            {
                throw new Exception("Object was not found");
            }

            if ((await _classRepository.GetByIdAsync(data.ClassId)) != null)
            {
                student.ClassId = data.ClassId;
            }

            _studentRepository.Update(student);
        }

        /// <summary>
        /// Видалити учня
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Incorrect Id");//Неправильний id
            }

            var student = await _studentRepository.GetByIdAsync(id);

            _studentRepository.Delete(student);
        }
    }
}
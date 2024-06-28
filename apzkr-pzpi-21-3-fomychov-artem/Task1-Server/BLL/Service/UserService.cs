using AutoMapper;
using BLL.DTO;
using BLL.Service.Interfaces;
using DAL.Data;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace BLL.Service
{
    public class UserService : IUserService
    {
        private readonly DBContext _dbContext;
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IAccountService _accountService;
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;
        public UserService(
            DBContext dbContext,
            IUserRepository userRepository,
            IAccountRepository accountRepository,
            IRoleRepository roleRepository,
            IAccountService accountService,
            IStudentService studentService,
            ITeacherService teacherService,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _roleRepository = roleRepository;
            _accountService = accountService;
            _studentService = studentService;
            _teacherService = teacherService;
            _mapper = mapper;
        }

        /// <summary>
        /// Отримати список учнів
        /// </summary>
        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();

            var usersDTO = _mapper.Map<IEnumerable<UserDTO>>(users);

            return usersDTO;
        }

        /// <summary>
        /// Отримати учня за його ID
        /// </summary>
        public async Task<UserDTO> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Incorrect Id");
            }

            var user = await _userRepository.GetByIdAsync(id)
                ?? throw new Exception("Object was not found");

            return _mapper.Map<UserDTO>(user);
        }

        /// <summary>
        /// Додати учня 
        /// </summary>
        public async Task<UserDTO> CreateAsync(CreateUserDTO data)
        {
            var check = await _userRepository.GetAllAsync();


            if (check.Where(x => x.Phone == data.Phone).Any())
            {
                throw new Exception("Phone is already in use!");
            }
            if (check.Where(x => x.Account.Login == data.Account.Login).Any())
            {
                throw new Exception("Login is already in use!");
            }

            var account = await _accountService.CreateAsync(data.Account);

            var user = _mapper.Map<User>(data);
            user.Account = await _accountRepository.GetByIdAsync(account.Id);
            user.AccountId = account.Id;
            user.Role = await _roleRepository.GetByRoleNameAsync(RoleName.Student);
            user.RoleId = user.Role.Id;

            await _userRepository.CreateAsync(user);

            return _mapper.Map<UserDTO>(user);
        }

        /// <summary>
        /// Оновити учня
        /// </summary>
        public async Task UpdateAsync(int id, UpdateUserDTO data)
        {
            if (id <= 0 || id != data.Id)
            {
                throw new Exception("Incorrect Id");
            }

            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new Exception("Object was not found");
            }

            if (!string.IsNullOrWhiteSpace(data.Name))
            {
                user.Name = data.Name;
            }
            if (!string.IsNullOrWhiteSpace(data.Surname))
            {
                user.Surname = data.Surname;
            }
            if (!string.IsNullOrWhiteSpace(data.Patronymic))
            {
                user.Patronymic = data.Patronymic;
            }
            if (!string.IsNullOrWhiteSpace(data.Email))
            {
                user.Email = data.Email;
            }
            if (!string.IsNullOrWhiteSpace(data.Phone))
            {
                user.Phone = data.Phone;
            }
            if (!string.IsNullOrWhiteSpace(data.Fingerprint))
            {
                user.Fingerprint = data.Fingerprint;
            }
            if (!data.RoleName.Equals(null))
            {
                int currentYear = DateTime.Now.Month <= 7 ? DateTime.Now.Year - 1 : DateTime.Now.Year;

                if (user.Role.Name == RoleName.Student)
                {
                    var student = (await _studentService.GetAllAsync()).Where(x => x.User.Id == data.Id && x.Class.StartYear == currentYear)
                        ?? throw new Exception("Unable to change role because user already study in class");
                }
                if (user.Role.Name == RoleName.Teacher)
                {
                    var teacher = (await _teacherService.GetAllAsync()).Where(x => x.User.Id == data.Id && x.Class.StartYear == currentYear)
                        ?? throw new Exception("Unable to change role because teacher already in class");
                }
                user.Role = await _roleRepository.GetByRoleNameAsync(data.RoleName);
            }

            _userRepository.Update(user);
        }

        /// <summary>
        /// Видалити учня
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Incorrect Id");
            }

            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new Exception("Object was not found");
            }

            _userRepository.Delete(user);
        }
    }
}
using AutoMapper;
using BLL.DTO;
using BLL.Service.Interfaces;
using DAL.Data;
using DAL.Entities;
using DAL.Repository.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace BLL.Service
{
    public class AccountService : IAccountService
    {
        private readonly DBContext _dbContext;
        private readonly IJwtService _jwtService;
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AccountService(
            DBContext dbContext,
            IAccountRepository accountRepository,
            IUserRepository userRepository,
            IJwtService jwtService,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _accountRepository = accountRepository;
            _userRepository = userRepository;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        /// <summary>
        /// Отримати список аккаунтів
        /// </summary>
        public async Task<IEnumerable<AccountDTO>> GetAllAsync()
        {
            var accounts = await _accountRepository.GetAllAsync();
            var users = await _userRepository.GetAllAsync();

            var result = _mapper.Map<IEnumerable<AccountDTO>>(accounts);

            foreach (var account in result)
            {
                account.User = _mapper.Map<UserDTO>(users.SingleOrDefault(x => x.AccountId == account.Id));
            }

            return result;
        }

        /// <summary>
        /// Отримати заклад за його ID
        /// </summary>
        public async Task<AccountDTO> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Incorrect Id");
            }

            var account = await _accountRepository.GetByIdAsync(id)
                ?? throw new Exception("Object was not found");

            return _mapper.Map<AccountDTO>(account);
        }

        /// <summary>
        /// Вхід користувача
        /// </summary>
        public async Task<AccountDTO> LoginAsync(LoginAccountDTO data)
        {
            var account = (await _accountRepository.GetAllAsync()).FirstOrDefault(x => x.Login == data.Login)
                ?? throw new Exception("Login is incorrect");

            using var hmac = new HMACSHA512(account.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != account.PasswordHash[i])
                    throw new Exception("Password is incorrect");
            }

            var accountDto = _mapper.Map<AccountDTO>(account);
            accountDto.Token = _jwtService.CreateToken(account);
            accountDto.User = _mapper.Map<UserDTO>((await _userRepository.GetAllAsync()).SingleOrDefault(x => x.AccountId == account.Id));
            return accountDto;
        }
        /// <summary>
        /// Створити новий аккаунт
        /// </summary>
        public async Task<AccountDTO> CreateAsync(CreateAccountDTO data)
        {
            if (string.IsNullOrWhiteSpace(data.Login))
            {
                throw new Exception("Login is null!");
            }
            if (string.IsNullOrWhiteSpace(data.Password))
            {
                throw new Exception("Password is null!");
            }

            var check = await _accountRepository.GetAllAsync();

            if (check.Where(x => x.Login == data.Login).Any())
            {
                throw new Exception("Object already exist!");
            }
            using var hmac = new HMACSHA512();

            var account = new Account
            {
                Login = data.Login,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data.Password)),
                PasswordSalt = hmac.Key
            };

            await _accountRepository.CreateAsync(account);

            var accountDto = _mapper.Map<AccountDTO>(account);
            accountDto.Token = _jwtService.CreateToken(account);

            return accountDto;
        }

        /// <summary>
        /// Оновити заклад
        /// </summary>
        public async Task UpdateAsync(int id, UpdateAccountDTO data)
        {
            if (id <= 0)
            {
                throw new Exception("Incorrect Id");
            }

            var account = await _accountRepository.GetByIdAsync(id);

            if (account == null)
            {
                throw new Exception("Object was not found");
            }

            if (!string.IsNullOrWhiteSpace(data.Password))
            {
                using var hmac = new HMACSHA512();

                account.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data.Password));
                account.PasswordSalt = hmac.Key;
            }

            _accountRepository.Update(account);
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

            var account = await _accountRepository.GetByIdAsync(id);

            if (account == null)
            {
                throw new Exception("Object was not found");//Об'єкт не знайдено
            }

            _accountRepository.Delete(account);
        }
    }
}
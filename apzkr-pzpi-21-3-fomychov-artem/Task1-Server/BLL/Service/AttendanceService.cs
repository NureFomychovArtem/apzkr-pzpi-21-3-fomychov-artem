using AutoMapper;
using BLL.DTO;
using BLL.Service.Interfaces;
using DAL.Data;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace BLL.Service
{
    public class AttendanceService : IAttendanceService
    {
        private readonly DBContext _dbContext;
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public AttendanceService(
            DBContext dbContext,
            IAttendanceRepository attendanceRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _attendanceRepository = attendanceRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Отримати список відвідувань
        /// </summary>
        public async Task<IEnumerable<AttendanceDTO>> GetAllAsync()
        {
            var attendances = await _attendanceRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AttendanceDTO>>(attendances);
        }

        /// <summary>
        /// Отримати список відвідувань користувача
        /// </summary>
        public async Task<IEnumerable<AttendanceDTO>> GetByUserIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id)
                ?? throw new Exception("User was not found");

            var attendances = (await _attendanceRepository.GetAllAsync()).Where(x => x.UserId == id);
            return _mapper.Map<IEnumerable<AttendanceDTO>>(attendances);
        }

        /// <summary>
        /// Отримати відвідування за його ID
        /// </summary>
        public async Task<AttendanceDTO> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Incorrect Id");
            }

            var attendance = await _attendanceRepository.GetByIdAsync(id)
                ?? throw new Exception("Object was not found");

            return _mapper.Map<AttendanceDTO>(attendance);
        }

        /// <summary>
        /// Отримати статистику відвідуваннь користувача
        /// </summary>
        public async Task<StatisticsAttendance> GetStatisticsByUserIdAsync(int id)
        {
            var attendances = await GetByUserIdAsync(id);
            var user = await _userRepository.GetByIdAsync(id)
                ?? throw new Exception("User was not found");

            var result = new StatisticsAttendance
            {
                User = _mapper.Map<UserDTO>(user),
                TemperatureAverage = 0,
                TemperatureMax = 0,
                TemperatureMin = 100,
                TimeAverage = new DateTime(attendances.Sum(a => a.Time.Ticks) / attendances.Count()),
                TimeMax = DateTime.MinValue,
                TimeMin = DateTime.MaxValue,
            };

            foreach (var attendance in attendances)
            {
                result.TemperatureAverage += attendance.Temperature;
                result.TemperatureMax = attendance.Temperature > result.TemperatureMax ? attendance.Temperature : result.TemperatureMax;
                result.TemperatureMin = attendance.Temperature < result.TemperatureMin ? attendance.Temperature : result.TemperatureMin;
                result.TimeMax = attendance.Time > result.TimeMax ? attendance.Time : result.TimeMax;
                result.TimeMin = attendance.Time < result.TimeMin ? attendance.Time : result.TimeMin;
            }
            result.TemperatureAverage = result.TemperatureAverage / attendances.Count();

            return result;
        }

        /// <summary>
        /// Створити нове відвідування
        /// </summary>
        public async Task<AttendanceDTO> CreateAsync(CreateAttendanceDTO data)
        {
            var user = await _userRepository.GetByFingerprintAsync(data.Fingerprint)
                ?? throw new Exception("User was not found");

            if (data.Time == null)
                data.Time = DateTime.UtcNow;

            var attendance = new Attendance
            {
                UserId = user.Id,
                Time = data.Time,
                Temperature = data.Temperature
            };

            await _attendanceRepository.CreateAsync(attendance);
            attendance.User = user;

            return _mapper.Map<AttendanceDTO>(attendance);
        }

        /// <summary>
        /// Оновити відвідування
        /// </summary>
        public async Task UpdateAsync(int id, UpdateAttendanceDTO data)
        {
            if (id <= 0 || id != data.Id)
            {
                throw new Exception("Incorrect Id");
            }

            var attendance = await _attendanceRepository.GetByIdAsync(id)
                ?? throw new Exception("Object was not found");

            if (data.Time != null)
            {
                attendance.Time = data.Time;
            }
            if (data.Temperature != null)
            {
                attendance.Temperature = data.Temperature;
            }

            _attendanceRepository.Update(attendance);
        }

        /// <summary>
        /// Видалити відвідування
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Incorrect Id");
            }

            var attendance = await _attendanceRepository.GetByIdAsync(id)
                ?? throw new Exception("Attendance was not found");

            _attendanceRepository.Delete(attendance);
        }
    }
}
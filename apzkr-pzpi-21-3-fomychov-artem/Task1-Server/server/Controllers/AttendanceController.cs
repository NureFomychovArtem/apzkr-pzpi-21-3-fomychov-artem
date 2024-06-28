using BLL.DTO;
using BLL.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _attendanceService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("ByUser/{id:int}")]
        public async Task<IActionResult> GetByUser(int id)
        {
            try
            {
                var result = await _attendanceService.GetByUserIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Statistics/{id:int}")]
        public async Task<IActionResult> GetStatisticsByUser(int id)
        {
            try
            {
                var result = await _attendanceService.GetStatisticsByUserIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _attendanceService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<AttendanceDTO>> Create([FromBody] CreateAttendanceDTO data)
        {
            try
            {
                var attendance = await _attendanceService.CreateAsync(data);
                return Ok(attendance);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateAttendanceDTO data)
        {
            try
            {
                await _attendanceService.UpdateAsync(id, data);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _attendanceService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
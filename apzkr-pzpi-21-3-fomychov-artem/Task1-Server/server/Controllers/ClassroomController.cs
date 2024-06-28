using BLL.DTO;
using BLL.Service;
using BLL.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly IClassroomService _classroomService;

        public ClassroomController(IClassroomService classroomService)
        {
            _classroomService = classroomService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _classroomService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _classroomService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ClassroomDTO>> Create([FromBody] CreateClassroomDTO data)
        {
            try
            {
                var classroom = await _classroomService.CreateAsync(data);
                return Ok(classroom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateClassroomDTO data)
        {
            try
            {
                await _classroomService.UpdateAsync(id, data);
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
                await _classroomService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
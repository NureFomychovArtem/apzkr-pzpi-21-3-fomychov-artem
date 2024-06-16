using BLL.DTO;
using BLL.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var teachers = await _teacherService.GetAllAsync();
            return Ok(teachers);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var teacher = await _teacherService.GetByIdAsync(id);
                return Ok(teacher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("class/{classId:int}")]
        public async Task<IActionResult> GetTeacherByClass(int classId)
        {
            try
            {
                var teacher = await _teacherService.GetTeacherByClassIdAsync(classId);
                return Ok(teacher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<TeacherDTO>> Create([FromBody] CreateTeacherDTO data)
        {
            try
            {
                var Teacher = await _teacherService.CreateAsync(data);
                return Ok(Teacher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateTeacherDTO data)
        {
            try
            {
                await _teacherService.UpdateAsync(id, data);
                return RedirectToAction("GetById", new { id = id });
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
                await _teacherService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
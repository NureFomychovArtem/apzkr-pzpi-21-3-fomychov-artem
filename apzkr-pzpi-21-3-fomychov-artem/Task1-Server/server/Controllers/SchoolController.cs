using BLL.DTO;
using BLL.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _schoolService;
        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var schools = await _schoolService.GetAllAsync();
            return Ok(schools);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var school = await _schoolService.GetByIdAsync(id);
                return Ok(school);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<SchoolDTO>> Create([FromBody] CreateSchoolDTO data)
        {
            try
            {
                var school = await _schoolService.CreateAsync(data);
                return Ok(school);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateSchoolDTO data)
        {
            try
            {
                await _schoolService.UpdateAsync(id, data);
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
                await _schoolService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
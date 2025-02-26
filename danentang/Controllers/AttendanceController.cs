using danentang.DbContexts;
using danentang.Dtos.Attendance;
using danentang.Services.Abstract.Attendance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace danentang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendService _attendService;
        public AttendanceController(IAttendService attendService)
        {
            _attendService = attendService;
        }

        [HttpPost("CreateAttendance")]
        public IActionResult CreateAttendance([FromBody] CreateAttendanceDto input)
        {
            var att = _attendService.CreateAttendance(input);
            return Ok(att);
        }

        [HttpPut("UpdateAttendance")]
        public IActionResult UpdateAttendance([FromBody] UpdateAttendanceDto input)
        {
            try
            {
                _attendService.UpdateAttendance(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteAttendanceBy{id}")]
        public IActionResult DeleteAttendance([FromBody] int id)
        {
            _attendService.DeleteAttendance(id);
            return NoContent();
        }
    }
}

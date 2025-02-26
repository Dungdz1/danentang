using danentang.Dtos.Payroll;
using danentang.Services.Abstract.Payroll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace danentang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly IPayrollService _payrollService;
        public PayrollController(IPayrollService payrollService)
        {
            _payrollService = payrollService;
        }

        [HttpPost("CreatePayRoll")]
        public IActionResult CreatePayRoll([FromBody] CreatePayrollDto input)
        {
            var pay = _payrollService.CreatePayroll(input);
            return Ok(pay);
        }

        [HttpPut("UpdateBy{id}")]
        public IActionResult UpdatePayroll([FromBody] UpdatePayrollDto input)
        {
            try
            {
                _payrollService.UpdatePayroll(input);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeletePayBy{id}")]
        public IActionResult DeletePayroll([FromBody] int id)
        {
            _payrollService.DeletePayroll(id);
            return NoContent();
        }
    }
}

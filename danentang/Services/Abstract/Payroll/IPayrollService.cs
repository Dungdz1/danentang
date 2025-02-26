using danentang.Dtos.Attendance;
using danentang.Dtos.Payroll;

namespace danentang.Services.Abstract.Payroll
{
    public interface IPayrollService
    {
        PayrollDto CreatePayroll(CreatePayrollDto input);
        void UpdatePayroll(UpdatePayrollDto input);
        void DeletePayroll(int id);
    }
}

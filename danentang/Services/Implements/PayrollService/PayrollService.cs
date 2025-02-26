using danentang.DbContexts;
using danentang.Dtos.Payroll;
using danentang.Entity;
using danentang.Services.Abstract.Payroll;

namespace danentang.Services.Implements.PayrollService
{
    public class PayrollService : ProllBaseService, IPayrollService
    {
        private readonly ApplicationDbContext _dbContext;
        public PayrollService(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public PayrollDto CreatePayroll(CreatePayrollDto input)
        {
            var pay = new Payroll
            {
                UserId = input.UserId,
                Base_salary = input.Base_salary,
                Bonus = input.Bonus,
                Deductions = input.Deductions,
                Details = input.Details,
                Month = input.Month,
                Net_salary = input.Net_salary,
            };
            _dbContext.Add(pay);
            _dbContext.SaveChanges();
            return new PayrollDto
            {
                Id = pay.Id,
                UserId = pay.UserId,
                Base_salary = pay.Base_salary,
                Bonus = pay.Bonus,
                Deductions = pay.Deductions,
                Details = pay.Details,
                Month = pay.Month,
                Net_salary = pay.Net_salary,
            };
        }

        public void DeletePayroll(int id)
        {
            var payFind = FindPayById(id);
            _dbContext.Payrolls.Remove(payFind);
            _dbContext.SaveChanges();
        }

        public void UpdatePayroll(UpdatePayrollDto input)
        {
            var payFind = FindPayById(input.Id);
            payFind.UserId = input.UserId;
            payFind.Base_salary = input.Base_salary;
            payFind.Bonus = input.Bonus;
            payFind.Deductions = input.Deductions;
            payFind.Details = input.Details;
            payFind.Month = input.Month;
            payFind.Net_salary = input.Net_salary;
        }
    }
}

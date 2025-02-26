using danentang.DbContexts;
using danentang.Entity;
using danentang.Exceptions;

namespace danentang.Services.Implements.PayrollService
{
    public class ProllBaseService
    {
        protected readonly ApplicationDbContext _dbContext;
        public ProllBaseService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected Payroll FindPayById(int payId)
        {
            var payFind = _dbContext.Payrolls.FirstOrDefault(s => s.Id == payId && !s.IsDeleted);
            if (payFind == null)
            {
                throw new UserFriendlyException($"Không tìm thấy người dùng có id {payId}");
            }
            return payFind;
        }
    }
}

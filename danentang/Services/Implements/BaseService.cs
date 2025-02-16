using danentang.DbContexts;
using danentang.Entity;
using danentang.Exceptions;

namespace danentang.Services.Implements
{
    public class BaseService
    {
        protected readonly ApplicationDbContext _dbContext;
        public BaseService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected User FindUserById(int userId)
        {
            var userFind = _dbContext.Users.FirstOrDefault(s => s.Id == userId && !s.IsDeleted);
            if (userFind != null)
            {
                throw new UserFriendlyException($"Không tìm thấy người dùng có id {userId}");
            }
            return userFind;
        }
    }
}

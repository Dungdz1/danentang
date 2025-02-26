using danentang.DbContexts;
using danentang.Entity;
using danentang.Exceptions;

namespace danentang.Services.Implements.AttendService
{
    public class AttBaseService
    {
        protected readonly ApplicationDbContext _dbContext;
        public AttBaseService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected Attendance FindAttendanceById(int attendanceId)
        {
            var attFind = _dbContext.Attendances.FirstOrDefault(s => s.Id == attendanceId && !s.IsDeleted);
            if (attFind == null)
            {
                throw new UserFriendlyException($"Không tìm thấy người dùng có id {attendanceId}");
            }
            return attFind;
        }
    }
}

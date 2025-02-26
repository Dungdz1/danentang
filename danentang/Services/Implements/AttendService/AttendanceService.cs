using danentang.DbContexts;
using danentang.Dtos.Attendance;
using danentang.Entity;
using danentang.Services.Abstract.Attendance;
using Microsoft.Extensions.Configuration;

namespace danentang.Services.Implements.AttendService
{
    public class AttendanceService : AttBaseService, IAttendService
    {
        private readonly ApplicationDbContext _dbContext;
        public AttendanceService(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public AttendanceDto CreateAttendance(CreateAttendanceDto input)
        {
            var att = new Attendance
            {
                UserId = input.UserId,
                TimeTamp = input.TimeTamp,
                Statuss = input.Statuss,
            };
            _dbContext.Add(att);
            _dbContext.SaveChanges();
            return new AttendanceDto
            {
                Id = att.Id,
                UserId = att.UserId,
                TimeTamp = att.TimeTamp,
                Statuss = att.Statuss,
            };
        }

        public void DeleteAttendance(int id)
        {
            var attFind = FindAttendanceById(id);
            _dbContext.Attendances.Remove(attFind);
            _dbContext.SaveChanges();
        }

        public void UpdateAttendance(UpdateAttendanceDto input)
        {
            var attFind = FindAttendanceById(input.Id);
            attFind.UserId = input.UserId;
            attFind.TimeTamp = input.TimeTamp;
            attFind.Statuss = input.Statuss;

        }
    }
}

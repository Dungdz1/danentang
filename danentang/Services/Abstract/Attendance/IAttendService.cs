using danentang.Dtos;
using danentang.Dtos.Attendance;

namespace danentang.Services.Abstract.Attendance
{
    public interface IAttendService
    {
        AttendanceDto CreateAttendance(CreateAttendanceDto input);
        void UpdateAttendance(UpdateAttendanceDto input);
        void DeleteAttendance(int id);
    }
}

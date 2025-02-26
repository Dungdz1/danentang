namespace danentang.Dtos.Attendance
{
    public class CreateAttendanceDto
    {
        public int UserId { get; set; }
        public DateTime TimeTamp { get; set; }
        public string Statuss { get; set; }
    }
}

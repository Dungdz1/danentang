namespace danentang.Dtos.Attendance
{
    public class AttendanceDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime TimeTamp { get; set; }
        public string Statuss { get; set; }
    }
}

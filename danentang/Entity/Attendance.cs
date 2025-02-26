namespace danentang.Entity
{
    public class Attendance
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime TimeTamp { get; set; }
        public string Statuss { get; set; }
        public bool IsDeleted { get; set; }
    }
}

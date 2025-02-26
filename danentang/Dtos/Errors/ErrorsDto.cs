namespace danentang.Dtos.Errors
{
    public class ErrorsDto
    {
        public int Id { get; set; }
        public DateTime TimeTamp { get; set; }
        public string Modules { get; set; }
        public string Error_Code { get; set; }
        public string Error_msg { get; set; }
        public string Context { get; set; }
    }
}

namespace danentang.Dtos
{
    public class LoginResponseDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}

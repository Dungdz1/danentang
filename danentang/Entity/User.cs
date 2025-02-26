namespace danentang.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string id_card_number { get; set; }
        public string Role { get; set; }
        public int manager_id { get; set; }
        public bool IsDeleted { get; set; }
    }
}

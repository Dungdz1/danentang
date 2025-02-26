namespace danentang.Dtos.Payroll
{
    public class PayrollDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Month { get; set; }
        public decimal Base_salary { get; set; }
        public decimal Bonus { get; set; }
        public decimal Deductions { get; set; }
        public decimal Net_salary { get; set; }
        public string Details { get; set; }
    }
}

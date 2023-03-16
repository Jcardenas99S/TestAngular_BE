namespace TestAngular_BE.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public long? EmployeeNationalId { get; set; }

        public string? EmployeeName { get; set; }

        public bool? IsActive { get; set; }
    }
}

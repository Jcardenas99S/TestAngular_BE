namespace TestAngular_BE.DTOs
{
    public class ServiceDTO
    {
        public int Id { get; set; }

        public int? ServiceTypeId { get; set; }

        public string? ServiceTypeIdName { get; set; }

        public int? PetId { get; set; }

        public string? PetIdName { get; set; }

        public int? EmployeeId { get; set; }

        public string? EmployeeIdName { get; set; }

        public string? ServiceDate { get; set; }

        public bool? IsActive { get; set; }
    }
}

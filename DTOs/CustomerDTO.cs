namespace TestAngular_BE.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        public string? CustomerName { get; set; }

        public string? CustomerPhone { get; set; }

        public int? CustomerTypeId { get; set; }

        public String? CustomerTypeIdName { get; set; }

        public string? CustomerEmail { get; set; }

        public long? CustomerNationalId { get; set; }

        public bool? IsActive { get; set; }
    }
}

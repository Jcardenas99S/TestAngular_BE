namespace TestAngular_BE.DTOs
{
    public class PetDTO
    {
        public int Id { get; set; }

        public string? PetName { get; set; }

        public int? PetAge { get; set; }

        public int? CustomerId { get; set; }

        public String? CustomerIdName { get; set; }

        public int? PetTypeId { get; set; }

        public String? PetTypeIdName { get; set; }

        public bool? IsActive { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace TestAngular_BE.Models;

public partial class PetJc
{
    public int Id { get; set; }

    public string? PetName { get; set; }

    public int? PetAge { get; set; }

    public int? CustomerId { get; set; }

    public int? PetTypeId { get; set; }

    public bool? IsActive { get; set; }

    public virtual CustomerJc? Customer { get; set; }

    public virtual PetTypeJc? PetType { get; set; }

    public virtual ICollection<ServiceJc> ServiceJcs { get; } = new List<ServiceJc>();
}

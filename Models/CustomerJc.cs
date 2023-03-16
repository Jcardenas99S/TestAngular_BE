using System;
using System.Collections.Generic;

namespace TestAngular_BE.Models;

public partial class CustomerJc
{
    public int Id { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerPhone { get; set; }

    public int? CustomerTypeId { get; set; }

    public string? CustomerEmail { get; set; }

    public long? CustomerNationalId { get; set; }

    public bool? IsActive { get; set; }

    public virtual CustomerTypeJc? CustomerType { get; set; }

    public virtual ICollection<PetJc> PetJcs { get; } = new List<PetJc>();
}

using System;
using System.Collections.Generic;

namespace TestAngular_BE.Models;

public partial class PetTypeJc
{
    public int Id { get; set; }

    public string? PetTypeName { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<PetJc> PetJcs { get; } = new List<PetJc>();
}

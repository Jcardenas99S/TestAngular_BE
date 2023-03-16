using System;
using System.Collections.Generic;

namespace TestAngular_BE.Models;

public partial class ServiceTypeJc
{
    public int Id { get; set; }

    public string? ServiceTypeName { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<ServiceJc> ServiceJcs { get; } = new List<ServiceJc>();
}

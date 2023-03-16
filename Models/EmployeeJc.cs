using System;
using System.Collections.Generic;

namespace TestAngular_BE.Models;

public partial class EmployeeJc
{
    public int Id { get; set; }

    public long? EmployeeNationalId { get; set; }

    public string? EmployeeName { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<ServiceJc> ServiceJcs { get; } = new List<ServiceJc>();
}

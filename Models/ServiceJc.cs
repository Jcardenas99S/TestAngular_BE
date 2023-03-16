using System;
using System.Collections.Generic;

namespace TestAngular_BE.Models;

public partial class ServiceJc
{
    public int Id { get; set; }

    public int? ServiceTypeId { get; set; }

    public int? PetId { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime? ServiceDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual EmployeeJc? Employee { get; set; }

    public virtual PetJc? Pet { get; set; }

    public virtual ServiceTypeJc? ServiceType { get; set; }
}

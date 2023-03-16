using System;
using System.Collections.Generic;

namespace TestAngular_BE.Models;

public partial class CustomerTypeJc
{
    public int Id { get; set; }

    public string? CustomerTypeCode { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<CustomerJc> CustomerJcs { get; } = new List<CustomerJc>();
}

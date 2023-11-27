using System;
using System.Collections.Generic;

namespace nppApplication.Models.Data;

public partial class Address
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string? Company { get; set; }

    public string Address1 { get; set; } = null!;

    public string Postal { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual User? User { get; set; }
}

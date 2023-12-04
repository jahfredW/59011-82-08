using System;
using System.Collections.Generic;

namespace nppApplication.Models.Data;

public partial class Director
{
    public int Id { get; set; }

    public string LastName { get; set; } = null!;

    public string? FirstName { get; set; }

    public virtual ICollection<Film> Films { get; set; } = new List<Film>();
}

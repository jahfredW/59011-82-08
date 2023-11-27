using System;
using System.Collections.Generic;

namespace nppApplication.Models.Data;

public partial class Film
{
    public int Id { get; set; }

    public int? DirectorId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Photo { get; set; }

    public virtual Director? Director { get; set; }
}

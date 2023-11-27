using System;
using System.Collections.Generic;

namespace nppApplication.Models.Data;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    /// <summary>
    /// (DC2Type:datetime_immutable)
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// (DC2Type:datetime_immutable)
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
}

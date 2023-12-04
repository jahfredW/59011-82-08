using System;
using System.Collections.Generic;

namespace nppApplication.Models.Data;

public partial class Album
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    /// <summary>
    /// (DC2Type:datetime_immutable)
    /// </summary>
    public DateTime CreatedAt { get; set; }

    public string? CoverPicture { get; set; }

    public bool Morning { get; set; }

    public bool IsActive { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Picture> Pictures { get; set; } = new List<Picture>();
}

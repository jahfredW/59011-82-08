using System;
using System.Collections.Generic;

namespace nppApplication.Models.Data;

public partial class Picture
{
    public int Id { get; set; }

    public int? AlbumId { get; set; }

    public string Name { get; set; } = null!;

    public string FileName { get; set; } = null!;

    /// <summary>
    /// (DC2Type:datetime_immutable)
    /// </summary>
    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }

    public string Thumbnail { get; set; } = null!;

    public virtual Album? Album { get; set; }
}

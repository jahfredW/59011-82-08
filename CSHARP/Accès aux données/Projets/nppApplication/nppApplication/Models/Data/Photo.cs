using System;
using System.Collections.Generic;

namespace nppApplication.Models.Data;

public partial class Photo
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    /// <summary>
    /// (DC2Type:datetime_immutable)
    /// </summary>
    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }

    public string Path { get; set; } = null!;
}

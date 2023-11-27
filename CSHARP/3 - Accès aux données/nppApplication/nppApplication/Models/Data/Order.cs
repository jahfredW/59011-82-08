using System;
using System.Collections.Generic;

namespace nppApplication.Models.Data;

public partial class Order
{
    public int Id { get; set; }

    /// <summary>
    /// (DC2Type:datetime_immutable)
    /// </summary>
    public DateTime CreatedAt { get; set; }

    public string Status { get; set; } = null!;

    public bool IsActive { get; set; }

    public int? UserId { get; set; }

    public string? StripeId { get; set; }

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    public virtual User? User { get; set; }
}

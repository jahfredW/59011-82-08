using System;
using System.Collections.Generic;

namespace nppApplication.Models.Data;

public partial class OrderLine
{
    public int Id { get; set; }

    public int OrderedId { get; set; }

    public int Quantity { get; set; }

    public double Price { get; set; }

    public double Total { get; set; }

    public int PictureId { get; set; }

    public virtual Order Ordered { get; set; } = null!;
}

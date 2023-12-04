using System;
using System.Collections.Generic;

namespace EntityFrameWorkAfpa.Models.Data;

public partial class Voeux
{
    public int IdVoeu { get; set; }

    public string? EstExaucé { get; set; }

    public int IdCadeau { get; set; }

    public int? IdEnfant { get; set; }

    public virtual Cadeau IdCadeauNavigation { get; set; } = null!;

    public virtual Enfant? IdEnfantNavigation { get; set; }
}

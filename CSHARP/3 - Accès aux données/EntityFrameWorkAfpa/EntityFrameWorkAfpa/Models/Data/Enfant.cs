using System;
using System.Collections.Generic;

namespace EntityFrameWorkAfpa.Models.Data;

public partial class Enfant
{
    public int IdEnfant { get; set; }

    public int NomEnfant { get; set; }

    public string? PrenomEnfant { get; set; }

    public string AdresseEnfant { get; set; } = null!;

    public bool? SexeEnfant { get; set; }

    public decimal? SagesseEnfant { get; set; }

    public virtual ICollection<Voeux> Voeuxes { get; set; } = new List<Voeux>();
}

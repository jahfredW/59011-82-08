using System;
using System.Collections.Generic;

namespace ExerciceAPI.Models.Data;

public partial class Enfant
{
    public int IdEnfant { get; set; }

    public string NomEnfant { get; set; } = null!;

    public string? PrenomEnfant { get; set; }

    public string AdresseEnfant { get; set; } = null!;

    public bool? SexeEnfant { get; set; }

    public decimal? SagesseEnfant { get; set; }

    public virtual ICollection<Voeux> Voeuxes { get; set; } = new List<Voeux>();
}

using System;
using System.Collections.Generic;

namespace ExerciceAPI.Models.Data;

public partial class Lutin
{
    public int IdLutin { get; set; }

    public string? NomLutin { get; set; }

    public string? PrenomLutin { get; set; }

    public virtual ICollection<Gerer> Gerers { get; set; } = new List<Gerer>();

    public virtual ICollection<Tournee> Tournees { get; set; } = new List<Tournee>();
}

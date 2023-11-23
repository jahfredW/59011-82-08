using System;
using System.Collections.Generic;

namespace ExerciceAPI.Models.Data;

public partial class Renne
{
    public string NomRenne { get; set; } = null!;

    public bool? SexeRenne { get; set; }

    public DateTime? DateDeNaissance { get; set; }

    public int? IdTraineau { get; set; }

    public virtual Traineau? IdTraineauNavigation { get; set; }
}

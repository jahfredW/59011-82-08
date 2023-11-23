using System;
using System.Collections.Generic;

namespace ExerciceAPI.Models.Data;

public partial class Cadeau
{
    public int IdCadeau { get; set; }

    public int DesignationCadeau { get; set; }

    public int? IdTraineau { get; set; }

    public virtual Traineau? IdTraineauNavigation { get; set; }

    public virtual ICollection<Voeux> Voeuxes { get; set; } = new List<Voeux>();
}

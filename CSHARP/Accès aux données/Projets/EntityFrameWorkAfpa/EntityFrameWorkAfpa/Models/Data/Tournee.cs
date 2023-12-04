using System;
using System.Collections.Generic;

namespace EntityFrameWorkAfpa.Models.Data;

public partial class Tournee
{
    public int IdTournee { get; set; }

    public DateTime? DateDepart { get; set; }

    public int? IdLutin { get; set; }

    public int? IdTraineau { get; set; }

    public virtual Lutin? IdLutinNavigation { get; set; }

    public virtual Traineau? IdTraineauNavigation { get; set; }
}

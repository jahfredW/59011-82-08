using System;
using System.Collections.Generic;

namespace EntityFrameWorkAfpa.Models.Data;

public partial class Gerer
{
    public int IdLutin { get; set; }

    public int IdTraineau { get; set; }

    public string? DatePriseEnCompte { get; set; }

    public virtual Lutin IdLutinNavigation { get; set; } = null!;

    public virtual Traineau IdTraineauNavigation { get; set; } = null!;
}

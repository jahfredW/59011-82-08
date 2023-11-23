using System;
using System.Collections.Generic;

namespace EntityFrameWorkAfpa.Models.Data;

public partial class Traineau
{
    public int IdTraineau { get; set; }

    public DateTime? DateMiseEnService { get; set; }

    public decimal? TailleTraineau { get; set; }

    public DateTime? DateRevision { get; set; }

    public virtual ICollection<Cadeau> Cadeaus { get; set; } = new List<Cadeau>();

    public virtual ICollection<Gerer> Gerers { get; set; } = new List<Gerer>();

    public virtual ICollection<Renne> Rennes { get; set; } = new List<Renne>();

    public virtual ICollection<Tournee> Tournees { get; set; } = new List<Tournee>();
}

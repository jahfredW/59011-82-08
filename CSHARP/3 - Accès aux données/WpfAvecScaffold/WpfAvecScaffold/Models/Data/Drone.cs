using System;
using System.Collections.Generic;

namespace WpfAvecScaffold.Models.Data;

public partial class Drone
{
    public int IdDrone { get; set; }

    public string? Nom { get; set; }

    public decimal? Prix { get; set; }

    public int IdTypeDrone { get; set; }

    public virtual TypeDrone LeTypeDeDrone { get; set; } = null!;

    public virtual ICollection<Session> ListeSessions { get; set; } = new List<Session>();
}

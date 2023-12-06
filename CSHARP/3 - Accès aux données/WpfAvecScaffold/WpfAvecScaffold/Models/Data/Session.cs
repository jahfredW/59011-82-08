using System;
using System.Collections.Generic;

namespace WpfAvecScaffold.Models.Data;

public partial class Session
{
    public int IdDrone { get; set; }

    public int IdPilote { get; set; }

    public int IdSession { get; set; }

    public DateTime? DateSession { get; set; }

    public virtual Drone LeDrone { get; set; } = null!;

    public virtual Pilote LePilote { get; set; } = null!;
}

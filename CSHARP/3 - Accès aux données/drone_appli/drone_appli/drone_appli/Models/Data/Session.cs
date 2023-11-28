using System;
using System.Collections.Generic;

namespace drone_appli.Models.Data;

public partial class Session
{
    public int IdDrone { get; set; }

    public int IdPilote { get; set; }

    public int IdSession { get; set; }

    public DateTime? DateSession { get; set; }

    public virtual Drone IdDroneNavigation { get; set; } = null!;

    public virtual Pilote IdPiloteNavigation { get; set; } = null!;
}

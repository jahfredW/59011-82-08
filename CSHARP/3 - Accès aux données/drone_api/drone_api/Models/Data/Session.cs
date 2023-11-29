using System;
using System.Collections.Generic;

namespace drone_api.Models.Data;

public partial class Session
{
    public int IdDrone { get; set; }

    public int IdPilote { get; set; }

    public int IdSession { get; set; }

    public DateTime? DateSession { get; set; }

    public virtual Drone drone { get; set; } = null!;

    public virtual Pilote Pilote { get; set; } = null!;
}

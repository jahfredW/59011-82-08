using System;
using System.Collections.Generic;

namespace drone_last.Models.Data;

public partial class TypeDrone
{
    public int IdTypeDrone { get; set; }

    public string? Intitule { get; set; }

    public virtual ICollection<Drone> Drones { get; set; } = new List<Drone>();
}

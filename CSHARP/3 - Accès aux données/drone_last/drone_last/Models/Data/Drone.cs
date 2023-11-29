﻿using System;
using System.Collections.Generic;

namespace drone_last.Models.Data;

public partial class Drone
{
    public int IdDrone { get; set; }

    public string? Nom { get; set; }

    public decimal? Prix { get; set; }

    public int IdTypeDrone { get; set; }

    public virtual TypeDrone TypeDroneRelation { get; set; } = null!;

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}

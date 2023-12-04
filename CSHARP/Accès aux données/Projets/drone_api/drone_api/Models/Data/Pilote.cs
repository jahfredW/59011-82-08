using System;
using System.Collections.Generic;

namespace drone_api.Models.Data;

public partial class Pilote
{
    public int IdPilote { get; set; }

    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}

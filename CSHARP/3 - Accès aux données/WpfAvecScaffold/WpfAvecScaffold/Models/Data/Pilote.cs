using System;
using System.Collections.Generic;

namespace WpfAvecScaffold.Models.Data;

public partial class Pilote
{
    public int IdPilote { get; set; }

    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public virtual ICollection<Session> ListeSessions { get; set; } = new List<Session>();
}

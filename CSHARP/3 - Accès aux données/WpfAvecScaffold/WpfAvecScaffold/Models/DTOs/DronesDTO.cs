using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAvecScaffold.Models.Data;

namespace WpfAvecScaffold.Models.DTOs
{
    public class DronesDTO
    {
        public int IdDrone { get; set; }

        public string? Nom { get; set; }

        public decimal? Prix { get; set; }

        public int IdTypeDrone { get; set; }

        public virtual TypeDrone LeTypeDeDrone { get; set; } = null!;

        public virtual ICollection<Session> ListeSessions { get; set; } = new List<Session>();
    }

    public class DronesDTOIn
    {
        public string? Nom { get; set; }

        public decimal? Prix { get; set; }

        public int IdTypeDrone { get; set; }

        // public string LeTypeDeDrone { get; set; } = null!;
    }

    public class DronesDTOOut
    {
        public int IdDrone { get; set; }

        public string? Nom { get; set; }

        public decimal? Prix { get; set; }

        public int IdTypeDrone { get; set; }

        public string LeTypeDeDrone { get; set; } = null!;

        // public virtual ICollection<Session> ListeSessions { get; set; } = new List<Session>();.

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAvecScaffold.Models.Data;

namespace WpfAvecScaffold.Models.DTOs
{
    public class TypeDronesDTO
    {
        public int IdTypeDrone { get; set; }

        public string? Intitule { get; set; }

        public virtual ICollection<Drone> Drones { get; set; } = new List<Drone>();
    }

    public class TypeDronesDTOIn
    {
        public string? Intitule { get; set; }

        // public virtual ICollection<Drone> Drones { get; set; } = new List<Drone>();
    }

    public class TypeDronesDTOOut
    {
        public int IdTypeDrone { get; set; }

        public string? Intitule { get; set; }

        // public virtual ICollection<Drone> Drones { get; set; } = new List<Drone>();
    }
}

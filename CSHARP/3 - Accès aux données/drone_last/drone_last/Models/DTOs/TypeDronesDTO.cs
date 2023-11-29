using drone_last.Models.Data;

namespace drone_last.Models.DTOs
{
    public class TypeDronesDTO
    {
        public int IdTypeDrone { get; set; }

        public string? Intitule { get; set; }

        public virtual ICollection<DronesDTOout> Drones { get; set; }
    }


    public class TypeDronesDTOout
    {
        // public int IdTypeDrone { get; set; }

        public string? Intitule { get; set; }

        // public virtual ICollection<Drone> Drones { get; set; } = new List<Drone>();
    }

    public class TypeDronesDTOin
    {
        public int IdTypeDrone { get; set; }

        public string? Intitule { get; set; }

        // public virtual ICollection<Drone> Drones { get; set; } = new List<Drone>();
    }
}

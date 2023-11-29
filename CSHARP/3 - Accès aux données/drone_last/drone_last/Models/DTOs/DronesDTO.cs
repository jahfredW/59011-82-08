using drone_last.Models.Data;

namespace drone_last.Models.DTOs
{
    public class DronesDTO
    {
        public int IdDrone { get; set; }

        public string? Nom { get; set; }

        public decimal? Prix { get; set; }

        public int IdTypeDrone { get; set; }

        public virtual TypeDronesDTOout TypeDroneRelation { get; set; }

        public virtual ICollection<SessionsDTOout> Sessions { get; set; }
    }

    public class DronesDTOin
    {
        public int IdDrone { get; set; }

        public string? Nom { get; set; }

        public decimal? Prix { get; set; }

        public int IdTypeDrone { get; set; }
    }

    public class DronesDTOout
    {
        // public int IdDrone { get; set; }

        public string? Nom { get; set; }

        public decimal? Prix { get; set; }

        public int IdTypeDrone { get; set; }
    }
}

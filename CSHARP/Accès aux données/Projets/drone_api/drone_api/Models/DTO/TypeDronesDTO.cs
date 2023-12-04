
using drone_api.Models.Data;

namespace drone_api.Models.DTO
{
    public class TypeDronesDTO
    {

        public int IdTypeDrone { get; set; }

        public string? Intitule { get; set; }

        public virtual ICollection<Drone> Drones { get; set; } = new List<Drone>();

    }
}




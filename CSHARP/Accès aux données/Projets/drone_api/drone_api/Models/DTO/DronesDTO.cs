using drone_api.Models.Data;

namespace drone_api.Models.DTO
{
    public class DronesDTO
    {

        public string? Nom { get; set; }

        public decimal? Prix { get; set; }

        public int IdTypeDrone { get; set; }

        public int TypeDrone  { get; set; }

        public virtual ICollection<Session> Session { get; set; } = new List<Session>();
        
    }

    public class DronesDTOWithSessions
    {

        public string? Nom { get; set; }

        public decimal? Prix { get; set; }

        public int IdTypeDrone { get; set; }

        public int TypeDrone { get; set; }

        public virtual ICollection<SessionsDTO> Sessions { get; set; }

    }

    public class DronesDTOIn
    {

        public string? Nom { get; set; }

        public decimal? Prix { get; set; }

        public string IntituleTypeDrone { get; set; }

        public int TypeDrone { get; set; }

    }
}

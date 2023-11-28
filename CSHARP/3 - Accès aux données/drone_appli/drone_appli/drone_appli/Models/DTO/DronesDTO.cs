using drone_appli.Models.Data;

namespace drone_appli.Models.DTO
{
    public class DronesDTO
    {
        public int IdDrone { get; set; }

        public string? Nom { get; set; }

        public decimal? Prix { get; set; }

        public int IdTypeDrone { get; set; }

        public virtual TypeDrone IdTypeDroneNavigation { get; set; } = null!;

        public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}

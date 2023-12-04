using drone_last.Models.Data;

namespace drone_last.Models.DTOs
{
    public class SessionsDTO
    {
        public int IdDrone { get; set; }

        public int IdPilote { get; set; }

        public int IdSession { get; set; }

        public DateTime? DateSession { get; set; }

        public virtual DronesDTOout DroneRelation { get; set; } = null!;

        public virtual PilotesDTOout PiloteRelation { get; set; } = null!;
    }

    public class SessionsDTOout
    {
        // public int IdDrone { get; set; }

        public int IdPilote { get; set; }

        public int IdSession { get; set; }

        public DateTime? DateSession { get; set; }

        // public virtual Drone DroneRelation { get; set; } = null!;

        // public virtual Pilote PiloteRelation { get; set; } = null!;
    }

    public class SessionsDTOin
    {
        public int IdDrone { get; set; }

        public int IdPilote { get; set; }

        public int IdSession { get; set; }

        public DateTime? DateSession { get; set; }

        // public virtual Drone DroneRelation { get; set; } = null!;

        // public virtual Pilote PiloteRelation { get; set; } = null!;
    }

    public class SessionsDTOoutSession
    {
        public int IdDrone { get; set; }

        // public int IdPilote { get; set; }

        public int IdSession { get; set; }

        public DateTime? DateSession { get; set; }

        public virtual DronesDTOout DroneRelation { get; set; } = null!;

        // public virtual Pilote PiloteRelation { get; set; } = null!;
    }
}

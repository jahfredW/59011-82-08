
using drone_api.Models.Data;

namespace drone_api.Models.DTO
{
    public class SessionsDTO
    {

        public int IdPilote { get; set; }

        public int IdSession { get; set; }

        public DateTime? DateSession { get; set; }

        //public virtual Drone drone { get; set; } = null!;

        public virtual PilotesDTOWithoutSessions Pilote { get; set; } = null!;

    }
}




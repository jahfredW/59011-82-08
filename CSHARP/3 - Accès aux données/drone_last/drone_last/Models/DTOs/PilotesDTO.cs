using drone_last.Models.Data;

namespace drone_last.Models.DTOs
{
    public class PilotesDTO
    {
        public int IdPilote { get; set; }

        public string? Nom { get; set; }

        public string? Prenom { get; set; }

        public virtual ICollection<SessionsDTOoutSession> Sessions { get; set; }
    }

    public class PilotesDTOin
    {
        public int IdPilote { get; set; }

        public string? Nom { get; set; }

        public string? Prenom { get; set; }
    }

    public class PilotesDTOout
    {
        // public int IdPilote { get; set; }

        public string? Nom { get; set; }

        public string? Prenom { get; set; }
    }

}

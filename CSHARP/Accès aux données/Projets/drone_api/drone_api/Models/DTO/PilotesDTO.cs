
using drone_api.Models.Data;

namespace drone_api.Models.DTO
{
    public class PilotesDTO
    {
        public string? Nom { get; set; }

        public string? Prenom { get; set; }

        public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

    }

    public class PilotesDTOWithoutSessions
    {
        public string? Nom { get; set; }

        public string? Prenom { get; set; }

        // public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

    }
}










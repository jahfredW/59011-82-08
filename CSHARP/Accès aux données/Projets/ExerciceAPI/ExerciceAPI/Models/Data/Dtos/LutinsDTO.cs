namespace ExerciceAPI.Models.Data.Dtos
{
    public class LutinsDTO
    {
        public string? NomLutin { get; set; }

        public string? PrenomLutin { get; set; }

        public virtual ICollection<Gerer> Gerers { get; set; } = new List<Gerer>();

        public virtual ICollection<Tournee> Tournees { get; set; } = new List<Tournee>();
    }
}

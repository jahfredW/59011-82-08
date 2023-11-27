using nppApplication.Models.Data;

namespace nppApplication.Models.DTO
{
    public class PicturesDTO
    {
        //public int? AlbumId { get; set; }

        public string Name { get; set; } = null!;

        public string FileName { get; set; } = null!;

        /// <summary>
        /// (DC2Type:datetime_immutable)
        /// </summary>
        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }

        public string Thumbnail { get; set; } = null!;

        public virtual Album? Album { get; set; }
    }
}

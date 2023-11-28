using nppApplication.Models.Data;

namespace nppApplication.Models.Services
{
    public class AlbumsService
    {
        private readonly nppContext _context;

        public AlbumsService(nppContext context)
        {
            _context = context;
        }

        public void AddAlbum(Album album)
        {
            if(album == null)
            {
                throw new ArgumentNullException(nameof(album));
            }

            _context.Albums.Add(album);
            _context.SaveChanges();
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            return _context.Albums.ToList();
        }

        public Album GetAlbumById(int id)
        {
            Album album = _context.Albums.FirstOrDefault(a => a.Id == id);

            return album;
        }
        public void DeleteAlbum(Album album) {

            _context.Albums.Remove(album);
            _context.SaveChanges();
        }

        public void UpdateAlbum(Album album)
        {
            _context.Albums.Update(album);
            _context.SaveChanges();
        }


    }
}

using Microsoft.EntityFrameworkCore;
using nppApplication.Models.Data;
using Org.BouncyCastle.Crypto.Paddings;

namespace nppApplication.Models.Services
{
    public class PicturesService
    {
        private readonly nppContext _context;

        public PicturesService(nppContext context)
        {
            _context = context;
        }

        // Read ALL
        public IEnumerable<Picture> GetAllPictures()
        {
            return _context.Pictures.Include("Album").ToList();
        }

        // Read One Picture 
        public Picture GetPictureById(int id)
        {
            return _context.Pictures.FirstOrDefault(p => p.Id == id);
        }

        // Create One picture
        public void AddPicture(Picture picture)
        {
            _context.Pictures.Add(picture);
            _context.SaveChanges();
        }

        // Update a Picture
        public void UpdatePicture(Picture picture)
        {
            _context.Pictures.Update(picture);
            _context.SaveChanges();
        }

        // Delete a Picture
        public void PictureDelete(Picture picture)
        {
            if(picture == null)
            {
                throw new ArgumentNullException(nameof(picture));
            }
            _context.Pictures.Remove(picture);
            _context.SaveChanges();
        }
    }
    
}

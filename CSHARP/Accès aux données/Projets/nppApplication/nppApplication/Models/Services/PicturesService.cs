using Microsoft.EntityFrameworkCore;
using nppApplication.Models.Data;
using Org.BouncyCastle.Crypto.Paddings;

namespace nppApplication.Models.Services
{
    public class PicturesService
    {
        private readonly NppContext _context;

        public PicturesService(NppContext context)
        {
            _context = context;
        }

        // Read ALL
        public IEnumerable<Picture> GetAllPictures()
        {
            // ici l'include permet d'effectuer une jointure 
            return _context.Pictures.Include("Album").ToList();
        }

        // Read One Picture 
        public Picture GetPictureById(int id)
        {   
            // idem; l'include permet de faire une jointure. 
            return _context.Pictures.Include("Album").FirstOrDefault(p => p.Id == id);
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

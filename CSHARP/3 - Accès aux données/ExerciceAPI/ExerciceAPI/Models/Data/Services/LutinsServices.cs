using Microsoft.EntityFrameworkCore;
using System;

namespace ExerciceAPI.Models.Data.Services
{
    public class LutinsServices
    {
        private readonly ApiDbContext _context;
        public LutinsServices(ApiDbContext context)
        {
            _context = context;
        }

        public void AddLutin(Lutin l)
        {
            if (l == null)
            {
                throw new ArgumentNullException(nameof(l));
            }
            _context.Lutins.Add(l);
            _context.SaveChanges();
        }

        public void DeleteLutin(Lutin l)
        {
            if (l == null)
            {
                throw new ArgumentNullException(nameof(l));
            }
            _context.Lutins.Remove(l);
            _context.SaveChanges();
        }

        public IEnumerable<Lutin> GetAllLutins()
        {
            return _context.Lutins.ToList();
        }
        public Lutin GetLutinById(int id)
        {
            return _context.Lutins.FirstOrDefault(p => p.IdLutin == id);
        }
    
    }
}

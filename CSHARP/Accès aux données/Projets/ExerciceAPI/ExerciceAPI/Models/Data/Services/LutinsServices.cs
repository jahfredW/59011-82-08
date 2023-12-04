using Microsoft.EntityFrameworkCore;
using System;

namespace ExerciceAPI.Models.Data.Services
{
    /// <summary>
    ///     Classe ou Service qui récupère les informations en base de donnée.
    /// </summary>
    public class LutinsServices
    {
        private readonly ApiDbContext _context;

        /// <summary>
        ///     Constructeur
        /// </summary>
        /// <param name="context">Contexte des informations de la BDD</param>
        public LutinsServices(ApiDbContext context)
        {
            _context = context;
        }

        /// <summary>
        ///  Permet l'ajout d'un lutin en base de données
        /// </summary>
        /// <param name="l"></param>
        /// <exception cref="ArgumentNullException">Si body null exception levée</exception>
        public void AddLutin(Lutin l)
        {
            if (l == null)
            {
                throw new ArgumentNullException(nameof(l));
            }
            _context.Lutins.Add(l);
            _context.SaveChanges();
        }

        /// <summary>
        ///     Supprime un lutin de la base de donnée
        /// </summary>
        /// <param name="l"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void DeleteLutin(Lutin l)
        {
            if (l == null)
            {
                throw new ArgumentNullException(nameof(l));
            }
            _context.Lutins.Remove(l);
            _context.SaveChanges();
        }

       
        /// <summary>
        ///    méthode de récupération de tous les lutins  
        /// </summary>
        /// <returns>Collection of Lutins Object</returns>
        public IEnumerable<Lutin> GetAllLutins()
        {
            return _context.Lutins.ToList();
        }

        /// <summary>
        ///     Permet de récupérer un lutin en base de donnée
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Un Lutin object</returns>
        public Lutin GetLutinById(int id)
        {
            return _context.Lutins.FirstOrDefault(p => p.IdLutin == id);
        }

        /// <summary>
        /// Mets à jour un lutin en base de donnée 
        /// </summary>
        /// <param name="l"></param>
        public void UpdateLutin(Lutin l)
        {
            _context.Lutins.Update(l);
            _context.SaveChanges();
        }
    
    }
}

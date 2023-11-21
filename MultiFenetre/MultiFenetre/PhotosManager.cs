using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MultiFenetre
{
    static class PhotosManager
    {
        public static void AddAll(Photos photos)
        {
            Dto.AddAll(photos);
        }

        //public static Photos Update(Photos photos)
        //{
        //    return Dto.update(photos);
        //}

        //public static Photos Delete(Photos photos)
        //{
        //    return Dto.delete(photos);
        //}

        public static Photos GetOne(Photos photo)
        {
            return Dto.Get(photo);
        }

        public static List<Photos> getAll()
        {
 		
            return Dto.GetAll();
        }
    }
}

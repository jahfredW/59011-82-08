using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WpfAvecScaffold.Models.Data;
using WpfAvecScaffold.Models.DTOs;

namespace WpfAvecScaffold.Models.Profiles
{
    public class TypeDronesProfile : Profile
    {
        public TypeDronesProfile()
        {
            CreateMap<TypeDrone, TypeDronesDTO>();
            CreateMap<TypeDronesDTOIn, TypeDrone>();
            CreateMap<TypeDrone, TypeDronesDTOOut>();
        }
    }
}

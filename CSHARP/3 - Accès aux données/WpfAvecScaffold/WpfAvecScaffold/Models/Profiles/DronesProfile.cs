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
    public class DronesProfile : Profile
    {
        public DronesProfile() 
        {
            CreateMap<Drone, DronesDTO>();
            CreateMap<DronesDTOIn, Drone>();
            CreateMap<Drone, DronesDTOOut>().ForMember(dest => dest.LeTypeDeDrone, opt => opt.MapFrom(src => src.LeTypeDeDrone.Intitule));
        }
    }
}

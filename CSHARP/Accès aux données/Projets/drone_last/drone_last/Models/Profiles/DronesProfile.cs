using AutoMapper;
using drone_last.Models.Data;
using drone_last.Models.DTOs;

namespace drone_last.Models.Profiles
{
    public class DronesProfile : Profile
    {
        public DronesProfile()
        {
            CreateMap<Drone, DronesDTO>();
            CreateMap<DronesDTO, Drone>();
            CreateMap<DronesDTOin, Drone>();
            CreateMap<Drone, DronesDTOout>();

        }
    }
}



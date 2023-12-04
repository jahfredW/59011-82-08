using AutoMapper;
using drone_api.Models.Data;
using drone_api.Models.DTO;

namespace drone_api.Models.Profiles
{
    public class DronesProfile : Profile
    {
        public DronesProfile()
        {
            CreateMap<Drone, DronesDTO>().ForMember(dest => dest.TypeDrone, opt => opt.MapFrom(src => src.IdTypeDrone));
            CreateMap<DronesDTO, Drone>();
            CreateMap<DronesDTOWithSessions, Drone>();
            CreateMap<Drone, DronesDTOWithSessions>().ForMember(dest => dest.TypeDrone, opt => opt.MapFrom(src => src.IdTypeDrone));
            CreateMap<Drone, DronesDTOIn>();
            CreateMap<DronesDTOIn, Drone>().ForMember(dest => dest.;


        }
    }
}

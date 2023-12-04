using AutoMapper;
using drone_appli.Models.DTO;
using drone_appli.Models.Data;



namespace drone_appli.Models.Profiles
{
    public class DronesProfile : Profile
    {
        public DronesProfile()
        {
            CreateMap<Drone, DronesDTO>();
            CreateMap<DronesDTO, Drone>();
        }
        
    }
}

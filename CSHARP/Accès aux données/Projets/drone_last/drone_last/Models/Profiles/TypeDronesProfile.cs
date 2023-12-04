
using AutoMapper;
using drone_last.Models.Data;
using drone_last.Models.DTOs;

namespace drone_last.Models.Profiles
{
    public class TypeDronesProfile : Profile
    {
        public TypeDronesProfile()
        {
            CreateMap<TypeDrone, TypeDronesDTO>();
            CreateMap<TypeDronesDTO, TypeDrone>();
            CreateMap<TypeDronesDTOin, TypeDrone>();
            CreateMap<TypeDrone, TypeDronesDTOout>();

        }
    }
}



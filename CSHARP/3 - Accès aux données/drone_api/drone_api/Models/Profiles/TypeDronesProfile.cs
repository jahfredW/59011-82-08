
using AutoMapper;
using drone_api.Models.Data;
using drone_api.Models.DTO;

namespace drone_api.Models.Profiles
{
    public class TypeDronesProfile : Profile
    {

        public TypeDronesProfile()
        {
            CreateMap<TypeDrone, TypeDronesDTO>();
            CreateMap<TypeDronesDTO, TypeDrone>();

        }
    }
}


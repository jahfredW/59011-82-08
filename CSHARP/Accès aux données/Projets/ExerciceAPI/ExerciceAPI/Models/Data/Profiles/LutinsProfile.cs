using AutoMapper;
using ExerciceAPI.Models.Data.Dtos;

namespace ExerciceAPI.Models.Data.Profiles
{
    public class LutinsProfile : Profile
    {
        public LutinsProfile() {
            CreateMap<Lutin, LutinsDTO>();
            CreateMap<LutinsDTO, Lutin>();
        }
        

    }
}

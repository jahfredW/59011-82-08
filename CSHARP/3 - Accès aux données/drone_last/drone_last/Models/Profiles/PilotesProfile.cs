
using AutoMapper;
using drone_last.Models.Data;
using drone_last.Models.DTOs;

namespace drone_last.Models.Profiles
{
    public class PilotesProfile : Profile
    {
        public PilotesProfile()
        {
            CreateMap<Pilote, PilotesDTO>();
            CreateMap<PilotesDTO, Pilote>();
            CreateMap<PilotesDTOin, Pilote>();
            CreateMap<Pilote, PilotesDTOout>();

        }
    }
}



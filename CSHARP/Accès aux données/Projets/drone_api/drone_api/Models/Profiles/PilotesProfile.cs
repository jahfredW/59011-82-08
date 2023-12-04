using AutoMapper;
using drone_api.Models.Data;
using drone_api.Models.DTO;

namespace drone_api.Models.Profiles
{
    public class PilotesProfile : Profile
    {
        public PilotesProfile()
        {
            CreateMap<Pilote, PilotesDTO>();
            CreateMap<PilotesDTO, Pilote>();
            CreateMap<PilotesDTOWithoutSessions, Pilote>();
            CreateMap<Pilote, PilotesDTOWithoutSessions>();

        }
    }
}



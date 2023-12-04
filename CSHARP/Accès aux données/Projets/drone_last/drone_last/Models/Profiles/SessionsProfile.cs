
using AutoMapper;
using drone_last.Models.Data;
using drone_last.Models.DTOs;

namespace drone_last.Models.Profiles
{
    public class SessionsProfile : Profile
    {
        public SessionsProfile()
        {
            CreateMap<Session, SessionsDTO>();
            CreateMap<SessionsDTO, Session>();
            CreateMap<SessionsDTOin, Session>();
            CreateMap<Session, SessionsDTOin>();
            CreateMap<Session, SessionsDTOout>();
            CreateMap<Session, SessionsDTOoutSession>();

        }
    }
}


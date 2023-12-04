
using AutoMapper;
using drone_api.Models.Data;
using drone_api.Models.DTO;

namespace drone_api.Models.Profiles
{
    public class SessionsProfile : Profile
    {
        public SessionsProfile()
        {
            CreateMap<Session, SessionsDTO>();
            CreateMap<SessionsDTO, Session>();

        }
    }
}



using AutoMapper;
using nppApplication.Models.DTO;
using nppApplication.Models.Data;

namespace nppApplication.Models.Profiles
{ 
    
    public class AlbumsProfile : Profile
    {
    public AlbumsProfile()
    {
        CreateMap<Album, AlbumsDTO>();
        CreateMap<AlbumsDTO, Album>();

        }
    }
}

using AutoMapper;
using nppApplication.Models.DTO;
using nppApplication.Models.Data;


namespace nppApplication.Models.Profiles
{
    public class PicturesProfile : Profile
    {
        public PicturesProfile() 
        {
            CreateMap<Picture, PicturesDTO>();
            CreateMap<PicturesDTO, Picture>();
        }

    }
}

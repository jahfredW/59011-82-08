using AutoMapper;
using nppApplication.Models.DTO;
using nppApplication.Models.Data;


namespace nppApplication.Models.Profiles
{
    public class PicturesProfile : Profile
    {
        public PicturesProfile() 
        {
            // dest -> obj de destination, ici PicturesDTO
            // src -> obj source ici Picture
            // Pour remplir l'attribut AlbumName de Picture, utilise le nom de l'album correspondant à picture DTO
            CreateMap<Picture, PicturesDTO>().ForMember(dest => dest.AlbumName, opt => opt.MapFrom(src => src.Album.Name));
            CreateMap<PicturesDTO,Picture>();
            CreateMap<PicturesDTOWithAlbumDetails,Picture>();
            CreateMap<Picture , PicturesDTOWithAlbumDetails>();

        }

    }
}

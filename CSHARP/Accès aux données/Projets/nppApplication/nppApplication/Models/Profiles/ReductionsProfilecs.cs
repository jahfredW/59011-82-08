using nppApplication.Models.DTO;
using nppApplication.Models.Data;
using AutoMapper;

namespace nppApplication.Models.Profiles
{
    public class ReductionsProfile : Profile
    {
        public ReductionsProfile() 
        {
            CreateMap<Reduction, ReductionsDTO>();
            CreateMap<ReductionsDTO, Reduction>();
            CreateMap<OrderDTOWithoutOrderLineAndUser, Order>();
            CreateMap<Order, OrderDTOWithoutOrderLineAndUser>();
        }
    }
}

using AutoMapper;

namespace SoqiaGateApi.Profiles
{
    public class CustomerProfile : Profile
    {

        public CustomerProfile()
        {
            CreateMap<Entities.Customer, Models.CustomerDtoEmpty>();
            CreateMap<Entities.Customer, Models.CustomersDto>();
            CreateMap<Models.CustomerForCreation, Entities.Customer>();
            CreateMap<Models.CustomerForUpdate, Entities.Customer>();
            CreateMap<Entities.Customer, Models.CustomerForUpdate>();

        }
    }
}

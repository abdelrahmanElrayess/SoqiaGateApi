using AutoMapper;

namespace SoqiaGateApi.Profiles
{
    public class CustomerHouseProfile : Profile
    {
        public CustomerHouseProfile()
        {
            CreateMap<Entities.CustomerHouse, Models.CustomersHouseDto>();
            CreateMap<Models.CustomersHouseForCreation, Entities.CustomerHouse>();
            CreateMap<Models.CustomerHouseForUpdate, Entities.CustomerHouse>();
            CreateMap<Entities.CustomerHouse, Models.CustomerHouseForUpdate>();
            
           
        }



    }
}

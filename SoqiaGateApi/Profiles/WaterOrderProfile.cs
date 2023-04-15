using AutoMapper;

namespace SoqiaGateApi.Profiles
{
    public class WaterOrderProfile : Profile
    {
        public WaterOrderProfile()
        {
            CreateMap<Entities.WaterOrder, Models.WaterOrderDto>();
            CreateMap<Models.WaterOrderForCreation, Entities.WaterOrder>();
            CreateMap<Models.WaterOrderForUpdate, Entities.WaterOrder>();
            CreateMap<Entities.WaterOrder, Models.WaterOrderForUpdate>();

            

        }
    }
}

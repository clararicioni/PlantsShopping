using AutoMapper;
using PlantsShopping.ProductAPI.Data.ValueObjects;
namespace PlantsShopping.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PlantVO, Model.Plant>();
                cfg.CreateMap<Model.Plant, PlantVO>();
            }, null);

            return mappingConfig;
        }
    }
}
using AutoMapper;

namespace Mango.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(ConfigurationBinder =>
            {
                Config.CreateMap<ProductDto, Product>();
                Config.CreateMap<Product, ProductDto>();
            });

            return mappingConfig;
        }
    }
}

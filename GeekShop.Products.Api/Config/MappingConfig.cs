using AutoMapper;
using GeekShop.Products.Api.Data.ValueObjects;
using GeekShop.Products.Api.Model;

namespace GeekShop.Products.Api.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(x => {
                x.CreateMap<ProductVO, Product>();
                x.CreateMap<Product, ProductVO>();
            });

            return mappingConfig;
        }
    }
}

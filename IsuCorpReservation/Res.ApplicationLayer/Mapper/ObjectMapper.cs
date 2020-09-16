using Res.ApplicationLayer.Models;
using AutoMapper;
using System;
using Res.DomainLayer.Models;

namespace Res.ApplicationLayer.Mapper
{
    // The best implementation of AutoMapper for class libraries -> https://www.abhith.net/blog/using-automapper-in-a-net-core-class-library/
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<AspnetRunDtoMapper>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }

    public class AspnetRunDtoMapper : Profile
    {
        public AspnetRunDtoMapper()
        {
            CreateMap<Reserve, ReserveModel>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId)).ReverseMap();

            CreateMap<Customer, CustomerModel>().ReverseMap();

            CreateMap<CustomerType, CustomerTypeModel>().ReverseMap();
        }
    }
}

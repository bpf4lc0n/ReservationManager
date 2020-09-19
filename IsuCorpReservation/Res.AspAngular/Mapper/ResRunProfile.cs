
using AutoMapper;
using Res.ApplicationLayer.Models;
using Res.AspAngular.ViewModels;

namespace Res.AspAngular.Mapper
{
    public class ResRunProfile : Profile
    {
        public ResRunProfile()
        {
            CreateMap<ReserveModel, ReserveViewModel>();
            CreateMap<ReserveViewModel, ReserveModel>();

            CreateMap<CustomerModel, CustomerViewModel>();
            CreateMap<CustomerViewModel, CustomerModel>();

            CreateMap<CustomerTypeModel, CustomerTypeViewModel>();            
            CreateMap<CustomerTypeViewModel, CustomerTypeModel>();
            
        }
    }
}


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
            CreateMap<CustomerModel, CustomerViewModel>();
            CreateMap<CustomerTypeModel, CustomerTypeViewModel>();

            CreateMap<ReserveViewModel, ReserveModel>();
            CreateMap<CustomerTypeViewModel, CustomerTypeModel>();
            CreateMap<CustomerViewModel, CustomerModel>();
        }
    }
}

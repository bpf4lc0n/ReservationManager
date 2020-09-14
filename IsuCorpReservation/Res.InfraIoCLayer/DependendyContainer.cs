using Microsoft.Extensions.DependencyInjection;

using Res.ApplicationLayer.Interfaces;
using Res.ApplicationLayer.Services;
using Res.DomainLayer.Interfaces;
using Res.Infra.DataLayer.Repositories;

using System;
using System.Collections.Generic;
using System.Text;

namespace Res.InfraIoCLayer
{
    public class DependendyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application Layer
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<IReserveService, ReserveService>();

            // Infra Data Layer
            services.AddScoped<IRestaurantRepository, CustomerRespository>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IReserveRepository, ReserveRepository>();
        }
    }
}

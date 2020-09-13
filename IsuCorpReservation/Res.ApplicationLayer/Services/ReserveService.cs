using Abp.Application.Services;
using AutoMapper;
using Res.ApplicationLayer.Interfaces;
using Res.DomainLayer.Interfaces;
using Res.DomainLayer.Models;
using Res.Infra.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Res.ApplicationLayer.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ReserveService : ApplicationService, IReserveService
    {
        private readonly IReserveRepository _iReserveRepository;
        private readonly ICustomerRepository _iCustomerRepository;
        private readonly IRestaurantRepository _iRestaurantRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iReserveRepository"></param>
        /// <param name="customerRepository"></param>
        /// <param name="iRestaurantRepository"></param>
        public ReserveService(IReserveRepository iReserveRepository, ICustomerRepository customerRepository, IRestaurantRepository iRestaurantRepository)
        {
            _iReserveRepository = iReserveRepository;
            _iCustomerRepository = customerRepository;
            _iRestaurantRepository = iRestaurantRepository;
        }

        public void CreateReserve(CreateReserveInput input)
        {
            //We can use Logger, it's defined in ApplicationService class.
            Logger.Info("Creating a reserve for input: " + input);

            //Creating a new Reserve entity with given input's properties
            var reserve = new Reserve {
                DateReserve = input.DateReserve,
                CustomerId = input.CustomerId,
                RestaurantId = input.RestaurantId
            };

            //Saving entity with standard Insert method of repositories.
            _iReserveRepository.Add(reserve);
        }


        public GetReserveOutput GetReserve(GetReserveInput input)
        {
            //Called specific GetAllWithPeople method of reserve repository.
            var reserves = _iReserveRepository.GetReserveDetails(input.ReserveId);

            //Used AutoMapper to automatically convert List<reserve> to List<reserveDto>.
            return new GetReserveOutput
            {
                // with dto
                // reserves = Mapper.Map<List<ReserveDto>>(reserves)
                reserves = reserves
            };
        }

        public GetReserveOutput GetReserves()
        {
            var reserves = _iReserveRepository.GetAllReserveData();           
            return new GetReserveOutput
            {
                // if needed ... use AutoMapper to automatically convert List<reserve> to List<reserveDto>.
                // with dto
                // reserves = Mapper.Map<List<ReserveDto>>(reserves)
                reserves = reserves
            };
        }

        public void UpdateReserve(UpdateReserveInput input)
        {
            //Retrieving a reserve entity with given id using standard Get method of repositories.
            var reserve = _iReserveRepository.Get(input.ReserveId);

            reserve.DateReserve = input.DateReserve;
            reserve.FavoriteStatus = input.FavoriteStatus;
            reserve.Ranking = input.Ranking;

            //Updating changed properties of the retrieved reserve entity.
            if (input.CustomerId != 0)
            {
                reserve.Customer = _iCustomerRepository.Get(input.CustomerId);
            }

            if (input.RestaurantId != 0)
            {
                reserve.Restaurant = _iRestaurantRepository.Get(input.RestaurantId);
            }

            //We even do not call Update method of the repository.
            //Because an application service method is a 'unit of work' scope as default.
            //ABP automatically saves all changes when a 'unit of work' scope ends (without any exception).
        }
    }
}

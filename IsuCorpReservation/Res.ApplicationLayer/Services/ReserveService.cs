using Res.ApplicationLayer.Interfaces;
using Res.ApplicationLayer.Mapper;
using Res.ApplicationLayer.Models;
using Res.DomainLayer.Interfaces;
using Res.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Res.ApplicationLayer.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ReserveService : IReserveService
    {
        private readonly IReserveRepository _ReserveRepository;
        private readonly IAppLogger<ReserveService> _logger;

        public ReserveService(IReserveRepository ReserveRepository, IAppLogger<ReserveService> logger)
        {
            _ReserveRepository = ReserveRepository ?? throw new ArgumentNullException(nameof(ReserveRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<ReserveModel>> GetReserveList()
        {
            var ReserveList = await _ReserveRepository.GetReserveListAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ReserveModel>>(ReserveList);
            return mapped;
        }

        public async Task<ReserveModel> GetReserveById(int ReserveId)
        {
            var Reserve = await _ReserveRepository.GetByIdAsync(ReserveId);
            var mapped = ObjectMapper.Mapper.Map<ReserveModel>(Reserve);
            return mapped;
        }

        public async Task<ReserveModel> Create(ReserveModel ReserveModel)
        {
            await ValidateReserveIfExist(ReserveModel);

            var mappedEntity = ObjectMapper.Mapper.Map<Reserve>(ReserveModel);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newEntity = await _ReserveRepository.AddAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully added - AspnetRunAppService");

            var newMappedEntity = ObjectMapper.Mapper.Map<ReserveModel>(newEntity);
            return newMappedEntity;
        }

        public async Task Update(ReserveModel ReserveModel)
        {
            ValidateReserveIfNotExist(ReserveModel);

            var editReserve = await _ReserveRepository.GetByIdAsync(ReserveModel.Id);
            if (editReserve == null)
                throw new ApplicationException($"Entity could not be loaded.");

            ObjectMapper.Mapper.Map<ReserveModel, Reserve>(ReserveModel, editReserve);

            await _ReserveRepository.UpdateAsync(editReserve);
            _logger.LogInformation($"Entity successfully updated - AspnetRunAppService");
        }

        public async Task Delete(ReserveModel ReserveModel)
        {
            ValidateReserveIfNotExist(ReserveModel);
            var deletedReserve = await _ReserveRepository.GetByIdAsync(ReserveModel.Id);
            if (deletedReserve == null)
                throw new ApplicationException($"Entity could not be loaded.");

            await _ReserveRepository.DeleteAsync(deletedReserve);
            _logger.LogInformation($"Entity successfully deleted - AspnetRunAppService");
        }

        private async Task ValidateReserveIfExist(ReserveModel ReserveModel)
        {
            var existingEntity = await _ReserveRepository.GetByIdAsync(ReserveModel.Id);
            if (existingEntity != null)
                throw new ApplicationException($"{ReserveModel.ToString()} with this id already exists");
        }

        private void ValidateReserveIfNotExist(ReserveModel ReserveModel)
        {
            var existingEntity = _ReserveRepository.GetByIdAsync(ReserveModel.Id);
            if (existingEntity == null)
                throw new ApplicationException($"{ReserveModel.ToString()} with this id is not exists");
        }
    }
}

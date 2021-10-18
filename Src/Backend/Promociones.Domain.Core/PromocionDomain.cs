using System;
using Promociones.Domain.Entity;
using Promociones.Domain.Interface;
using Promociones.Infrastructure.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Promociones.Domain.Core
{
    public class PromocionDomain : IPromocionDomain
    {
        private readonly IPromocionRepository _promocionRepository;
        public PromocionDomain(IPromocionRepository promocionRepository)
        {
            _promocionRepository = promocionRepository;
        }

        public async Task<bool> InsertAsync(Promocion promocion)
        {
            return await _promocionRepository.InsertAsync(promocion);
        }

        public async Task<bool> UpdateAsync(Promocion promocion)
        {
            return await _promocionRepository.UpdateAsync(promocion);
        }

        public async Task<bool> DeleteAsync(int promocionId)
        {
            return await _promocionRepository.DeleteAsync(promocionId);
        }

        public async Task<Promocion> GetAsync(int promocionId)
        {
            return await _promocionRepository.GetAsync(promocionId);
        }

        public async Task<IEnumerable<Promocion>> GetAllAsync()
        {
            return await _promocionRepository.GetAllAsync();
        }
        public async Task<bool> CheckEmailAsync(string email)
        {
            return await _promocionRepository.CheckEmailAsync(email);
        }
        public async Task<bool> CheckCodigoAsync(string codigo)
        {
            return await _promocionRepository.CheckCodigoAsync(codigo);
        }
        public async Task<bool> CanjearCodigoAsync(Promocion promocion)
        {
            return await _promocionRepository.CanjearCodigoAsync(promocion);
        }
    }
}

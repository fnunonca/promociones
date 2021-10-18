using System.Collections.Generic;
using Promociones.Domain.Entity;
using System.Threading.Tasks;

namespace Promociones.Infrastructure.Interface
{
    public interface IPromocionRepository
    {
        Task<bool> InsertAsync(Promocion promocion);
        Task<bool> UpdateAsync(Promocion promocion);
        Task<bool> DeleteAsync(int promocionId);
        Task<Promocion> GetAsync(int promocionId);
        Task<IEnumerable<Promocion>> GetAllAsync();
        Task<bool> CheckEmailAsync(string email);
        Task<bool> CheckCodigoAsync(string codigo);
        Task<bool> CanjearCodigoAsync(Promocion promocion);
    }
}

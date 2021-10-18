using System;
using System.Collections.Generic;
using System.Text;
using Promociones.Application.DTO;
using Promociones.Transversal.Common;
using System.Threading.Tasks;

namespace Promociones.Application.Interface
{
    public interface IPromocionApplication
    {

        Task<Response<bool>> InsertAsync(PromocionDto promocion);
        Task<Response<bool>> UpdateAsync(PromocionDto promocion);
        Task<Response<bool>> DeleteAsync(int promocionId);
        Task<Response<PromocionDto>> GetAsync(int promocionId);
        Task<Response<List<PromocionDto>>> GetAllAsync();
        Task<Response<bool>> CanjearCodigoAsync(PromocionDto promocion);

    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Promociones.Application.DTO;
using Promociones.Application.Interface;
using System.Threading.Tasks;

namespace Promociones.Services.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PromocionController : Controller
    {
        private readonly IPromocionApplication _promocionApplication;
        public PromocionController(IPromocionApplication promocionApplication)
        {
            _promocionApplication = promocionApplication;
        }

        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] PromocionDto promocionDto)
        {
            if (promocionDto == null)
                return BadRequest();
            var response = await _promocionApplication.InsertAsync(promocionDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] PromocionDto promocionDto)
        {
            if (promocionDto == null)
                return BadRequest();
            var response = await _promocionApplication.UpdateAsync(promocionDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("DeleteAsync/{promocionId}")]
        public async Task<IActionResult> DeleteAsync(int promocionId)
        {
            var response = await _promocionApplication.DeleteAsync(promocionId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAsync/{promocionId}")]
        public async Task<IActionResult> GetAsync(int promocionId)
        {
            var response = await _promocionApplication.GetAsync(promocionId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _promocionApplication.GetAllAsync();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("CanjearCodigoAsync")]
        public async Task<IActionResult> CanjearCodigoAsync([FromBody] PromocionDto promocionDto)
        {
            if (promocionDto == null)
                return BadRequest();
            var response = await _promocionApplication.CanjearCodigoAsync(promocionDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
    }
}

using System;
using AutoMapper;
using Promociones.Application.DTO;
using Promociones.Application.Interface;
using Promociones.Domain.Entity;
using Promociones.Domain.Interface;
using Promociones.Transversal.Common;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Promociones.Application.Main
{
    public class PromocionApplication : IPromocionApplication
    {
        private readonly IPromocionDomain _promocionDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<PromocionApplication> _logger;
        public PromocionApplication(IPromocionDomain promocionDomain, IMapper mapper, IAppLogger<PromocionApplication> logger)
        {
            _promocionDomain = promocionDomain;
            _mapper = mapper;
            _logger = logger;
        }

        
        public async Task<Response<bool>> InsertAsync(PromocionDto promocionDto)
        {
            var response = new Response<bool>();
            try
            {
                var existeEmail = await _promocionDomain.CheckEmailAsync(promocionDto.email);

                if (existeEmail)
                {
                    response.IsSuccess = true;
                    response.Message = $"El correo {promocionDto.email} ya fue utilizado";
                    response.Data = false;
                }
                else
                {
                    var promocion = _mapper.Map<Promocion>(promocionDto);
                    promocion.usuarioModificacion = "fvasquez";
                    promocion.fechaModificacion = DateTime.Now;
                    promocion.estado = 0;
                    promocion.codigo = generarCodigo();
                    response.Data = await _promocionDomain.InsertAsync(promocion);
                    if (response.Data)
                    {
                        response.IsSuccess = true;
                        response.Message = promocion.codigo;
                    }
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        private string generarCodigo()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString("N").Substring(0, 7);
        }

        public async Task<Response<bool>> UpdateAsync(PromocionDto promocionDto)
        {
            var response = new Response<bool>();
            try
            {
                var promocion = _mapper.Map<Promocion>(promocionDto);
                promocion.usuarioModificacion = "fvasquez";
                promocion.fechaModificacion = DateTime.Now;
                response.Data = await _promocionDomain.UpdateAsync(promocion);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(int promocionId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _promocionDomain.DeleteAsync(promocionId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<PromocionDto>> GetAsync(int promocionId)
        {
            var response = new Response<PromocionDto>();
            try
            {
                var promocion = await _promocionDomain.GetAsync(promocionId);
                response.Data = _mapper.Map<PromocionDto>(promocion);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<List<PromocionDto>>> GetAllAsync()
        {
            var response = new Response<List<PromocionDto>>();
            try
            {
                var promociones = await _promocionDomain.GetAllAsync();
                var promocionesDto = _mapper.Map<List<PromocionDto>>(promociones);
                promocionesDto.ForEach(x => x.estadoDescripcion = establecerEstado(x.estado));
                response.Data = promocionesDto;
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> CanjearCodigoAsync(PromocionDto promocionDto)
        {
            var response = new Response<bool>();
            try
            {
                var codigoCanjeado = await _promocionDomain.CheckCodigoAsync(promocionDto.codigo);
                if (codigoCanjeado)
                {
                    response.IsSuccess = true;
                    response.Message = $"El codigo {promocionDto.codigo} ya fue canjeado";
                }
                else
                {
                    var promocion = _mapper.Map<Promocion>(promocionDto);
                    promocion.estado = 1;
                    promocion.usuarioModificacion = "fvasquez";
                    promocion.fechaModificacion = DateTime.Now;
                    response.Data = await _promocionDomain.CanjearCodigoAsync(promocion);
                    if (response.Data)
                    {
                        response.IsSuccess = true;
                        response.Message = "Canje Exitoso!";
                    }
                }

            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        private string establecerEstado(int estado)
        {
            string descripcion = estado == 0 ? "Generado" : "Canjeado";
            return descripcion;
        }
    }
}

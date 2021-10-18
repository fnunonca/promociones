using System;
using Promociones.Domain.Entity;
using Promociones.Infrastructure.Interface;
using Promociones.Transversal.Common;
using Dapper;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Promociones.Infrastructure.Repository
{
    public class PromocionRepository : IPromocionRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public PromocionRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> InsertAsync(Promocion promocion)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "promocionInsert";
                var parameters = new DynamicParameters();
                parameters.Add("nombre", promocion.nombre);
                parameters.Add("email", promocion.email);
                parameters.Add("estado", promocion.estado);
                parameters.Add("codigo", promocion.codigo);
                parameters.Add("usuarioModificacion", promocion.usuarioModificacion);
                parameters.Add("fechaModificacion", promocion.fechaModificacion);

                var result = await connection.QuerySingleAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Promocion promocion)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "promocionUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("id", promocion.id);
                parameters.Add("nombre", promocion.nombre);
                parameters.Add("email", promocion.email);
                parameters.Add("estado", promocion.estado);
                parameters.Add("codigo", promocion.codigo);
                parameters.Add("usuarioModificacion", promocion.usuarioModificacion);
                parameters.Add("fechaModificacion", promocion.fechaModificacion);

                var result = await connection.QuerySingleAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(int promocionId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "promocionDelete";
                var parameters = new DynamicParameters();
                parameters.Add("id", promocionId);
                var result = await connection.QuerySingleAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<Promocion> GetAsync(int promocionId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "promocionByID";
                var parameters = new DynamicParameters();
                parameters.Add("id", promocionId);

                var customer = await connection.QuerySingleAsync<Promocion>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }

        public async Task<IEnumerable<Promocion>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "promocionQuery";
                var parameters = new DynamicParameters();
                parameters.Add("email", string.Empty);
                parameters.Add("nombre", string.Empty);
                var promociones = await connection.QueryAsync<Promocion>(
                    query, 
                    param: parameters, 
                    commandType: CommandType.StoredProcedure);
                
                return promociones;
            }
        }


        public async Task<bool> CheckEmailAsync(string email)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "promocionCheckEmail";
                var parameters = new DynamicParameters();
                parameters.Add("email", email);
                var result = await connection.QuerySingleAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public async Task<bool> CheckCodigoAsync(string codigo)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "promocionCheckCodigo";
                var parameters = new DynamicParameters();
                parameters.Add("codigo", codigo);
                var result = await connection.QuerySingleAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> CanjearCodigoAsync(Promocion promocion)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "promocionCanjearCodigo";
                var parameters = new DynamicParameters();
                parameters.Add("estado", promocion.estado);
                parameters.Add("codigo", promocion.codigo);
                parameters.Add("usuarioModificacion", promocion.usuarioModificacion);
                parameters.Add("fechaModificacion", promocion.fechaModificacion);

                var result = await connection.QuerySingleAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
    }
}

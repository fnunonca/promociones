using System;

namespace Promociones.Application.DTO
{
    public class PromocionDto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public int estado { get; set; }
        public string? estadoDescripcion { get; set; }
        public string codigo { get; set; }
    }
}

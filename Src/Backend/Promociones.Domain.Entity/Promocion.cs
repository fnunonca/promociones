using System;

namespace Promociones.Domain.Entity
{
    public class Promocion
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string codigo { get; set; }
        public int estado { get; set; }
        public string usuarioModificacion { get; set; }
        public DateTime fechaModificacion { get; set; }
    }
}

using System;

namespace EntityLayer
{
    public class EPedido
    {
        public int IdPedido { get; set; }
        public int IdFactura { get; set; }
        public string FechaEntrega { get; set; }
        public string DireccionAdicional { get; set; }
        public int IdEstado { get; set; }
    }
}

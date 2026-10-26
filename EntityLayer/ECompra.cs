using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer
{
    public class ECompra
    {
        public int IdCompra { get; set; }
        public int IdProveedor { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal DescuentoFactura { get; set; }
        public decimal TotalMonto { get; set; }
        public string EstadoPago { get; set; }

    }
}

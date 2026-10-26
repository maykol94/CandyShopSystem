using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer
{
    public class EDetalleCompra
    {
        public int IdDetalleCompra { get; set; }
        public int IdCompra { get; set; }
        public int IdVariacion { get; set; }
        public int CantidadCompra { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal DescuentoUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}

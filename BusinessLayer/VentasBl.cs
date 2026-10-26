using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class VentasBl
    {
        private VentasDal objVentasDal = new VentasDal();

        public async Task<(bool Exito, string Mensaje)> RegistrarVentaAsync(EFactura factura, List<EDetalleFactura> carrito)
        {
            if (factura == null) return (false, "La factura no contiene datos.");
            if (factura.IdCliente <= 0) return (false, "Seleccione un cliente válido.");
            if (factura.IdTrabajador <= 0) return (false, "Credenciales de trabajador inválidas.");
            if (carrito == null || carrito.Count == 0) return (false, "El carrito de ventas está vacío.");

            foreach (var item in carrito)
            {
                if (item.IdVariacion <= 0) return (false, "Un producto en el carrito tiene un ID de variación inválido.");
                if (item.Cantidad <= 0) return (false, "La cantidad a vender debe ser mayor a cero.");
            }

            return await objVentasDal.RegistrarVentaAsync(factura, carrito);
        }
    }
}
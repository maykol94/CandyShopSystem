using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class VentasBl
    {
        private VentasDal objVentasDal = new VentasDal();

        public async Task<(bool Exito, string Mensaje, int IdFactura)> RegistrarVentaAsync(EFactura objFactura, List<EDetalleFactura> oDetalle)
        {
            if (objFactura.IdCliente <= 0)
            {
                return (false, "Debe seleccionar un cliente válido.", 0);
            }

            if (oDetalle == null || oDetalle.Count == 0)
            {
                return (false, "El detalle de la venta no puede estar vacío.", 0);
            }

            return await objVentasDal.RegistrarVentaAsync(objFactura, oDetalle);
        }
    }
}
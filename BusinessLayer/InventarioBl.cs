using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class InventarioBl
    {
        private InventarioDal objInventarioDal = new InventarioDal();

        public async Task<List<EInventario>> ObtenerInventarioAsync()
        {
            return await objInventarioDal.ObtenerInventarioAsync();
        }

        public async Task<(bool Exito, string Mensaje)> AjustarStockAsync(int idStock, int cantidadCambio)
        {
            // Validamos e indicamos al usuario que debe ir al módulo de compras
            if (idStock <= 0)
            {
                return (false, "Este producto no tiene historial. Ve al módulo de 'compra' para registrar su primer ingreso con su lote, precios y fechas.");
            }

            if (cantidadCambio == 0) return (false, "La cantidad a cambiar no puede ser cero.");

            return await objInventarioDal.AjustarStockAsync(idStock, cantidadCambio);
        }

        public async Task<(bool Exito, string Mensaje)> EliminarStockAsync(int idStock)
        {
            if (idStock <= 0) return (false, "El ID de stock no es válido.");
            return await objInventarioDal.EliminarStockAsync(idStock);
        }
    }
}
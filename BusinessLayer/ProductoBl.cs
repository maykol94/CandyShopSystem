using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DataAccessLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class ProductoBl
    {
        private ProductoDal objProductoDal = new ProductoDal();

        public async Task<List<EProducto>> ObtenerProductosAsync()
        {
            return await objProductoDal.ObtenerProductosAsync();
        }

        public async Task<DataSet> ObtenerCatalogosProductoAsync()
        {
            return await objProductoDal.ObtenerCatalogosProductoAsync();
        }

        public async Task<(bool Exito, string Mensaje)> GuardarProductoAsync(EProducto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.NombreProducto))
            {
                return (false, "El nombre del producto no puede estar vacío.");
            }

            if (producto.IdCategoria <= 0)
            {
                return (false, "Debe seleccionar una categoría válida.");
            }

            if (producto.IdTipoProducto <= 0)
            {
                return (false, "Debe seleccionar un tipo de producto válido.");
            }

            return await objProductoDal.GuardarProductoAsync(producto);
        }

        public async Task<(bool Exito, string Mensaje)> EliminarProductoAsync(int idProducto)
        {
            return await objProductoDal.EliminarProductoAsync(idProducto);
        }
    }
}
using DataAccessLayer;
using EntityLayer;
using System.Collections.Generic;
using System.Data;

namespace BusinessLayer
{
    public class ProductoBl
    {
        private ProductoDal objProductoDal = new ProductoDal();

        public List<EProducto> ObtenerProductos()
        {
            return objProductoDal.ObtenerProductos();
        }

        public bool RegistrarProducto(EProducto obj, out string mensaje)
        {
            return objProductoDal.RegistrarProducto(obj, out mensaje);
        }

        public bool EditarProducto(EProducto obj, out string mensaje)
        {
            return objProductoDal.EditarProducto(obj, out mensaje);
        }

        public bool EliminarProducto(int idProducto, out string mensaje)
        {
            return objProductoDal.EliminarProducto(idProducto, out mensaje);
        }

        public DataTable ObtenerCategoriasCombo() => objProductoDal.ObtenerCategoriasCombo();
        public DataTable ObtenerMarcasCombo() => objProductoDal.ObtenerMarcasCombo();
        public DataTable ObtenerTiposProductoCombo() => objProductoDal.ObtenerTiposProductoCombo();
    }
}
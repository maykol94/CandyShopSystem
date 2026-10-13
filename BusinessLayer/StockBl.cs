using System.Collections.Generic;
using DataAccessLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class StockBl
    {
        private StockDal objStockDal = new StockDal();

        public List<EInventario> ObtenerInventario()
        {
            return objStockDal.ObtenerInventario();
        }

        public bool AjustarStock(int idStock, int cambio, out string mensaje)
        {
            mensaje = string.Empty;

            if (idStock <= 0)
            {
                mensaje = "Identificador de stock no válido.";
                return false;
            }

            if (cambio != 1 && cambio != -1)
            {
                mensaje = "El ajuste de existencias solo puede ser incremento (+1) o decremento (-1).";
                return false;
            }

            return objStockDal.AjustarStock(idStock, cambio, out mensaje);
        }
    }
}

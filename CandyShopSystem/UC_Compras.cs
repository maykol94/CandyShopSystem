using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace CandyShopSystem
{
    public partial class UC_Compras : UserControl
    {

        private CompraBl objCompraBl;

        public UC_Compras()
        {
            InitializeComponent();
            dbvCompras.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dbvCompras.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dbvCompras.DefaultCellStyle.SelectionForeColor = Color.Black;
            objCompraBl = new CompraBl();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UC_Compras_Load(object sender, EventArgs e)
        {
            CargarCompras();
        }

        private void dbvCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si hicieron clic en la columna del botón
            if (e.ColumnIndex == dbvCompras.Columns["colCambiarEstado"].Index && e.RowIndex >= 0)
            {
                // Obtener datos de la fila
                int idCompra = Convert.ToInt32(dbvCompras.Rows[e.RowIndex].Cells["colIdCompra"].Value);
                string estadoActual = dbvCompras.Rows[e.RowIndex].Cells["colEstadoPago"].Value.ToString();

                // Determinar el nuevo estado (comparación sin importar mayúsculas/minúsculas)
                string nuevoEstado;
                if (estadoActual.Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
                {
                    nuevoEstado = "Pagado al contado";
                }
                else
                {
                    nuevoEstado = "Pendiente";
                }

                // Confirmar con el usuario
                DialogResult resultado = MessageBox.Show(
                    $"¿Desea cambiar el estado de la compra #{idCompra} de '{estadoActual}' a '{nuevoEstado}'?",
                    "Confirmar cambio",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    string respuesta = objCompraBl.CambiarEstadoCompra(idCompra, nuevoEstado);

                    if (respuesta == "OK")
                    {
                        MessageBox.Show("Estado actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCompras();
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar: " + respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CargarCompras()
        {
            DataTable dt = objCompraBl.ObtenerCompras();
            dbvCompras.DataSource = dt;
        }

        private void btnNuevaCompra_Click(object sender, EventArgs e)
        {
            FormRegistroCompra frm = new FormRegistroCompra();

            
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarCompras();
            }
        }
    }
}

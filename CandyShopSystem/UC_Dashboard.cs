using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CandyShopSystem
{
    public partial class UC_Dashboard : UserControl
    {
        public UC_Dashboard()
        {
            InitializeComponent();
            CargarVentasPruebas();
        }
        private void CargarVentasPruebas()
        {
            dgvUltimasVentas.ClearSelection();

            // Desbloquear y fijar la altura del encabezado
            dgvUltimasVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvUltimasVentas.ColumnHeadersHeight = 35;

            // Limpiar y definir columnas
            dgvUltimasVentas.Columns.Clear();
            dgvUltimasVentas.Columns.Add("id", "N° Venta");
            dgvUltimasVentas.Columns.Add("cliente", "Cliente / Pulpería");
            dgvUltimasVentas.Columns.Add("total", "Total");
            dgvUltimasVentas.Columns.Add("fecha", "Hora / Fecha");

            //desctiva el orden de las columnas
            foreach (DataGridViewColumn col in dgvUltimasVentas.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            //registro de prueba
            dgvUltimasVentas.Rows.Add("1", "María López", "C$ 150.00", "Hoy, 10:30 AM");
            dgvUltimasVentas.Rows.Add("2", "Juan Pérez", "C$ 85.50", "Hoy, 11:15 AM");
            dgvUltimasVentas.Rows.Add("3", "Pulpería El Rosario", "C$ 420.00", "Hoy, 12:00 PM");
            dgvUltimasVentas.Rows.Add("4", "Distribuidora San José", "C$ 1,200.00", "Hoy, 01:45 PM");

            // Formato visual de la tabla
            dgvUltimasVentas.EnableHeadersVisualStyles = false;
            dgvUltimasVentas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 235, 243);
            dgvUltimasVentas.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(70, 70, 70);
            dgvUltimasVentas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            // Filas intercaladas y selección limpia
            dgvUltimasVentas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            dgvUltimasVentas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 210, 228);
            dgvUltimasVentas.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Quitar la selección azul inicial al cargar
            dgvUltimasVentas.ClearSelection();
        }
    }
}

using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;

namespace CandyShopSystem
{
    public partial class UC_Reportes : UserControl
    {
        private ReporteDAL reporteDAL = new ReporteDAL();

        public UC_Reportes()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(253, 246, 248);
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);

            this.Load += UC_Reportes_Load;
            this.Resize += UC_Reportes_Resize;
        }

        private async void UC_Reportes_Load(object sender, EventArgs e)
        {
            RedimensionarYEstirarControles();
            EstilarGrids();
            await CargarReportesAsync();
        }

        private void UC_Reportes_Resize(object sender, EventArgs e)
        {
            RedimensionarYEstirarControles();
        }

        private void RedimensionarYEstirarControles()
        {
            this.Dock = DockStyle.Fill;
            if (this.Parent != null)
            {
                this.Size = this.Parent.ClientSize;
            }

            int anchoDisponible = this.ClientSize.Width - 40;
            if (anchoDisponible <= 0) return;

            // Ajustar el contenedor de Ventas del Día para que ocupe todo el ancho
            Control pnlVentasDia = BuscarControlPorNombre(this, "pnlVentasDia") ?? BuscarControlPorNombre(this, "panelVentasDia");
            if (pnlVentasDia != null)
            {
                pnlVentasDia.Left = 20;
                pnlVentasDia.Width = anchoDisponible;
            }

            // Ajustar el contenedor de Ventas Recientes para que ocupe todo el ancho
            Control pnlRecientes = BuscarControlPorNombre(this, "pnlVentasRecientes") ?? BuscarControlPorNombre(this, "panelVentasRecientes");
            if (pnlRecientes != null)
            {
                pnlRecientes.Left = 20;
                pnlRecientes.Width = anchoDisponible;
            }

            // Asegurarnos de que los DataGridViews se estiren dentro de sus paneles
            DataGridView[] grids = new DataGridView[]
            {
                BuscarControlPorNombre(this, "dgvVentasDia") as DataGridView,
                BuscarControlPorNombre(this, "dgvFacturas") as DataGridView
            };

            foreach (var dgv in grids)
            {
                if (dgv != null)
                {
                    dgv.Dock = DockStyle.Fill;
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }

        private async Task CargarReportesAsync()
        {
            try
            {
                DataTable dtDia = await Task.Run(() => reporteDAL.ObtenerVentasDelDia());
                DataTable dtRecientes = await Task.Run(() => reporteDAL.ObtenerVentasRecientes());

                AsignarTablaGrid("dgvVentasDia", dtDia);
                AsignarTablaGrid("dgvFacturas", dtRecientes);

                FormatearColumnasGrids();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los reportes: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EstilarGrids()
        {
            DataGridView[] grids = new DataGridView[]
            {
                BuscarControlPorNombre(this, "dgvVentasDia") as DataGridView,
                BuscarControlPorNombre(this, "dgvFacturas") as DataGridView
            };

            foreach (var dgv in grids)
            {
                if (dgv != null)
                {
                    dgv.BackgroundColor = Color.White;
                    dgv.BorderStyle = BorderStyle.None;
                    dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                    dgv.GridColor = Color.FromArgb(245, 240, 243);
                    dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgv.ReadOnly = true;
                    dgv.AllowUserToAddRows = false;
                    dgv.RowHeadersVisible = false;
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    dgv.EnableHeadersVisualStyles = false;
                    dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(253, 242, 244);
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(190, 46, 95);
                    dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                    dgv.ColumnHeadersHeight = 35;

                    dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 226, 233);
                    dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(190, 46, 95);
                    dgv.DefaultCellStyle.ForeColor = Color.FromArgb(70, 70, 80);
                    dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.0F);
                    dgv.RowTemplate.Height = 38;
                }
            }
        }

        private void FormatearColumnasGrids()
        {
            // Formato para la tabla de Ventas Recientes (alinear montos a la derecha si existe la columna)
            var dgvFacturas = BuscarControlPorNombre(this, "dgvFacturas") as DataGridView;
            if (dgvFacturas != null && dgvFacturas.Columns.Count > 0)
            {
                if (dgvFacturas.Columns["monto_total"] != null)
                {
                    dgvFacturas.Columns["monto_total"].DefaultCellStyle.Format = "C$ #,##0.00";
                    dgvFacturas.Columns["monto_total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }

            // Formato para la tabla de Ventas del Día
            var dgvDia = BuscarControlPorNombre(this, "dgvVentasDia") as DataGridView;
            if (dgvDia != null && dgvDia.Columns.Count > 0)
            {
                if (dgvDia.Columns["monto_total"] != null)
                {
                    dgvDia.Columns["monto_total"].DefaultCellStyle.Format = "C$ #,##0.00";
                    dgvDia.Columns["monto_total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private void AsignarTablaGrid(string nombre, DataTable dt)
        {
            Control ctrl = BuscarControlPorNombre(this, nombre);
            if (ctrl is DataGridView dgv)
            {
                dgv.DataSource = dt;
            }
        }

        private Control BuscarControlPorNombre(Control contenedor, string nombre)
        {
            if (contenedor == null) return null;
            if (string.Equals(contenedor.Name, nombre, StringComparison.OrdinalIgnoreCase)) return contenedor;

            foreach (Control hijo in contenedor.Controls)
            {
                Control encontrado = BuscarControlPorNombre(hijo, nombre);
                if (encontrado != null) return encontrado;
            }

            return null;
        }
    }
}
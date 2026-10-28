using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using EntityLayer;

namespace CandyShopSystem
{
    public partial class UC_Dashboard : UserControl
    {
        private HomeBl objHomeBl = new HomeBl();

        public UC_Dashboard()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(253, 246, 248);
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);

            this.Load += UC_Dashboard_Load;
            this.Resize += UC_Dashboard_Resize;
        }

        private async void UC_Dashboard_Load(object sender, EventArgs e)
        {
            RedimensionarYEstirarControles();
            EstilarGrids();
            await CargarDatosDashboardAsync();
        }

        private void UC_Dashboard_Resize(object sender, EventArgs e)
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

            int anchoTarjeta = (anchoDisponible - 30) / 4;
            string[] tarjetas = { "pnlCardClientes", "pnlCardProductos", "pnlCardVentas", "pnlCardPedidos" };
            int xActual = 20;

            foreach (string nombreCard in tarjetas)
            {
                Control pnl = BuscarControlPorNombre(this, nombreCard);
                if (pnl != null)
                {
                    pnl.Left = xActual;
                    pnl.Width = anchoTarjeta;
                    xActual += anchoTarjeta + 10;
                }
            }

            Control pnlVentas = BuscarControlPorNombre(this, "pnlVentasRecientes");
            if (pnlVentas != null)
            {
                pnlVentas.Left = 20;
                pnlVentas.Width = anchoDisponible;
            }

            Control pnlMasVendidos = BuscarControlPorNombre(this, "pnlProductosMasVendidos");
            if (pnlMasVendidos != null)
            {
                pnlMasVendidos.Left = 20;
                pnlMasVendidos.Width = anchoDisponible;
            }

            DataGridView[] grids = new DataGridView[]
            {
                BuscarControlPorNombre(this, "dgvVentasRecientes") as DataGridView,
                BuscarControlPorNombre(this, "dgvProductosMasVendidos") as DataGridView
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

        private async Task CargarDatosDashboardAsync()
        {
            try
            {
                EDashboard datos = await Task.Run(() => objHomeBl.ObtenerTotalesDashboard());
                DataTable dtVentas = await Task.Run(() => objHomeBl.ObtenerVentasRecientes());
                DataTable dtMasVendidos = await Task.Run(() => objHomeBl.ObtenerProductosMasVendidos());

                AsignarTextoLabel("lblTotalClientes", datos.TotalClientes.ToString());
                AsignarTextoLabel("lblTotalProductos", datos.TotalProductos.ToString());

                AsignarTextoLabel("lblVentasHoy", string.Format("C$ {0:N2}", datos.VentasHoy));

                AsignarTextoLabel("lblPedidosPendientesCard", datos.PedidosPendientes.ToString());
                AsignarTextoLabel("lblStockDisponible", datos.StockDisponible.ToString());
                AsignarTextoLabel("lblPorReponer", datos.PorReponer.ToString());
                AsignarTextoLabel("lblPedidosPendientesResumen", datos.PedidosPendientes.ToString());
                AsignarTablaGrid("dgvVentasRecientes", dtVentas);
                AsignarTablaGrid("dgvProductosMasVendidos", dtMasVendidos);

                FormatearColumnasGrids();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del Dashboard: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EstilarGrids()
        {
            DataGridView[] grids = new DataGridView[]
            {
                BuscarControlPorNombre(this, "dgvVentasRecientes") as DataGridView,
                BuscarControlPorNombre(this, "dgvProductosMasVendidos") as DataGridView
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
            // Ventas Recientes
            var dgvVentas = BuscarControlPorNombre(this, "dgvVentasRecientes") as DataGridView;
            if (dgvVentas != null && dgvVentas.Columns.Count > 0)
            {
                if (dgvVentas.Columns["TOTAL"] != null)
                {
                    // Formato explícito para Córdobas (C$ #,##0.00) en la grilla
                    dgvVentas.Columns["TOTAL"].DefaultCellStyle.Format = "C$ #,##0.00";
                    dgvVentas.Columns["TOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (dgvVentas.Columns["FECHA"] != null)
                {
                    dgvVentas.Columns["FECHA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

            // Productos más Vendidos
            var dgvMasVendidos = BuscarControlPorNombre(this, "dgvProductosMasVendidos") as DataGridView;
            if (dgvMasVendidos != null && dgvMasVendidos.Columns.Count > 0)
            {
                if (dgvMasVendidos.Columns["CANTIDAD"] != null)
                {
                    dgvMasVendidos.Columns["CANTIDAD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void AsignarTextoLabel(string nombre, string texto)
        {
            Control ctrl = BuscarControlPorNombre(this, nombre);
            if (ctrl != null)
            {
                ctrl.Text = texto;
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
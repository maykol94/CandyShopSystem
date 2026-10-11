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
    public partial class UC_Stock : UserControl
    {
        private BindingSource bindingSourceStock = new BindingSource();
        private DataTable tablaStock = new DataTable();

        private Panel panelAlerta;
        private Label lblAlertaTexto;

        public UC_Stock()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(248, 249, 253);

            this.AutoSize = false;
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);

            ConstruirBarraAlerta();
            EstilarGrid();

            this.Load += UC_Stock_Load;
            this.Resize += UC_Stock_Resize;
        }

        private void ConstruirBarraAlerta()
        {
            // Panel de alerta si hay productos con stock menor o igual al mínimo
            panelAlerta = new Panel();
            panelAlerta.BackColor = Color.FromArgb(254, 243, 199);
            panelAlerta.Height = 45;
            panelAlerta.Dock = DockStyle.Top;
            panelAlerta.Padding = new Padding(15, 0, 0, 0);

            lblAlertaTexto = new Label();
            lblAlertaTexto.ForeColor = Color.FromArgb(146, 64, 14);
            lblAlertaTexto.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAlertaTexto.Dock = DockStyle.Fill;
            lblAlertaTexto.TextAlign = ContentAlignment.MiddleLeft;
            lblAlertaTexto.Text = " Hay productos con existencias iguales o menores al mínimo. Revisa las alertas destacadas.";

            panelAlerta.Controls.Add(lblAlertaTexto);
            this.Controls.Add(panelAlerta);
            panelAlerta.BringToFront();

            //para ubicar el grid debajo de la alerta
            PosicionarGridAbajoDeAlerta();
        }

        private void PosicionarGridAbajoDeAlerta()
        {
            if (dgvStock != null && panelAlerta != null)
            {
                dgvStock.Dock = DockStyle.None; // Desactivar dock temporalmente para ubicarlo con coordenadas
                dgvStock.Top = panelAlerta.Bottom + 10; // 10 píxeles de separación debajo de la alerta
                dgvStock.Left = 15;
                dgvStock.Width = this.ClientRectangle.Width - 30;
                dgvStock.Height = this.ClientRectangle.Height - panelAlerta.Bottom - 20;
                dgvStock.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
        }

        private async void UC_Stock_Load(object sender, EventArgs e)
        {
            AjustarAnchoAContenedor();
            VincularEventos();
            await CargarTablaStockAsync();
        }

        private void VincularEventos()
        {
            Control txtB = BuscarControlPorNombre(this, "txtBuscar") ?? BuscarControlPorNombre(this, "txtBuscarInventario");
            if (txtB != null)
            {
                txtB.TextChanged -= FiltrarTabla;
                txtB.TextChanged += FiltrarTabla;
            }

            if (dgvStock != null)
            {
                dgvStock.CellContentClick -= dgvStock_CellContentClick;
                dgvStock.CellContentClick += dgvStock_CellContentClick;

                dgvStock.CellPainting -= dgvStock_CellPainting;
                dgvStock.CellPainting += dgvStock_CellPainting;
            }
        }

        private void UC_Stock_Resize(object sender, EventArgs e)
        {
            AjustarAnchoAContenedor();
            PosicionarGridAbajoDeAlerta();
        }

        private void AjustarAnchoAContenedor()
        {
            this.Dock = DockStyle.Fill;
            if (this.Parent != null)
            {
                this.Size = this.Parent.ClientSize;
            }
        }

        private void EstilarGrid()
        {
            if (dgvStock == null) return;

            dgvStock.BackgroundColor = Color.White;
            dgvStock.BorderStyle = BorderStyle.None;
            dgvStock.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvStock.GridColor = Color.FromArgb(245, 240, 243);
            dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStock.ReadOnly = true;

            // Elimina la fila en blanco extra al final de la tabla
            dgvStock.AllowUserToAddRows = false;

            dgvStock.RowHeadersVisible = false;
            dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvStock.EnableHeadersVisualStyles = false;
            dgvStock.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvStock.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(253, 242, 244);
            dgvStock.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(190, 46, 95);
            dgvStock.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvStock.ColumnHeadersHeight = 42;

            dgvStock.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dgvStock.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);

            dgvStock.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 226, 233);
            dgvStock.DefaultCellStyle.SelectionForeColor = Color.FromArgb(190, 46, 95);
            dgvStock.DefaultCellStyle.ForeColor = Color.FromArgb(70, 70, 80);
            dgvStock.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvStock.RowTemplate.Height = 42;
        }

        public async Task CargarTablaStockAsync()
        {
            try
            {
                tablaStock = await Task.Run(() => ObtenerDatosPrueba());

                bindingSourceStock.DataSource = tablaStock;
                dgvStock.DataSource = null;
                dgvStock.DataSource = bindingSourceStock;

                AgregarColumnasBotonesAjuste();
                AjustarColumnasGrid();
                ActualizarAlertaStock();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar inventario: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ObtenerDatosPrueba()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id_stock", typeof(int));
            dt.Columns.Add("producto", typeof(string));
            dt.Columns.Add("categoria", typeof(string));
            dt.Columns.Add("stock_actual", typeof(int));
            dt.Columns.Add("minimo", typeof(int));
            dt.Columns.Add("estado", typeof(string));

            dt.Rows.Add(1, "Caramelos surtidos", "Caramelos", 58, 25, "Disponible");
            dt.Rows.Add(2, "Chupetas", "Chupetas", 18, 25, "Reponer");
            dt.Rows.Add(3, "Gomitas", "Gomitas", 43, 20, "Disponible");
            dt.Rows.Add(4, "Chocolates en barra", "Chocolates", 12, 20, "Reponer");
            dt.Rows.Add(5, "Malvaviscos", "Dulces", 34, 15, "Disponible");
            return dt;
        }

        private void AgregarColumnasBotonesAjuste()
        {
            if (dgvStock.Columns["btnMenos"] == null)
            {
                DataGridViewButtonColumn btnMenos = new DataGridViewButtonColumn();
                btnMenos.Name = "btnMenos";
                btnMenos.HeaderText = "";
                btnMenos.Text = "—";
                btnMenos.UseColumnTextForButtonValue = true;
                btnMenos.Width = 40;
                dgvStock.Columns.Add(btnMenos);
            }

            if (dgvStock.Columns["btnMas"] == null)
            {
                DataGridViewButtonColumn btnMas = new DataGridViewButtonColumn();
                btnMas.Name = "btnMas";
                btnMas.HeaderText = "";
                btnMas.Text = "+";
                btnMas.UseColumnTextForButtonValue = true;
                btnMas.Width = 40;
                dgvStock.Columns.Add(btnMas);
            }
        }

        private void AjustarColumnasGrid()
        {
            if (dgvStock.Columns.Count > 0)
            {
                if (dgvStock.Columns["id_stock"] != null) dgvStock.Columns["id_stock"].Visible = false;

                if (dgvStock.Columns["producto"] != null) dgvStock.Columns["producto"].HeaderText = "PRODUCTO";
                if (dgvStock.Columns["categoria"] != null) dgvStock.Columns["categoria"].HeaderText = "CATEGORÍA";
                if (dgvStock.Columns["stock_actual"] != null) dgvStock.Columns["stock_actual"].HeaderText = "STOCK ACTUAL";
                if (dgvStock.Columns["minimo"] != null) dgvStock.Columns["minimo"].HeaderText = "MÍNIMO";
                if (dgvStock.Columns["estado"] != null) dgvStock.Columns["estado"].HeaderText = "ESTADO";

                if (dgvStock.Columns["producto"] != null) dgvStock.Columns["producto"].FillWeight = 160;
                if (dgvStock.Columns["categoria"] != null) dgvStock.Columns["categoria"].FillWeight = 120;
                if (dgvStock.Columns["stock_actual"] != null) dgvStock.Columns["stock_actual"].FillWeight = 90;
                if (dgvStock.Columns["minimo"] != null) dgvStock.Columns["minimo"].FillWeight = 80;
                if (dgvStock.Columns["estado"] != null) dgvStock.Columns["estado"].FillWeight = 100;
                if (dgvStock.Columns["btnMenos"] != null) dgvStock.Columns["btnMenos"].FillWeight = 40;
                if (dgvStock.Columns["btnMas"] != null) dgvStock.Columns["btnMas"].FillWeight = 40;
            }
        }

        private void dgvStock_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvStock.Columns[e.ColumnIndex].Name == "estado")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                string estado = e.Value?.ToString() ?? "";

                Color bgColor = estado.Equals("Disponible", StringComparison.OrdinalIgnoreCase) ? Color.FromArgb(220, 252, 231) : Color.FromArgb(254, 226, 226);
                Color fgColor = estado.Equals("Disponible", StringComparison.OrdinalIgnoreCase) ? Color.FromArgb(22, 101, 52) : Color.FromArgb(153, 27, 27);

                using (Brush bgBrush = new SolidBrush(bgColor))
                {
                    Rectangle rect = new Rectangle(e.CellBounds.Left + 8, e.CellBounds.Top + 8, e.CellBounds.Width - 16, e.CellBounds.Height - 16);
                    e.Graphics.FillRectangle(bgBrush, rect);
                }

                using (Brush textBrush = new SolidBrush(fgColor))
                {
                    Font fontPill = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                    SizeF textSize = e.Graphics.MeasureString(estado, fontPill);
                    float textX = e.CellBounds.Left + (e.CellBounds.Width - textSize.Width) / 2;
                    float textY = e.CellBounds.Top + (e.CellBounds.Height - textSize.Height) / 2;
                    e.Graphics.DrawString(estado, fontPill, textBrush, textX, textY);
                }

                e.Handled = true;
            }
        }

        private void dgvStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dgvStock.Columns[e.ColumnIndex].Name;
            DataGridViewRow row = dgvStock.Rows[e.RowIndex];

            int stockActual = Convert.ToInt32(row.Cells["stock_actual"].Value);
            int minimo = Convert.ToInt32(row.Cells["minimo"].Value);

            if (colName == "btnMenos")
            {
                if (stockActual > 0) stockActual--;
            }
            else if (colName == "btnMas")
            {
                stockActual++;
            }
            else
            {
                return;
            }

            row.Cells["stock_actual"].Value = stockActual;

            string nuevoEstado = stockActual <= minimo ? "Reponer" : "Disponible";
            row.Cells["estado"].Value = nuevoEstado;

            ActualizarAlertaStock();
        }

        private void ActualizarAlertaStock()
        {
            int productosAReponer = 0;
            foreach (DataGridViewRow row in dgvStock.Rows)
            {
                if (row.Cells["estado"].Value != null && row.Cells["estado"].Value.ToString().Equals("Reponer", StringComparison.OrdinalIgnoreCase))
                {
                    productosAReponer++;
                }
            }

            if (productosAReponer > 0)
            {
                panelAlerta.Visible = true;
                lblAlertaTexto.Text = $"⚠️ Hay {productosAReponer} producto(s) con existencias iguales o menores al mínimo. Revisa las alertas destacadas.";
            }
            else
            {
                panelAlerta.Visible = false;
            }
        }

        private void FiltrarTabla(object sender, EventArgs e)
        {
            try
            {
                Control txtB = BuscarControlPorNombre(this, "txtBuscar") ?? BuscarControlPorNombre(this, "txtBuscarInventario");
                string busqueda = ObtenerTextoControl(txtB);

                if (string.IsNullOrWhiteSpace(busqueda))
                {
                    bindingSourceStock.Filter = string.Empty;
                    return;
                }

                busqueda = busqueda.Replace("'", "''").Trim();
                bindingSourceStock.Filter = string.Format("producto LIKE '%{0}%' OR categoria LIKE '%{0}%'", busqueda);
            }
            catch
            {
                bindingSourceStock.Filter = string.Empty;
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

        private string ObtenerTextoControl(object control)
        {
            if (control == null) return "";
            var propTexts = control.GetType().GetProperty("Texts");
            if (propTexts != null)
            {
                string val = propTexts.GetValue(control, null) as string;
                if (!string.IsNullOrWhiteSpace(val)) return val.Trim();
            }
            var propText = control.GetType().GetProperty("Text");
            if (propText != null)
            {
                string val = propText.GetValue(control, null) as string;
                if (!string.IsNullOrWhiteSpace(val)) return val.Trim();
            }
            return "";
        }
    }
}

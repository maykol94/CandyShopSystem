using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using EntityLayer;
using FontAwesome.Sharp;

namespace PresentationLayer
{
    public partial class UC_Inventario : UserControl
    {
        private InventarioBl objInventarioBl = new InventarioBl();
        private BindingSource bindingSourceInventario = new BindingSource();
        private List<EInventario> listaInventario = new List<EInventario>();

        private Image imgMas;
        private Image imgMenos;

        public UC_Inventario()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(253, 246, 248);

            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);

            InicializarIconosAcciones();
            EstilarGrid();

            this.Load += UC_Stock_Load;
            this.Resize += UC_Stock_Resize;
        }

        private void InicializarIconosAcciones()
        {
            imgMas = IconChar.Plus.ToBitmap(Color.FromArgb(170, 70, 150), 15);
            imgMenos = IconChar.Minus.ToBitmap(Color.FromArgb(170, 70, 150), 15);
        }

        private async void UC_Stock_Load(object sender, EventArgs e)
        {
            AjustarAnchoAContenedor();
            VincularEventos();
            await CargarTablaInventarioAsync();
        }

        private void UC_Stock_Resize(object sender, EventArgs e)
        {
            AjustarAnchoAContenedor();
        }

        private void AjustarAnchoAContenedor()
        {
            this.Dock = DockStyle.Fill;
            if (this.Parent != null)
            {
                this.Size = this.Parent.ClientSize;
            }
        }

        private void VincularEventos()
        {
            Control txtB = BuscarControlPorNombre(this, "txtBuscarInventario") ?? BuscarControlPorNombre(this, "txtBuscar");
            if (txtB != null)
            {
                txtB.TextChanged -= FiltrarTabla;
                txtB.TextChanged += FiltrarTabla;

                var propTexts = txtB.GetType().GetProperty("Texts");
                if (propTexts != null)
                {
                    var evtRJ = txtB.GetType().GetEvent("_TextChanged");
                    if (evtRJ != null)
                    {
                        var handler = Delegate.CreateDelegate(evtRJ.EventHandlerType, this, GetType().GetMethod("FiltrarTabla", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance));
                        evtRJ.RemoveEventHandler(txtB, handler);
                        evtRJ.AddEventHandler(txtB, handler);
                    }
                }
            }

            Control dgvCtrl = BuscarControlPorNombre(this, "dgvInventario") ?? BuscarControlPorNombre(this, "dgvData");
            if (dgvCtrl is DataGridView dgvGrid)
            {
                dgvGrid.CellContentClick -= dgvInventario_CellContentClick;
                dgvGrid.CellContentClick += dgvInventario_CellContentClick;

                dgvGrid.CellPainting -= dgvInventario_CellPainting;
                dgvGrid.CellPainting += dgvInventario_CellPainting;
            }
        }

        private void EstilarGrid()
        {
            Control dgvCtrl = BuscarControlPorNombre(this, "dgvInventario") ?? BuscarControlPorNombre(this, "dgvData");
            if (dgvCtrl is DataGridView dgv)
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
                dgv.Dock = DockStyle.Fill;

                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(253, 242, 244);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(190, 46, 95);
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.0F, FontStyle.Bold);
                dgv.ColumnHeadersHeight = 42;

                dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 226, 233);
                dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(190, 46, 95);
                dgv.DefaultCellStyle.ForeColor = Color.FromArgb(70, 70, 80);
                dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
                dgv.RowTemplate.Height = 45;
            }
        }

        public async Task CargarTablaInventarioAsync()
        {
            try
            {
                listaInventario = await objInventarioBl.ObtenerInventarioAsync();
                DataTable dt = ConvertirListaADataTable(listaInventario);

                bindingSourceInventario.DataSource = dt;

                Control dgvCtrl = BuscarControlPorNombre(this, "dgvInventario") ?? BuscarControlPorNombre(this, "dgvData");
                if (dgvCtrl is DataGridView dgv)
                {
                    dgv.DataSource = null;
                    dgv.DataSource = bindingSourceInventario;

                    AgregarColumnasAcciones(dgv);
                    AjustarColumnasGrid(dgv);
                }

                ActualizarBannerAlerta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar inventario: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarBannerAlerta()
        {
            int rep = listaInventario.Count(x => x.CantidadDisponible <= x.DiasAlerta);

            Control lblA = BuscarControlPorNombre(this, "lblAlertaTexto");
            Control pnlA = BuscarControlPorNombre(this, "pnlAlerta");

            if (lblA != null)
            {
                if (rep > 0)
                {
                    lblA.Text = $"Hay {rep} producto(s) con existencias iguales o menores al mínimo. Revisa las alertas destacadas.";
                    if (pnlA != null) pnlA.Visible = true;
                }
                else
                {
                    lblA.Text = "Todas las existencias están en niveles óptimos.";
                    if (pnlA != null) pnlA.Visible = true;
                }
            }
        }

        private DataTable ConvertirListaADataTable(List<EInventario> lista)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdStock", typeof(int));
            dt.Columns.Add("Producto", typeof(string));
            dt.Columns.Add("Categoria", typeof(string));
            dt.Columns.Add("CantidadDisponible", typeof(int));
            dt.Columns.Add("PrecioCompra", typeof(decimal));
            dt.Columns.Add("PrecioVenta", typeof(decimal));
            dt.Columns.Add("FechaIngreso", typeof(string));
            dt.Columns.Add("DiasAlerta", typeof(int));
            dt.Columns.Add("Estado", typeof(string));

            foreach (var item in lista)
            {
                dt.Rows.Add(item.IdStock, item.Producto, item.Categoria, item.CantidadDisponible, item.PrecioCompra, item.PrecioVenta, item.FechaIngreso, item.DiasAlerta, item.Estado);
            }

            return dt;
        }

        private void AgregarColumnasAcciones(DataGridView dgv)
        {
            if (dgv.Columns["colRestar"] == null)
            {
                DataGridViewButtonColumn btnRestar = new DataGridViewButtonColumn();
                btnRestar.Name = "colRestar";
                btnRestar.HeaderText = "";
                btnRestar.Width = 35;
                btnRestar.FlatStyle = FlatStyle.Flat;
                dgv.Columns.Add(btnRestar);
            }

            if (dgv.Columns["colSumar"] == null)
            {
                DataGridViewButtonColumn btnSumar = new DataGridViewButtonColumn();
                btnSumar.Name = "colSumar";
                btnSumar.HeaderText = "";
                btnSumar.Width = 35;
                btnSumar.FlatStyle = FlatStyle.Flat;
                dgv.Columns.Add(btnSumar);
            }
        }

        private void AjustarColumnasGrid(DataGridView dgv)
        {
            if (dgv.Columns.Count > 0)
            {
                if (dgv.Columns["IdStock"] != null) dgv.Columns["IdStock"].Visible = false;
                if (dgv.Columns["DiasAlerta"] != null) dgv.Columns["DiasAlerta"].Visible = false;

                if (dgv.Columns["Producto"] != null) dgv.Columns["Producto"].HeaderText = "PRODUCTO";
                if (dgv.Columns["Categoria"] != null) dgv.Columns["Categoria"].HeaderText = "CATEGORÍA";
                if (dgv.Columns["CantidadDisponible"] != null) dgv.Columns["CantidadDisponible"].HeaderText = "STOCK";
                if (dgv.Columns["PrecioCompra"] != null) dgv.Columns["PrecioCompra"].HeaderText = "PRECIO COMPRA";
                if (dgv.Columns["PrecioVenta"] != null) dgv.Columns["PrecioVenta"].HeaderText = "PRECIO VENTA";
                if (dgv.Columns["FechaIngreso"] != null) dgv.Columns["FechaIngreso"].HeaderText = "FECHA ENTRADA";
                if (dgv.Columns["Estado"] != null) dgv.Columns["Estado"].HeaderText = "ESTADO";

                if (dgv.Columns["Producto"] != null) dgv.Columns["Producto"].FillWeight = 140;
                if (dgv.Columns["Categoria"] != null) dgv.Columns["Categoria"].FillWeight = 90;
                if (dgv.Columns["CantidadDisponible"] != null) dgv.Columns["CantidadDisponible"].FillWeight = 60;
                if (dgv.Columns["PrecioCompra"] != null) dgv.Columns["PrecioCompra"].FillWeight = 85;
                if (dgv.Columns["PrecioVenta"] != null) dgv.Columns["PrecioVenta"].FillWeight = 85;
                if (dgv.Columns["FechaIngreso"] != null) dgv.Columns["FechaIngreso"].FillWeight = 90;
                if (dgv.Columns["Estado"] != null) dgv.Columns["Estado"].FillWeight = 80;

                if (dgv.Columns["PrecioCompra"] != null) dgv.Columns["PrecioCompra"].DefaultCellStyle.Format = "C$ #,##0.00";
                if (dgv.Columns["PrecioVenta"] != null) dgv.Columns["PrecioVenta"].DefaultCellStyle.Format = "C$ #,##0.00";

                if (dgv.Columns["CantidadDisponible"] != null) dgv.Columns["CantidadDisponible"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (dgv.Columns["PrecioCompra"] != null) dgv.Columns["PrecioCompra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (dgv.Columns["PrecioVenta"] != null) dgv.Columns["PrecioVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (dgv.Columns["FechaIngreso"] != null) dgv.Columns["FechaIngreso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (dgv.Columns["Estado"] != null) dgv.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                int index = 0;
                if (dgv.Columns["Producto"] != null) dgv.Columns["Producto"].DisplayIndex = index++;
                if (dgv.Columns["Categoria"] != null) dgv.Columns["Categoria"].DisplayIndex = index++;
                if (dgv.Columns["CantidadDisponible"] != null) dgv.Columns["CantidadDisponible"].DisplayIndex = index++;
                if (dgv.Columns["PrecioCompra"] != null) dgv.Columns["PrecioCompra"].DisplayIndex = index++;
                if (dgv.Columns["PrecioVenta"] != null) dgv.Columns["PrecioVenta"].DisplayIndex = index++;
                if (dgv.Columns["FechaIngreso"] != null) dgv.Columns["FechaIngreso"].DisplayIndex = index++;
                if (dgv.Columns["Estado"] != null) dgv.Columns["Estado"].DisplayIndex = index++;
                if (dgv.Columns["colRestar"] != null) dgv.Columns["colRestar"].DisplayIndex = index++;
                if (dgv.Columns["colSumar"] != null) dgv.Columns["colSumar"].DisplayIndex = index++;
            }
        }

        private void dgvInventario_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Control dgvCtrl = BuscarControlPorNombre(this, "dgvInventario") ?? BuscarControlPorNombre(this, "dgvData");
            if (dgvCtrl is DataGridView dgv)
            {
                string colName = dgv.Columns[e.ColumnIndex].Name;

                if (colName == "Estado" && e.Value != null)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                    string estado = e.Value.ToString();
                    bool esDisponible = estado.Equals("Disponible", StringComparison.OrdinalIgnoreCase);
                    bool esReponer = estado.Equals("Reponer", StringComparison.OrdinalIgnoreCase);

                    Color backPill = esDisponible ? Color.FromArgb(220, 245, 230) : (esReponer ? Color.FromArgb(255, 243, 205) : Color.FromArgb(255, 225, 230));
                    Color textPill = esDisponible ? Color.FromArgb(35, 135, 75) : (esReponer ? Color.FromArgb(133, 100, 4) : Color.FromArgb(220, 50, 80));

                    int pillWidth = 85;
                    int pillHeight = 24;
                    int posX = e.CellBounds.Left + (e.CellBounds.Width - pillWidth) / 2;
                    int posY = e.CellBounds.Top + (e.CellBounds.Height - pillHeight) / 2;

                    Rectangle rectPill = new Rectangle(posX, posY, pillWidth, pillHeight);

                    using (GraphicsPath path = GetRoundedPath(rectPill, 12))
                    using (SolidBrush brushBack = new SolidBrush(backPill))
                    using (SolidBrush brushText = new SolidBrush(textPill))
                    using (StringFormat sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    {
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.FillPath(brushBack, path);
                        e.Graphics.DrawString(estado, new Font("Segoe UI", 8.5F, FontStyle.Bold), brushText, rectPill, sf);
                    }

                    e.Handled = true;
                }

                if (colName == "colRestar" || colName == "colSumar")
                {
                    bool isSelected = (e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected;
                    Color bgCelda = isSelected ? Color.FromArgb(254, 226, 233) : Color.FromArgb(253, 242, 244);

                    using (SolidBrush brushBgCelda = new SolidBrush(bgCelda))
                    {
                        e.Graphics.FillRectangle(brushBgCelda, e.CellBounds);
                    }

                    using (Pen penSeparator = new Pen(Color.FromArgb(245, 240, 243)))
                    {
                        e.Graphics.DrawLine(penSeparator, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                    }

                    Image imgToDraw = colName == "colRestar" ? imgMenos : imgMas;

                    if (imgToDraw != null)
                    {
                        int x = e.CellBounds.Left + (e.CellBounds.Width - imgToDraw.Width) / 2;
                        int y = e.CellBounds.Top + (e.CellBounds.Height - imgToDraw.Height) / 2;

                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.DrawImage(imgToDraw, new Point(x, y));
                    }

                    e.Handled = true;
                }
            }
        }

        private async void dgvInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Control dgvCtrl = BuscarControlPorNombre(this, "dgvInventario") ?? BuscarControlPorNombre(this, "dgvData");
            if (dgvCtrl is DataGridView dgv)
            {
                string colName = dgv.Columns[e.ColumnIndex].Name;

                if (colName == "colRestar" || colName == "colSumar")
                {
                    DataGridViewRow row = dgv.Rows[e.RowIndex];
                    DataRowView rowView = row.DataBoundItem as DataRowView;

                    if (rowView != null)
                    {
                        int idStock = Convert.ToInt32(rowView["IdStock"]);
                        int cambio = colName == "colSumar" ? 1 : -1;

                        var (exito, mensaje) = await objInventarioBl.AjustarStockAsync(idStock, cambio);

                        if (exito)
                        {
                            await CargarTablaInventarioAsync();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo ajustar el inventario: " + mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private void FiltrarTabla(object sender, EventArgs e)
        {
            try
            {
                Control txtB = BuscarControlPorNombre(this, "txtBuscarInventario") ?? BuscarControlPorNombre(this, "txtBuscar");
                string busqueda = ObtenerTextoControl(txtB);

                if (string.IsNullOrWhiteSpace(busqueda))
                {
                    bindingSourceInventario.Filter = string.Empty;
                    return;
                }

                busqueda = busqueda.Replace("'", "''").Trim();
                bindingSourceInventario.Filter = string.Format("Producto LIKE '%{0}%' OR Categoria LIKE '%{0}%' OR Estado LIKE '%{0}%'", busqueda);
            }
            catch (Exception)
            {
                bindingSourceInventario.Filter = string.Empty;
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float floatRadius = radius * 2;
            path.AddArc(rect.X, rect.Y, floatRadius, floatRadius, 180, 90);
            path.AddArc(rect.Right - floatRadius, rect.Y, floatRadius, floatRadius, 270, 90);
            path.AddArc(rect.Right - floatRadius, rect.Bottom - floatRadius, floatRadius, floatRadius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - floatRadius, floatRadius, floatRadius, 90, 90);
            path.CloseFigure();
            return path;
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
                string valTexts = propTexts.GetValue(control, null) as string;
                if (!string.IsNullOrWhiteSpace(valTexts)) return valTexts.Trim();
            }

            var propText = control.GetType().GetProperty("Text");
            if (propText != null)
            {
                string valText = propText.GetValue(control, null) as string;
                if (!string.IsNullOrWhiteSpace(valText)) return valText.Trim();
            }

            return "";
        }
    }
}
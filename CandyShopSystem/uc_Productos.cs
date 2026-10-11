using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using EntityLayer;

namespace CandyShopSystem
{
    public partial class uc_Productos : UserControl
    {
        private ProductoBL objProductoBL = new ProductoBL();
        private BindingSource bindingSourceProductos = new BindingSource();
        private DataTable tablaProductos = new DataTable();

        public uc_Productos()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(248, 249, 253);

            this.AutoSize = false;
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);

            EstilarGrid();

            this.Load += uc_Productos_Load;
            this.Resize += uc_Productos_Resize;
        }

        private async void uc_Productos_Load(object sender, EventArgs e)
        {
            AjustarAnchoAContenedor();
            VincularEventos();
            await CargarTablaProductosAsync();
        }

        private void VincularEventos()
        {
            // 1. Vincular caja de texto de búsqueda
            if (txtBuscar != null)
            {
                txtBuscar._TextChanged -= FiltrarTabla;
                txtBuscar._TextChanged += FiltrarTabla;

                txtBuscar.TextChanged -= FiltrarTabla;
                txtBuscar.TextChanged += FiltrarTabla;
            }

            // 2. Vincular botón Buscar
            if (btnBuscar != null)
            {
                btnBuscar.Click -= btnBuscar_Click;
                btnBuscar.Click += btnBuscar_Click;
            }

            // 3. Vincular botón Nuevo Producto
            if (btnNuevoProducto != null)
            {
                btnNuevoProducto.Click -= btnNuevoProducto_Click;
                btnNuevoProducto.Click += btnNuevoProducto_Click;
            }

            // 4. Eventos del AdvancedDataGridView
            if (dgvProductos != null)
            {
                dgvProductos.FilterStringChanged -= dgvProductos_FilterStringChanged;
                dgvProductos.FilterStringChanged += dgvProductos_FilterStringChanged;

                dgvProductos.SortStringChanged -= dgvProductos_SortStringChanged;
                dgvProductos.SortStringChanged += dgvProductos_SortStringChanged;

                dgvProductos.CellContentClick -= dgvProductos_CellContentClick;
                dgvProductos.CellContentClick += dgvProductos_CellContentClick;
            }
        }

        private void uc_Productos_Resize(object sender, EventArgs e)
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

        private void EstilarGrid()
        {
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProductos.GridColor = Color.FromArgb(240, 240, 245);
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.ReadOnly = true;

            dgvProductos.RowHeadersVisible = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.Dock = DockStyle.Fill;

            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvProductos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 250);
            dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(100, 100, 120);
            dgvProductos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvProductos.ColumnHeadersHeight = 42;

            dgvProductos.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dgvProductos.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);

            dgvProductos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(242, 235, 255);
            dgvProductos.DefaultCellStyle.SelectionForeColor = Color.FromArgb(112, 18, 206);
            dgvProductos.DefaultCellStyle.ForeColor = Color.FromArgb(70, 70, 80);
            dgvProductos.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvProductos.RowTemplate.Height = 38;
        }

        public async Task CargarTablaProductosAsync()
        {
            try
            {
                List<EProducto> lista = await Task.Run(() => objProductoBL.ObtenerProductos());
                tablaProductos = ConvertirListaADataTable(lista);

                bindingSourceProductos.DataSource = tablaProductos;
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = bindingSourceProductos;

                AjustarColumnasGrid();
                AgregarColumnasAcciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ConvertirListaADataTable(List<EProducto> lista)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdProducto", typeof(int));
            dt.Columns.Add("Codigo", typeof(string));
            dt.Columns.Add("NombreProducto", typeof(string));
            dt.Columns.Add("Categoria", typeof(string));
            dt.Columns.Add("Precio", typeof(decimal));
            dt.Columns.Add("Stock", typeof(int));
            dt.Columns.Add("Estado", typeof(string));

            foreach (var item in lista)
            {
                dt.Rows.Add(
                    item.IdProducto,
                    item.Codigo,
                    item.NombreProducto,
                    item.Categoria,
                    item.Precio,
                    item.Stock,
                    item.Estado
                );
            }

            return dt;
        }

        private void AjustarColumnasGrid()
        {
            if (dgvProductos.Columns.Count > 0)
            {
                if (dgvProductos.Columns["IdProducto"] != null) dgvProductos.Columns["IdProducto"].Visible = false;

                if (dgvProductos.Columns["Codigo"] != null) dgvProductos.Columns["Codigo"].HeaderText = "ID";
                if (dgvProductos.Columns["NombreProducto"] != null) dgvProductos.Columns["NombreProducto"].HeaderText = "GOLOSINA / PRODUCTO";
                if (dgvProductos.Columns["Categoria"] != null) dgvProductos.Columns["Categoria"].HeaderText = "CATEGORÍA";
                if (dgvProductos.Columns["Precio"] != null)
                {
                    dgvProductos.Columns["Precio"].HeaderText = "PRECIO";
                    dgvProductos.Columns["Precio"].DefaultCellStyle.Format = "C$ #,##0.00";
                }
                if (dgvProductos.Columns["Stock"] != null) dgvProductos.Columns["Stock"].HeaderText = "STOCK";
                if (dgvProductos.Columns["Estado"] != null) dgvProductos.Columns["Estado"].HeaderText = "ESTADO";

                if (dgvProductos.Columns["Codigo"] != null) dgvProductos.Columns["Codigo"].FillWeight = 50;
                if (dgvProductos.Columns["NombreProducto"] != null) dgvProductos.Columns["NombreProducto"].FillWeight = 160;
                if (dgvProductos.Columns["Categoria"] != null) dgvProductos.Columns["Categoria"].FillWeight = 110;
                if (dgvProductos.Columns["Precio"] != null) dgvProductos.Columns["Precio"].FillWeight = 90;
                if (dgvProductos.Columns["Stock"] != null) dgvProductos.Columns["Stock"].FillWeight = 70;
                if (dgvProductos.Columns["Estado"] != null) dgvProductos.Columns["Estado"].FillWeight = 80;
            }
        }

        private void AgregarColumnasAcciones()
        {
            if (dgvProductos.Columns["colVer"] == null)
            {
                DataGridViewButtonColumn btnVer = new DataGridViewButtonColumn();
                btnVer.Name = "colVer";
                btnVer.HeaderText = "VER";
                btnVer.Text = "Ver";
                btnVer.UseColumnTextForButtonValue = true;
                btnVer.Width = 45;
                btnVer.FlatStyle = FlatStyle.Flat;
                btnVer.DefaultCellStyle.BackColor = Color.FromArgb(230, 235, 255);
                btnVer.DefaultCellStyle.ForeColor = Color.FromArgb(98, 102, 241);
                dgvProductos.Columns.Add(btnVer);
            }

            if (dgvProductos.Columns["colEditar"] == null)
            {
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                btnEditar.Name = "colEditar";
                btnEditar.HeaderText = "EDITAR";
                btnEditar.Text = "Editar";
                btnEditar.UseColumnTextForButtonValue = true;
                btnEditar.Width = 55;
                btnEditar.FlatStyle = FlatStyle.Flat;
                btnEditar.DefaultCellStyle.BackColor = Color.FromArgb(254, 243, 199);
                btnEditar.DefaultCellStyle.ForeColor = Color.FromArgb(217, 119, 6);
                dgvProductos.Columns.Add(btnEditar);
            }

            if (dgvProductos.Columns["colEliminar"] == null)
            {
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.Name = "colEliminar";
                btnEliminar.HeaderText = "ELIMINAR";
                btnEliminar.Text = "Borrar";
                btnEliminar.UseColumnTextForButtonValue = true;
                btnEliminar.Width = 55;
                btnEliminar.FlatStyle = FlatStyle.Flat;
                btnEliminar.DefaultCellStyle.BackColor = Color.FromArgb(254, 226, 226);
                btnEliminar.DefaultCellStyle.ForeColor = Color.FromArgb(220, 38, 38);
                dgvProductos.Columns.Add(btnEliminar);
            }
        }

        // --- FILTRADO NATIVO DEL ADVANCED DATAGRIDVIEW ---

        private void dgvProductos_FilterStringChanged(object sender, EventArgs e)
        {
            try { bindingSourceProductos.Filter = dgvProductos.FilterString; } catch { }
        }

        private void dgvProductos_SortStringChanged(object sender, EventArgs e)
        {
            try { bindingSourceProductos.Sort = dgvProductos.SortString; } catch { }
        }

        // --- BÚSQUEDA Y FILTRADO DE LA CAJA DE TEXTO ---

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarTabla(sender, e);
        }

        private void FiltrarTabla(object sender, EventArgs e)
        {
            string busqueda = "";

            if (txtBuscar != null)
            {
                // Soporte para RJTextBox (propiedad .Texts) o TextBox estándar (propiedad .Text)
                var propTexts = txtBuscar.GetType().GetProperty("Texts");
                if (propTexts != null)
                {
                    string valTexts = propTexts.GetValue(txtBuscar, null) as string;
                    if (!string.IsNullOrEmpty(valTexts)) busqueda = valTexts.Trim();
                }

                if (string.IsNullOrEmpty(busqueda))
                {
                    busqueda = txtBuscar.Text != null ? txtBuscar.Text.Trim() : "";
                }
            }

            if (string.IsNullOrEmpty(busqueda))
            {
                bindingSourceProductos.Filter = dgvProductos.FilterString;
            }
            else
            {
                string filtroTexto = string.Format(
                    "(Codigo LIKE '%{0}%' OR NombreProducto LIKE '%{0}%' OR Categoria LIKE '%{0}%' OR Estado LIKE '%{0}%')",
                    busqueda.Replace("'", "''")
                );

                if (!string.IsNullOrEmpty(dgvProductos.FilterString))
                {
                    bindingSourceProductos.Filter = string.Format("{0} AND ({1})", dgvProductos.FilterString, filtroTexto);
                }
                else
                {
                    bindingSourceProductos.Filter = filtroTexto;
                }
            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int idProducto = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells["IdProducto"].Value);

            if (dgvProductos.Columns[e.ColumnIndex].Name == "colVer")
            {
                MessageBox.Show("Detalles del producto ID: " + idProducto, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (dgvProductos.Columns[e.ColumnIndex].Name == "colEditar")
            {
                MessageBox.Show("Editar producto ID: " + idProducto, "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (dgvProductos.Columns[e.ColumnIndex].Name == "colEliminar")
            {
                var result = MessageBox.Show("¿Está seguro de eliminar el producto seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Lógica de borrado
                }
            }
        }

        private async void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            using (FormProductoModal modal = new FormProductoModal())
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    await CargarTablaProductosAsync();
                }
            }
        }
    }
}
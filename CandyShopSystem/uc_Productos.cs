using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using EntityLayer;
using FontAwesome.Sharp;

namespace PresentationLayer
{
    public partial class UC_Productos : UserControl
    {
        private ProductoBl objProductoBl = new ProductoBl();
        private BindingSource bindingSourceProductos = new BindingSource();
        private DataTable tablaProductos = new DataTable();

        private Image imgEditar;
        private Image imgEliminar;

        public UC_Productos()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(248, 249, 253);

            this.AutoSize = false;
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);

            InicializarIconosAcciones();
            EstilarGrid();

            this.Load += UC_Productos_Load;
            this.Resize += UC_Productos_Resize;
        }

        private void InicializarIconosAcciones()
        {
            imgEditar = IconChar.PenToSquare.ToBitmap(Color.FromArgb(140, 110, 230), 18);
            imgEliminar = IconChar.TrashAlt.ToBitmap(Color.FromArgb(235, 95, 115), 18);
        }

        private async void UC_Productos_Load(object sender, EventArgs e)
        {
            AjustarAnchoAContenedor();
            VincularEventos();
            await CargarTablaProductosAsync();
        }

        private void VincularEventos()
        {
            Control txtB = BuscarControlPorNombre(this, "txtBuscarProducto") ?? BuscarControlPorNombre(this, "txtBuscar");
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

            Control btnB = BuscarControlPorNombre(this, "btnBuscarProducto") ?? BuscarControlPorNombre(this, "btnBuscar");
            if (btnB != null)
            {
                btnB.Click -= btnBuscar_Click;
                btnB.Click += btnBuscar_Click;
            }

            Control btnN = BuscarControlPorNombre(this, "btnNuevosProductos") ?? BuscarControlPorNombre(this, "btnNuevoProducto") ?? BuscarControlPorNombre(this, "btnNuevo");
            if (btnN != null)
            {
                btnN.Click -= btnNuevoProducto_Click;
                btnN.Click += btnNuevoProducto_Click;
            }

            Control dgvCtrl = BuscarControlPorNombre(this, "dgvProductos") ?? BuscarControlPorNombre(this, "dgvData");
            if (dgvCtrl is DataGridView dgvGrid)
            {
                dgvGrid.CellContentClick -= dgvProductos_CellContentClick;
                dgvGrid.CellContentClick += dgvProductos_CellContentClick;

                dgvGrid.CellPainting -= dgvProductos_CellPainting;
                dgvGrid.CellPainting += dgvProductos_CellPainting;
            }
        }

        private void UC_Productos_Resize(object sender, EventArgs e)
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
            Control dgvCtrl = BuscarControlPorNombre(this, "dgvProductos") ?? BuscarControlPorNombre(this, "dgvData");
            if (dgvCtrl is DataGridView dgv)
            {
                dgv.BackgroundColor = Color.White;
                dgv.BorderStyle = BorderStyle.None;
                dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dgv.GridColor = Color.FromArgb(245, 240, 243);
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.ReadOnly = true;

                dgv.RowHeadersVisible = false;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.Dock = DockStyle.Fill;

                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(253, 242, 244);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(190, 46, 95);
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                dgv.ColumnHeadersHeight = 42;

                dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
                dgv.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);

                dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 226, 233);
                dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(190, 46, 95);
                dgv.DefaultCellStyle.ForeColor = Color.FromArgb(70, 70, 80);
                dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
                dgv.RowTemplate.Height = 38;
            }
        }

        public async Task CargarTablaProductosAsync()
        {
            try
            {
                List<EProducto> lista = await Task.Run(() => objProductoBl.ObtenerProductos());
                tablaProductos = ConvertirListaADataTable(lista);

                bindingSourceProductos.DataSource = tablaProductos;

                Control dgvCtrl = BuscarControlPorNombre(this, "dgvProductos") ?? BuscarControlPorNombre(this, "dgvData");
                if (dgvCtrl is DataGridView dgv)
                {
                    dgv.DataSource = null;
                    dgv.DataSource = bindingSourceProductos;

                    AgregarColumnasAcciones(dgv);
                    AjustarColumnasGrid(dgv);
                }
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
            dt.Columns.Add("NombreProducto", typeof(string));
            dt.Columns.Add("IdCategoria", typeof(int));
            dt.Columns.Add("NombreCategoria", typeof(string));
            dt.Columns.Add("IdMarca", typeof(int));
            dt.Columns.Add("NombreMarca", typeof(string));
            dt.Columns.Add("IdTipoProducto", typeof(int));
            dt.Columns.Add("TipoProductoDescripcion", typeof(string));

            foreach (var item in lista)
            {
                dt.Rows.Add(
                    item.IdProducto,
                    item.NombreProducto,
                    item.IdCategoria,
                    item.NombreCategoria,
                    item.IdMarca,
                    item.NombreMarca,
                    item.IdTipoProducto,
                    item.TipoProductoDescripcion
                );
            }

            return dt;
        }

        private void AgregarColumnasAcciones(DataGridView dgv)
        {
            if (dgv.Columns["colEditar"] == null)
            {
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                btnEditar.Name = "colEditar";
                btnEditar.HeaderText = "";
                btnEditar.Width = 35;
                btnEditar.FlatStyle = FlatStyle.Flat;
                dgv.Columns.Add(btnEditar);
            }

            if (dgv.Columns["colEliminar"] == null)
            {
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.Name = "colEliminar";
                btnEliminar.HeaderText = "";
                btnEliminar.Width = 35;
                btnEliminar.FlatStyle = FlatStyle.Flat;
                dgv.Columns.Add(btnEliminar);
            }
        }

        private void AjustarColumnasGrid(DataGridView dgv)
        {
            if (dgv.Columns.Count > 0)
            {
                if (dgv.Columns["IdProducto"] != null) dgv.Columns["IdProducto"].HeaderText = "ID";
                if (dgv.Columns["IdCategoria"] != null) dgv.Columns["IdCategoria"].Visible = false;
                if (dgv.Columns["IdMarca"] != null) dgv.Columns["IdMarca"].Visible = false;
                if (dgv.Columns["IdTipoProducto"] != null) dgv.Columns["IdTipoProducto"].Visible = false;

                if (dgv.Columns["NombreProducto"] != null) dgv.Columns["NombreProducto"].HeaderText = "PRODUCTO";
                if (dgv.Columns["NombreCategoria"] != null) dgv.Columns["NombreCategoria"].HeaderText = "CATEGORÍA";
                if (dgv.Columns["NombreMarca"] != null) dgv.Columns["NombreMarca"].HeaderText = "MARCA";
                if (dgv.Columns["TipoProductoDescripcion"] != null) dgv.Columns["TipoProductoDescripcion"].HeaderText = "TIPO PRODUCTO";

                if (dgv.Columns["IdProducto"] != null) dgv.Columns["IdProducto"].FillWeight = 40;
                if (dgv.Columns["NombreProducto"] != null) dgv.Columns["NombreProducto"].FillWeight = 160;
                if (dgv.Columns["NombreCategoria"] != null) dgv.Columns["NombreCategoria"].FillWeight = 110;
                if (dgv.Columns["NombreMarca"] != null) dgv.Columns["NombreMarca"].FillWeight = 100;
                if (dgv.Columns["TipoProductoDescripcion"] != null) dgv.Columns["TipoProductoDescripcion"].FillWeight = 110;

                int index = 0;
                if (dgv.Columns["IdProducto"] != null) dgv.Columns["IdProducto"].DisplayIndex = index++;
                if (dgv.Columns["NombreProducto"] != null) dgv.Columns["NombreProducto"].DisplayIndex = index++;
                if (dgv.Columns["NombreCategoria"] != null) dgv.Columns["NombreCategoria"].DisplayIndex = index++;
                if (dgv.Columns["NombreMarca"] != null) dgv.Columns["NombreMarca"].DisplayIndex = index++;
                if (dgv.Columns["TipoProductoDescripcion"] != null) dgv.Columns["TipoProductoDescripcion"].DisplayIndex = index++;

                if (dgv.Columns["colEditar"] != null) dgv.Columns["colEditar"].DisplayIndex = index++;
                if (dgv.Columns["colEliminar"] != null) dgv.Columns["colEliminar"].DisplayIndex = index++;
            }
        }

        private void dgvProductos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Control dgvCtrl = BuscarControlPorNombre(this, "dgvProductos") ?? BuscarControlPorNombre(this, "dgvData");
            if (dgvCtrl is DataGridView dgv)
            {
                string colName = dgv.Columns[e.ColumnIndex].Name;

                if (colName == "colEditar" || colName == "colEliminar")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                    Image imgToDraw = null;
                    if (colName == "colEditar") imgToDraw = imgEditar;
                    else if (colName == "colEliminar") imgToDraw = imgEliminar;

                    if (imgToDraw != null)
                    {
                        int x = e.CellBounds.Left + (e.CellBounds.Width - imgToDraw.Width) / 2;
                        int y = e.CellBounds.Top + (e.CellBounds.Height - imgToDraw.Height) / 2;
                        e.Graphics.DrawImage(imgToDraw, new Point(x, y));
                    }

                    e.Handled = true;
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarTabla(sender, e);
        }

        private void FiltrarTabla(object sender, EventArgs e)
        {
            try
            {
                Control txtB = BuscarControlPorNombre(this, "txtBuscarProducto") ?? BuscarControlPorNombre(this, "txtBuscar");
                string busqueda = ObtenerTextoControl(txtB);

                if (string.IsNullOrWhiteSpace(busqueda))
                {
                    bindingSourceProductos.Filter = string.Empty;
                    return;
                }

                busqueda = busqueda.Replace("'", "''").Trim();

                string filtroBusqueda = string.Format(
                    "NombreProducto LIKE '%{0}%' OR NombreCategoria LIKE '%{0}%' OR NombreMarca LIKE '%{0}%' OR TipoProductoDescripcion LIKE '%{0}%'",
                    busqueda
                );

                bindingSourceProductos.Filter = filtroBusqueda;
            }
            catch (Exception)
            {
                bindingSourceProductos.Filter = string.Empty;
            }
        }

        private async void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Control dgvCtrl = BuscarControlPorNombre(this, "dgvProductos") ?? BuscarControlPorNombre(this, "dgvData");
            if (dgvCtrl is DataGridView dgv)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                DataRowView rowView = row.DataBoundItem as DataRowView;

                if (rowView == null) return;

                EProducto productoSeleccionado = new EProducto()
                {
                    IdProducto = Convert.ToInt32(rowView["IdProducto"]),
                    NombreProducto = rowView["NombreProducto"].ToString(),
                    IdCategoria = Convert.ToInt32(rowView["IdCategoria"]),
                    NombreCategoria = rowView["NombreCategoria"].ToString(),
                    IdMarca = Convert.ToInt32(rowView["IdMarca"]),
                    NombreMarca = rowView["NombreMarca"].ToString(),
                    IdTipoProducto = Convert.ToInt32(rowView["IdTipoProducto"]),
                    TipoProductoDescripcion = rowView["TipoProductoDescripcion"].ToString()
                };

                string colName = dgv.Columns[e.ColumnIndex].Name;

                // Editar Producto
                if (colName == "colEditar")
                {
                    using (FormEditarProducto modal = new FormEditarProducto(productoSeleccionado))
                    {
                        if (modal.ShowDialog() == DialogResult.OK)
                        {
                            await CargarTablaProductosAsync();
                        }
                    }
                }
                // Eliminar Producto
                else if (colName == "colEliminar")
                {
                    var result = MessageBox.Show(
                        $"¿Está seguro de eliminar el producto '{productoSeleccionado.NombreProducto}'?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        string mensaje = string.Empty;
                        bool respuesta = objProductoBl.EliminarProducto(productoSeleccionado.IdProducto, out mensaje);

                        if (respuesta)
                        {
                            MessageBox.Show("¡Producto eliminado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await CargarTablaProductosAsync();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el producto: " + mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private async void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            using (FormRegistrarProducto modal = new FormRegistrarProducto())
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    await CargarTablaProductosAsync();
                }
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using EntityLayer;
using FontAwesome.Sharp;

namespace CandyShopSystem
{
    public partial class UC_Proveedor : UserControl
    {
        private ProveedorBL objProveedorBL = new ProveedorBL();
        private BindingSource bindingSourceProveedores = new BindingSource();
        private DataTable tablaProveedores = new DataTable();

        // Imágenes pre-renderizadas de FontAwesome para máximo rendimiento visual
        private Image imgVer;
        private Image imgEditar;
        private Image imgEliminar;

        public UC_Proveedor()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(248, 249, 253);

            this.AutoSize = false;
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);

            InicializarIconosAcciones();
            EstilarGrid();

            this.Load += UC_Proveedor_Load;
            this.Resize += UC_Proveedor_Resize;
        }

        private void InicializarIconosAcciones()
        {
            // Colores e iconos de FontAwesome idénticos a la plantilla de referencia
            imgVer = IconChar.BookOpen.ToBitmap(Color.FromArgb(123, 136, 198), 18);
            imgEditar = IconChar.PenToSquare.ToBitmap(Color.FromArgb(140, 138, 214), 18);
            imgEliminar = IconChar.TrashAlt.ToBitmap(Color.FromArgb(152, 148, 168), 18);
        }

        private async void UC_Proveedor_Load(object sender, EventArgs e)
        {
            AjustarAnchoAContenedor();
            VincularEventos();
            await CargarTablaProveedoresAsync();
        }

        private void VincularEventos()
        {
            // 1. Vincular caja de texto de búsqueda
            Control txtB = BuscarControlPorNombre(this, "txtBuscar");
            if (txtB != null)
            {
                txtB.TextChanged -= FiltrarTabla;
                txtB.TextChanged += FiltrarTabla;

                // Soporte si se trata de un control personalizado (ej. RJTextBox)
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

            // 2. Botón Buscar
            Control btnB = BuscarControlPorNombre(this, "btnBuscar");
            if (btnB != null)
            {
                btnB.Click -= btnBuscar_Click;
                btnB.Click += btnBuscar_Click;
            }

            // 3. Botón Nuevo Proveedor
            Control btnN = BuscarControlPorNombre(this, "btnNuevoProveedor") ?? BuscarControlPorNombre(this, "btnNuevo");
            if (btnN != null)
            {
                btnN.Click -= btnNuevoProveedor_Click;
                btnN.Click += btnNuevoProveedor_Click;
            }

            // 4. Eventos del AdvancedDataGridView
            if (dgvProveedores != null)
            {
                dgvProveedores.FilterStringChanged -= dgvProveedores_FilterStringChanged;
                dgvProveedores.FilterStringChanged += dgvProveedores_FilterStringChanged;

                dgvProveedores.SortStringChanged -= dgvProveedores_SortStringChanged;
                dgvProveedores.SortStringChanged += dgvProveedores_SortStringChanged;

                dgvProveedores.CellContentClick -= dgvProveedores_CellContentClick;
                dgvProveedores.CellContentClick += dgvProveedores_CellContentClick;

                dgvProveedores.CellPainting -= dgvProveedores_CellPainting;
                dgvProveedores.CellPainting += dgvProveedores_CellPainting;
            }
        }

        private void UC_Proveedor_Resize(object sender, EventArgs e)
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
            if (dgvProveedores == null) return;

            dgvProveedores.BackgroundColor = Color.White;
            dgvProveedores.BorderStyle = BorderStyle.None;
            dgvProveedores.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProveedores.GridColor = Color.FromArgb(240, 240, 245);
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.ReadOnly = true;

            dgvProveedores.RowHeadersVisible = false;
            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProveedores.Dock = DockStyle.Fill;

            dgvProveedores.EnableHeadersVisualStyles = false;
            dgvProveedores.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvProveedores.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 250);
            dgvProveedores.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(100, 100, 120);
            dgvProveedores.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvProveedores.ColumnHeadersHeight = 42;

            dgvProveedores.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dgvProveedores.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);

            dgvProveedores.DefaultCellStyle.SelectionBackColor = Color.FromArgb(242, 235, 255);
            dgvProveedores.DefaultCellStyle.SelectionForeColor = Color.FromArgb(112, 18, 206);
            dgvProveedores.DefaultCellStyle.ForeColor = Color.FromArgb(70, 70, 80);
            dgvProveedores.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvProveedores.RowTemplate.Height = 38;
        }

        public async Task CargarTablaProveedoresAsync()
        {
            try
            {
                List<EProveedor> lista = await Task.Run(() => objProveedorBL.ObtenerProveedores());
                tablaProveedores = ConvertirListaADataTable(lista);

                bindingSourceProveedores.DataSource = tablaProveedores;
                dgvProveedores.DataSource = null;
                dgvProveedores.DataSource = bindingSourceProveedores;

                AjustarColumnasGrid();
                AgregarColumnasAcciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ConvertirListaADataTable(List<EProveedor> lista)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdProveedor", typeof(int));
            dt.Columns.Add("NombreProveedor", typeof(string));
            dt.Columns.Add("Contacto", typeof(string));
            dt.Columns.Add("Telefono", typeof(string));
            dt.Columns.Add("Direccion", typeof(string));
            dt.Columns.Add("Estado", typeof(string));

            foreach (var item in lista)
            {
                dt.Rows.Add(
                    item.IdProveedor,
                    item.NombreProveedor,
                    item.Contacto,
                    item.Telefono,
                    item.Direccion,
                    item.Estado
                );
            }

            return dt;
        }

        private void AjustarColumnasGrid()
        {
            if (dgvProveedores.Columns.Count > 0)
            {
                if (dgvProveedores.Columns["IdProveedor"] != null) dgvProveedores.Columns["IdProveedor"].Visible = false;

                if (dgvProveedores.Columns["NombreProveedor"] != null) dgvProveedores.Columns["NombreProveedor"].HeaderText = "PROVEEDOR / EMPRESA";
                if (dgvProveedores.Columns["Contacto"] != null) dgvProveedores.Columns["Contacto"].HeaderText = "CONTACTO";
                if (dgvProveedores.Columns["Telefono"] != null) dgvProveedores.Columns["Telefono"].HeaderText = "TELÉFONO";
                if (dgvProveedores.Columns["Direccion"] != null) dgvProveedores.Columns["Direccion"].HeaderText = "DIRECCIÓN";
                if (dgvProveedores.Columns["Estado"] != null) dgvProveedores.Columns["Estado"].HeaderText = "ESTADO";

                if (dgvProveedores.Columns["NombreProveedor"] != null) dgvProveedores.Columns["NombreProveedor"].FillWeight = 150;
                if (dgvProveedores.Columns["Contacto"] != null) dgvProveedores.Columns["Contacto"].FillWeight = 100;
                if (dgvProveedores.Columns["Telefono"] != null) dgvProveedores.Columns["Telefono"].FillWeight = 90;
                if (dgvProveedores.Columns["Direccion"] != null) dgvProveedores.Columns["Direccion"].FillWeight = 160;
                if (dgvProveedores.Columns["Estado"] != null) dgvProveedores.Columns["Estado"].FillWeight = 70;
            }
        }

        private void AgregarColumnasAcciones()
        {
            if (dgvProveedores.Columns["colVer"] == null)
            {
                DataGridViewButtonColumn btnVer = new DataGridViewButtonColumn();
                btnVer.Name = "colVer";
                btnVer.HeaderText = "";
                btnVer.Width = 30;
                btnVer.FlatStyle = FlatStyle.Flat;
                dgvProveedores.Columns.Add(btnVer);
            }

            if (dgvProveedores.Columns["colEditar"] == null)
            {
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                btnEditar.Name = "colEditar";
                btnEditar.HeaderText = "";
                btnEditar.Width = 30;
                btnEditar.FlatStyle = FlatStyle.Flat;
                dgvProveedores.Columns.Add(btnEditar);
            }

            if (dgvProveedores.Columns["colEliminar"] == null)
            {
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.Name = "colEliminar";
                btnEliminar.HeaderText = "";
                btnEliminar.Width = 30;
                btnEliminar.FlatStyle = FlatStyle.Flat;
                dgvProveedores.Columns.Add(btnEliminar);
            }
        }

        // --- DIBUJO PERSONALIZADO DE ICONOS FONTAWESOME ---

        private void dgvProveedores_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dgvProveedores.Columns[e.ColumnIndex].Name;

            if (colName == "colVer" || colName == "colEditar" || colName == "colEliminar")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                Image imgToDraw = null;
                if (colName == "colVer") imgToDraw = imgVer;
                else if (colName == "colEditar") imgToDraw = imgEditar;
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

        // --- FILTRADO SEGURO DE LA CAJA DE TEXTO ---

        private void dgvProveedores_FilterStringChanged(object sender, EventArgs e)
        {
            try { bindingSourceProveedores.Filter = dgvProveedores.FilterString; } catch { }
        }

        private void dgvProveedores_SortStringChanged(object sender, EventArgs e)
        {
            try { bindingSourceProveedores.Sort = dgvProveedores.SortString; } catch { }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarTabla(sender, e);
        }

        private void FiltrarTabla(object sender, EventArgs e)
        {
            try
            {
                Control txtB = BuscarControlPorNombre(this, "txtBuscar");
                string busqueda = ObtenerTextoControl(txtB);

                if (string.IsNullOrWhiteSpace(busqueda))
                {
                    bindingSourceProveedores.Filter = string.Empty;
                    return;
                }

                busqueda = busqueda.Replace("'", "''").Trim();

                string filtroBusqueda = string.Format(
                    "NombreProveedor LIKE '%{0}%' OR Contacto LIKE '%{0}%' OR Telefono LIKE '%{0}%' OR Direccion LIKE '%{0}%'",
                    busqueda
                );

                bindingSourceProveedores.Filter = filtroBusqueda;
            }
            catch (Exception)
            {
                bindingSourceProveedores.Filter = string.Empty;
            }
        }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int idProveedor = Convert.ToInt32(dgvProveedores.Rows[e.RowIndex].Cells["IdProveedor"].Value);

            if (dgvProveedores.Columns[e.ColumnIndex].Name == "colVer")
            {
                MessageBox.Show("Detalles del proveedor ID: " + idProveedor, "Ver Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (dgvProveedores.Columns[e.ColumnIndex].Name == "colEditar")
            {
                MessageBox.Show("Editar proveedor ID: " + idProveedor, "Editar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (dgvProveedores.Columns[e.ColumnIndex].Name == "colEliminar")
            {
                var result = MessageBox.Show("¿Está seguro de eliminar el proveedor seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Lógica de eliminación en base de datos
                }
            }
        }

        private async void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            // Abre modal para registrar proveedor
        }

        // --- MÉTODOS AUXILIARES ---

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

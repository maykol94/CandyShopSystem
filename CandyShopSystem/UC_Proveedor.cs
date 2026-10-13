using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using EntityLayer;
using FontAwesome.Sharp;
using CandyShopSystem;

namespace PresentationLayer
{
    public partial class UC_Proveedores : UserControl
    {
        private ProveedorBl objProveedorBl = new ProveedorBl();
        private BindingSource bindingSourceProveedores = new BindingSource();
        private DataTable tablaProveedores = new DataTable();

        private Image imgEditar;
        private Image imgEliminar;

        public UC_Proveedores()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(248, 249, 253);

            this.AutoSize = false;
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);

            InicializarIconosAcciones();
            EstilarGrid();

            this.Load += UC_Proveedores_Load;
            this.Resize += UC_Proveedores_Resize;
        }

        private void InicializarIconosAcciones()
        {
            imgEditar = IconChar.PenToSquare.ToBitmap(Color.FromArgb(140, 110, 230), 18);
            imgEliminar = IconChar.TrashAlt.ToBitmap(Color.FromArgb(235, 95, 115), 18);
        }

        private async void UC_Proveedores_Load(object sender, EventArgs e)
        {
            AjustarAnchoAContenedor();
            VincularEventos();
            await CargarTablaProveedoresAsync();
        }

        private void VincularEventos()
        {
            Control txtB = BuscarControlPorNombre(this, "txtBuscarProveedor") ?? BuscarControlPorNombre(this, "txtBuscar");
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

            Control btnB = BuscarControlPorNombre(this, "btnBuscarProveedor") ?? BuscarControlPorNombre(this, "btnBuscar");
            if (btnB != null)
            {
                btnB.Click -= btnBuscar_Click;
                btnB.Click += btnBuscar_Click;
            }

            Control btnN = BuscarControlPorNombre(this, "btnNuevoProveedor") ?? BuscarControlPorNombre(this, "btnNuevo");
            if (btnN != null)
            {
                btnN.Click -= btnNuevoProveedor_Click;
                btnN.Click += btnNuevoProveedor_Click;
            }

            Control dgvCtrl = BuscarControlPorNombre(this, "dgvProveedores") ?? BuscarControlPorNombre(this, "dgvData");
            if (dgvCtrl is DataGridView dgvGrid)
            {
                dgvGrid.CellContentClick -= dgvProveedores_CellContentClick;
                dgvGrid.CellContentClick += dgvProveedores_CellContentClick;

                dgvGrid.CellPainting -= dgvProveedores_CellPainting;
                dgvGrid.CellPainting += dgvProveedores_CellPainting;
            }
        }

        private void UC_Proveedores_Resize(object sender, EventArgs e)
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
            Control dgvCtrl = BuscarControlPorNombre(this, "dgvProveedores") ?? BuscarControlPorNombre(this, "dgvData");
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

        public async Task CargarTablaProveedoresAsync()
        {
            try
            {
                List<EProveedor> lista = await Task.Run(() => objProveedorBl.ObtenerProveedores());
                tablaProveedores = ConvertirListaADataTable(lista);

                bindingSourceProveedores.DataSource = tablaProveedores;

                Control dgvCtrl = BuscarControlPorNombre(this, "dgvProveedores") ?? BuscarControlPorNombre(this, "dgvData");
                if (dgvCtrl is DataGridView dgv)
                {
                    dgv.DataSource = null;
                    dgv.DataSource = bindingSourceProveedores;

                    AgregarColumnasAcciones(dgv);
                    AjustarColumnasGrid(dgv);
                }
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
            dt.Columns.Add("IdEstado", typeof(int));
            dt.Columns.Add("EstadoTexto", typeof(string));

            foreach (var item in lista)
            {
                string txtEstado = item.IdEstado == 11 ? "Activo" : "Inactivo";
                dt.Rows.Add(
                    item.IdProveedor,
                    item.NombreProveedor,
                    item.Contacto,
                    item.Telefono,
                    item.Direccion,
                    item.IdEstado,
                    txtEstado
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
                if (dgv.Columns["IdProveedor"] != null) dgv.Columns["IdProveedor"].Visible = false;
                if (dgv.Columns["IdEstado"] != null) dgv.Columns["IdEstado"].Visible = false;

                if (dgv.Columns["NombreProveedor"] != null) dgv.Columns["NombreProveedor"].HeaderText = "PROVEEDOR";
                if (dgv.Columns["Contacto"] != null) dgv.Columns["Contacto"].HeaderText = "CONTACTO";
                if (dgv.Columns["Telefono"] != null) dgv.Columns["Telefono"].HeaderText = "TELÉFONO";
                if (dgv.Columns["Direccion"] != null) dgv.Columns["Direccion"].HeaderText = "DIRECCIÓN";
                if (dgv.Columns["EstadoTexto"] != null) dgv.Columns["EstadoTexto"].HeaderText = "ESTADO";

                if (dgv.Columns["NombreProveedor"] != null) dgv.Columns["NombreProveedor"].FillWeight = 140;
                if (dgv.Columns["Contacto"] != null) dgv.Columns["Contacto"].FillWeight = 100;
                if (dgv.Columns["Telefono"] != null) dgv.Columns["Telefono"].FillWeight = 90;
                if (dgv.Columns["Direccion"] != null) dgv.Columns["Direccion"].FillWeight = 140;
                if (dgv.Columns["EstadoTexto"] != null) dgv.Columns["EstadoTexto"].FillWeight = 80;

                int index = 0;
                if (dgv.Columns["NombreProveedor"] != null) dgv.Columns["NombreProveedor"].DisplayIndex = index++;
                if (dgv.Columns["Contacto"] != null) dgv.Columns["Contacto"].DisplayIndex = index++;
                if (dgv.Columns["Telefono"] != null) dgv.Columns["Telefono"].DisplayIndex = index++;
                if (dgv.Columns["Direccion"] != null) dgv.Columns["Direccion"].DisplayIndex = index++;
                if (dgv.Columns["EstadoTexto"] != null) dgv.Columns["EstadoTexto"].DisplayIndex = index++;

                // Solo las 2 columnas de acciones al final (Editar y Eliminar)
                if (dgv.Columns["colEditar"] != null) dgv.Columns["colEditar"].DisplayIndex = index++;
                if (dgv.Columns["colEliminar"] != null) dgv.Columns["colEliminar"].DisplayIndex = index++;
            }
        }

        private void dgvProveedores_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Control dgvCtrl = BuscarControlPorNombre(this, "dgvProveedores") ?? BuscarControlPorNombre(this, "dgvData");
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
                Control txtB = BuscarControlPorNombre(this, "txtBuscarProveedor") ?? BuscarControlPorNombre(this, "txtBuscar");
                string busqueda = ObtenerTextoControl(txtB);

                if (string.IsNullOrWhiteSpace(busqueda))
                {
                    bindingSourceProveedores.Filter = string.Empty;
                    return;
                }

                busqueda = busqueda.Replace("'", "''").Trim();

                string filtroBusqueda = string.Format(
                    "NombreProveedor LIKE '%{0}%' OR Contacto LIKE '%{0}%' OR Telefono LIKE '%{0}%' OR Direccion LIKE '%{0}%' OR EstadoTexto LIKE '%{0}%'",
                    busqueda
                );

                bindingSourceProveedores.Filter = filtroBusqueda;
            }
            catch (Exception)
            {
                bindingSourceProveedores.Filter = string.Empty;
            }
        }

        private async void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Control dgvCtrl = BuscarControlPorNombre(this, "dgvProveedores") ?? BuscarControlPorNombre(this, "dgvData");
            if (dgvCtrl is DataGridView dgv)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                DataRowView rowView = row.DataBoundItem as DataRowView;

                if (rowView == null) return;

                EProveedor proveedorSeleccionado = new EProveedor()
                {
                    IdProveedor = Convert.ToInt32(rowView["IdProveedor"]),
                    NombreProveedor = rowView["NombreProveedor"].ToString(),
                    Contacto = rowView["Contacto"] != DBNull.Value ? rowView["Contacto"].ToString() : "",
                    Telefono = rowView["Telefono"] != DBNull.Value ? rowView["Telefono"].ToString() : "",
                    Direccion = rowView["Direccion"] != DBNull.Value ? rowView["Direccion"].ToString() : "",
                    IdEstado = Convert.ToInt32(rowView["IdEstado"])
                };

                string colName = dgv.Columns[e.ColumnIndex].Name;

                // Editar Proveedor
                if (colName == "colEditar")
                {
                    using (FormEditarProveedor modal = new FormEditarProveedor(proveedorSeleccionado))
                    {
                        if (modal.ShowDialog() == DialogResult.OK)
                        {
                            await CargarTablaProveedoresAsync();
                        }
                    }
                }
                // Eliminar Proveedor
                else if (colName == "colEliminar")
                {
                    var result = MessageBox.Show(
                        $"¿Está seguro de eliminar al proveedor '{proveedorSeleccionado.NombreProveedor}'?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        string mensaje = string.Empty;
                        bool respuesta = objProveedorBl.EliminarProveedor(proveedorSeleccionado.IdProveedor, out mensaje);

                        if (respuesta)
                        {
                            MessageBox.Show("¡Proveedor eliminado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await CargarTablaProveedoresAsync();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el proveedor: " + mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private async void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            using (FormRegistrarProveedor modal = new FormRegistrarProveedor())
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    await CargarTablaProveedoresAsync();
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

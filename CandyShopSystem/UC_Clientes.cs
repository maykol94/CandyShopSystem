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
    public partial class UC_Clientes : UserControl
    {
        private ClienteBL objClienteBL = new ClienteBL();
        private BindingSource bindingSourceClientes = new BindingSource();
        private DataTable tablaClientes = new DataTable();

        //estructura de datos: cola de atención de clientes
        private Queue<ECliente> colaAtencionClientes = new Queue<ECliente>();

        private Image imgVer;
        private Image imgEditar;
        private Image imgEliminar;

        public UC_Clientes()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(248, 249, 253);

            this.AutoSize = false;
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);

            InicializarIconosAcciones();
            EstilarGrid();

            this.Load += UC_Clientes_Load;
            this.Resize += UC_Clientes_Resize;
        }

        private void InicializarIconosAcciones()
        {
            // Colores: Azul suave para ver, lila para editar y rosa para eliminar
            imgVer = IconChar.BookOpen.ToBitmap(Color.FromArgb(100, 130, 200), 18);
            imgEditar = IconChar.PenToSquare.ToBitmap(Color.FromArgb(140, 110, 230), 18);
            imgEliminar = IconChar.TrashAlt.ToBitmap(Color.FromArgb(235, 95, 115), 18);
        }

        private async void UC_Clientes_Load(object sender, EventArgs e)
        {
            AjustarAnchoAContenedor();
            VincularEventos();
            await CargarTablaClientesAsync();
        }

        private void VincularEventos()
        {
            Control txtB = BuscarControlPorNombre(this, "txtBuscar");
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

            Control btnB = BuscarControlPorNombre(this, "btnBuscar");
            if (btnB != null)
            {
                btnB.Click -= btnBuscar_Click;
                btnB.Click += btnBuscar_Click;
            }

            Control btnN = BuscarControlPorNombre(this, "btnNuevoCliente") ?? BuscarControlPorNombre(this, "btnNuevo");
            if (btnN != null)
            {
                btnN.Click -= btnNuevoCliente_Click;
                btnN.Click += btnNuevoCliente_Click;
            }

            // Vincular el botón de atender cliente en la cola
            Control btnAtender = BuscarControlPorNombre(this, "btnAtenderCliente") ?? BuscarControlPorNombre(this, "btnAtender");
            if (btnAtender != null)
            {
                btnAtender.Click -= btnAtenderCliente_Click;
                btnAtender.Click += btnAtenderCliente_Click;
            }

            if (dgvClientes != null)
            {
                dgvClientes.FilterStringChanged -= dgvClientes_FilterStringChanged;
                dgvClientes.FilterStringChanged += dgvClientes_FilterStringChanged;

                dgvClientes.SortStringChanged -= dgvClientes_SortStringChanged;
                dgvClientes.SortStringChanged += dgvClientes_SortStringChanged;

                dgvClientes.CellContentClick -= dgvClientes_CellContentClick;
                dgvClientes.CellContentClick += dgvClientes_CellContentClick;

                dgvClientes.CellPainting -= dgvClientes_CellPainting;
                dgvClientes.CellPainting += dgvClientes_CellPainting;
            }
        }

        private void UC_Clientes_Resize(object sender, EventArgs e)
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
            if (dgvClientes == null) return;

            dgvClientes.BackgroundColor = Color.White;
            dgvClientes.BorderStyle = BorderStyle.None;
            dgvClientes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvClientes.GridColor = Color.FromArgb(245, 240, 243);
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.ReadOnly = true;

            dgvClientes.RowHeadersVisible = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.Dock = DockStyle.Fill;

            dgvClientes.EnableHeadersVisualStyles = false;
            dgvClientes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(253, 242, 244);
            dgvClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(190, 46, 95);
            dgvClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvClientes.ColumnHeadersHeight = 42;

            dgvClientes.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dgvClientes.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);

            dgvClientes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 226, 233);
            dgvClientes.DefaultCellStyle.SelectionForeColor = Color.FromArgb(190, 46, 95);
            dgvClientes.DefaultCellStyle.ForeColor = Color.FromArgb(70, 70, 80);
            dgvClientes.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvClientes.RowTemplate.Height = 38;
        }

        public async Task CargarTablaClientesAsync()
        {
            try
            {
                List<ECliente> lista = await Task.Run(() => objClienteBL.ObtenerClientes());
                tablaClientes = ConvertirListaADataTable(lista);

                // Cargar también la Cola de Atención con los clientes recuperados
                colaAtencionClientes.Clear();
                foreach (var c in lista)
                {
                    colaAtencionClientes.Enqueue(c);
                }

                bindingSourceClientes.DataSource = tablaClientes;
                dgvClientes.DataSource = null;
                dgvClientes.DataSource = bindingSourceClientes;

                AgregarColumnasAcciones();
                AjustarColumnasGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ConvertirListaADataTable(List<ECliente> lista)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdCliente", typeof(int));
            dt.Columns.Add("NombreCliente", typeof(string));
            dt.Columns.Add("Contacto", typeof(string));
            dt.Columns.Add("Direccion", typeof(string));
            dt.Columns.Add("NombreNegocio", typeof(string));
            dt.Columns.Add("IdTipoCliente", typeof(int));
            dt.Columns.Add("TipoClienteDescripcion", typeof(string));

            foreach (var item in lista)
            {
                dt.Rows.Add(
                    item.IdCliente,
                    item.NombreCliente,
                    item.Contacto,
                    item.Direccion,
                    item.NombreNegocio,
                    item.IdTipoCliente,
                    item.TipoClienteDescripcion
                );
            }

            return dt;
        }

        private void AgregarColumnasAcciones()
        {
            if (dgvClientes.Columns["colVer"] == null)
            {
                DataGridViewButtonColumn btnVer = new DataGridViewButtonColumn();
                btnVer.Name = "colVer";
                btnVer.HeaderText = "";
                btnVer.Width = 35;
                btnVer.FlatStyle = FlatStyle.Flat;
                dgvClientes.Columns.Add(btnVer);
            }

            if (dgvClientes.Columns["colEditar"] == null)
            {
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                btnEditar.Name = "colEditar";
                btnEditar.HeaderText = "";
                btnEditar.Width = 35;
                btnEditar.FlatStyle = FlatStyle.Flat;
                dgvClientes.Columns.Add(btnEditar);
            }

            if (dgvClientes.Columns["colEliminar"] == null)
            {
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.Name = "colEliminar";
                btnEliminar.HeaderText = "";
                btnEliminar.Width = 35;
                btnEliminar.FlatStyle = FlatStyle.Flat;
                dgvClientes.Columns.Add(btnEliminar);
            }
        }

        private void AjustarColumnasGrid()
        {
            if (dgvClientes.Columns.Count > 0)
            {
                if (dgvClientes.Columns["IdCliente"] != null) dgvClientes.Columns["IdCliente"].Visible = false;
                if (dgvClientes.Columns["IdTipoCliente"] != null) dgvClientes.Columns["IdTipoCliente"].Visible = false;

                if (dgvClientes.Columns["NombreCliente"] != null) dgvClientes.Columns["NombreCliente"].HeaderText = "CLIENTE";
                if (dgvClientes.Columns["Contacto"] != null) dgvClientes.Columns["Contacto"].HeaderText = "CONTACTO";
                if (dgvClientes.Columns["Direccion"] != null) dgvClientes.Columns["Direccion"].HeaderText = "DIRECCIÓN";
                if (dgvClientes.Columns["NombreNegocio"] != null) dgvClientes.Columns["NombreNegocio"].HeaderText = "NEGOCIO";
                if (dgvClientes.Columns["TipoClienteDescripcion"] != null) dgvClientes.Columns["TipoClienteDescripcion"].HeaderText = "TIPO CLIENTE";

                if (dgvClientes.Columns["NombreCliente"] != null) dgvClientes.Columns["NombreCliente"].FillWeight = 130;
                if (dgvClientes.Columns["Contacto"] != null) dgvClientes.Columns["Contacto"].FillWeight = 90;
                if (dgvClientes.Columns["Direccion"] != null) dgvClientes.Columns["Direccion"].FillWeight = 130;
                if (dgvClientes.Columns["NombreNegocio"] != null) dgvClientes.Columns["NombreNegocio"].FillWeight = 110;
                if (dgvClientes.Columns["TipoClienteDescripcion"] != null) dgvClientes.Columns["TipoClienteDescripcion"].FillWeight = 100;

                int index = 0;
                if (dgvClientes.Columns["NombreCliente"] != null) dgvClientes.Columns["NombreCliente"].DisplayIndex = index++;
                if (dgvClientes.Columns["Contacto"] != null) dgvClientes.Columns["Contacto"].DisplayIndex = index++;
                if (dgvClientes.Columns["Direccion"] != null) dgvClientes.Columns["Direccion"].DisplayIndex = index++;
                if (dgvClientes.Columns["NombreNegocio"] != null) dgvClientes.Columns["NombreNegocio"].DisplayIndex = index++;
                if (dgvClientes.Columns["TipoClienteDescripcion"] != null) dgvClientes.Columns["TipoClienteDescripcion"].DisplayIndex = index++;

                // Los 3 botones de acción al final
                if (dgvClientes.Columns["colVer"] != null) dgvClientes.Columns["colVer"].DisplayIndex = index++;
                if (dgvClientes.Columns["colEditar"] != null) dgvClientes.Columns["colEditar"].DisplayIndex = index++;
                if (dgvClientes.Columns["colEliminar"] != null) dgvClientes.Columns["colEliminar"].DisplayIndex = index++;
            }
        }

        private void dgvClientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dgvClientes.Columns[e.ColumnIndex].Name;

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

        private void dgvClientes_FilterStringChanged(object sender, EventArgs e)
        {
            try { bindingSourceClientes.Filter = dgvClientes.FilterString; } catch { }
        }

        private void dgvClientes_SortStringChanged(object sender, EventArgs e)
        {
            try { bindingSourceClientes.Sort = dgvClientes.SortString; } catch { }
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
                    bindingSourceClientes.Filter = string.Empty;
                    return;
                }

                busqueda = busqueda.Replace("'", "''").Trim();

                string filtroBusqueda = string.Format(
                    "NombreCliente LIKE '%{0}%' OR Contacto LIKE '%{0}%' OR Direccion LIKE '%{0}%' OR NombreNegocio LIKE '%{0}%' OR TipoClienteDescripcion LIKE '%{0}%'",
                    busqueda
                );

                bindingSourceClientes.Filter = filtroBusqueda;
            }
            catch (Exception)
            {
                bindingSourceClientes.Filter = string.Empty;
            }
        }

        private async void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvClientes.Rows[e.RowIndex];
            DataRowView rowView = row.DataBoundItem as DataRowView;

            if (rowView == null) return;

            ECliente clienteSeleccionado = new ECliente()
            {
                IdCliente = Convert.ToInt32(rowView["IdCliente"]),
                NombreCliente = rowView["NombreCliente"].ToString(),
                Contacto = rowView["Contacto"].ToString(),
                Direccion = rowView["Direccion"].ToString(),
                NombreNegocio = rowView["NombreNegocio"] != DBNull.Value ? rowView["NombreNegocio"].ToString() : "",
                TipoCliente = rowView["TipoClienteDescripcion"] != DBNull.Value ? rowView["TipoClienteDescripcion"].ToString() : "",
                IdTipoCliente = rowView["IdTipoCliente"] != DBNull.Value ? Convert.ToInt32(rowView["IdTipoCliente"]) : 0
            };

            string colName = dgvClientes.Columns[e.ColumnIndex].Name;

            // para ver los detalles del cliente
            if (colName == "colVer")
            {
                using (FormClienteModal modal = new FormClienteModal(clienteSeleccionado, esSoloLectura: true))
                {
                    modal.ShowDialog();
                }
            }
            // para poder editar cliente
            else if (colName == "colEditar")
            {
                using (FormEditarCliente modal = new FormEditarCliente(clienteSeleccionado))
                {
                    if (modal.ShowDialog() == DialogResult.OK)
                    {
                        await CargarTablaClientesAsync();
                    }
                }
            }
            // para eliminar cliente
            else if (colName == "colEliminar")
            {
                var result = MessageBox.Show(
                    $"¿Está seguro de eliminar al cliente '{clienteSeleccionado.NombreCliente}'?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    bool respuesta = objClienteBL.EliminarCliente(clienteSeleccionado.IdCliente, out mensaje);

                    if (respuesta)
                    {
                        MessageBox.Show("¡Cliente eliminado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await CargarTablaClientesAsync();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el cliente: " + mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private async void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            using (FormClienteModal modal = new FormClienteModal())
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    await CargarTablaClientesAsync();
                }
            }
        }

        //estructura de datos: cola de atención de clientes 
        private void btnAtenderCliente_Click(object sender, EventArgs e)
        {
            if (colaAtencionClientes != null && colaAtencionClientes.Count > 0)
            {
                //saca al cliente que está al frente de la cola para atenderlo
                ECliente clienteParaAtender = colaAtencionClientes.Dequeue();

                //abre el formulario de atención al cliente con el cliente que se acaba de sacar de la cola
                using (FormAtenderCliente modal = new FormAtenderCliente(clienteParaAtender, colaAtencionClientes.Count))
                {
                    modal.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("No hay clientes pendientes en la cola de atención.", "Cola Vacía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
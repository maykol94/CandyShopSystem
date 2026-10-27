using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using EntityLayer;

namespace CandyShopSystem
{
    public partial class UC_Pedidos : UserControl
    {
        private PedidoBl objPedidoBl = new PedidoBl();
        private BindingSource bindingSourcePedidos = new BindingSource();
        private DataTable tablaPedidos = new DataTable();

        public UC_Pedidos()
        {
            InitializeComponent();

            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.FromArgb(253, 246, 248);
            this.Dock = DockStyle.Fill;

            EstilarGrid();

            this.Load += UC_Pedidos_Load;
        }

        private async void UC_Pedidos_Load(object sender, EventArgs e)
        {
            VincularEventos();
            await CargarPedidosDesdeBDAsync();
        }

        private void VincularEventos()
        {
            Control btnNuevo = BuscarControlPorNombre(this, "btnNuevoPedido") ?? BuscarControlPorNombre(this, "btnNuevosPedidos") ?? BuscarControlPorNombre(this, "btnNuevos");
            if (btnNuevo != null)
            {
                btnNuevo.Click -= btnNuevoPedido_Click;
                btnNuevo.Click += btnNuevoPedido_Click;
            }

            Control btnDespachar = BuscarControlPorNombre(this, "btnDespacharPedido") ?? BuscarControlPorNombre(this, "btnDespachar");
            if (btnDespachar != null)
            {
                btnDespachar.Click -= btnDespacharPedido_Click;
                btnDespachar.Click += btnDespacharPedido_Click;
            }

            if (dgvPedidos != null)
            {
                dgvPedidos.CellPainting -= dgvPedidos_CellPainting;
                dgvPedidos.CellPainting += dgvPedidos_CellPainting;
            }
        }

        private void EstilarGrid()
        {
            if (dgvPedidos == null) return;

            dgvPedidos.BackgroundColor = Color.White;
            dgvPedidos.BorderStyle = BorderStyle.None;
            dgvPedidos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPedidos.GridColor = Color.FromArgb(248, 242, 244);
            dgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedidos.ReadOnly = true;

            dgvPedidos.RowHeadersVisible = false;
            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPedidos.Dock = DockStyle.Fill;

            dgvPedidos.EnableHeadersVisualStyles = false;
            dgvPedidos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPedidos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(254, 243, 246);
            dgvPedidos.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(170, 70, 100);
            dgvPedidos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.0F, FontStyle.Bold);
            dgvPedidos.ColumnHeadersHeight = 40;

            dgvPedidos.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 0, 0, 0);
            dgvPedidos.DefaultCellStyle.Padding = new Padding(12, 0, 0, 0);

            dgvPedidos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 235, 240);
            dgvPedidos.DefaultCellStyle.SelectionForeColor = Color.FromArgb(170, 70, 100);
            dgvPedidos.DefaultCellStyle.ForeColor = Color.FromArgb(80, 80, 90);
            dgvPedidos.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvPedidos.RowTemplate.Height = 48;
        }

        public async Task CargarPedidosDesdeBDAsync()
        {
            try
            {
                DataTable tablaOriginal = await Task.Run(() => objPedidoBl.ObtenerTablaPedidosPendientes());

                // Creamos una copia o filtramos la tabla para excluir los entregados
                tablaPedidos = tablaOriginal.Clone(); 

                if (!tablaPedidos.Columns.Contains("estado_texto"))
                {
                    tablaPedidos.Columns.Add("estado_texto", typeof(string));
                }

                foreach (DataRow row in tablaOriginal.Rows)
                {
                    int idEstado = 13;
                    if (tablaOriginal.Columns.Contains("id_estado") && row["id_estado"] != DBNull.Value)
                    {
                        idEstado = Convert.ToInt32(row["id_estado"]);
                    }
                    else if (tablaOriginal.Columns.Contains("IdEstado") && row["IdEstado"] != DBNull.Value)
                    {
                        idEstado = Convert.ToInt32(row["IdEstado"]);
                    }

                    string textoEstado = "Pendiente";
                    if (idEstado == 14)
                    {
                        textoEstado = "En ruta";
                    }
                    else if (idEstado == 15)
                    {
                        textoEstado = "Entregado";
                        
                        continue;
                    }

                    // Importamos la fila a nuestra tabla filtrada y le asignamos su texto
                    DataRow nuevaFila = tablaPedidos.NewRow();
                    nuevaFila.ItemArray = row.ItemArray;
                    nuevaFila["estado_texto"] = textoEstado;
                    tablaPedidos.Rows.Add(nuevaFila);
                }

                bindingSourcePedidos.DataSource = tablaPedidos;
                dgvPedidos.DataSource = bindingSourcePedidos;

                AjustarEncabezadosGrid();
                ActualizarEtiquetaContador();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar pedidos: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AjustarEncabezadosGrid()
        {
            if (dgvPedidos.Columns.Count > 0)
            {
                if (dgvPedidos.Columns["id_pedido"] != null)
                {
                    dgvPedidos.Columns["id_pedido"].HeaderText = "N° PEDIDO";
                    dgvPedidos.Columns["id_pedido"].FillWeight = 80;
                }
                if (dgvPedidos.Columns["id_factura"] != null)
                {
                    dgvPedidos.Columns["id_factura"].HeaderText = "N° FACTURA";
                    dgvPedidos.Columns["id_factura"].FillWeight = 80;
                }
                if (dgvPedidos.Columns["fecha_entrega"] != null)
                {
                    dgvPedidos.Columns["fecha_entrega"].HeaderText = "FECHA";
                    dgvPedidos.Columns["fecha_entrega"].FillWeight = 90;
                }
                if (dgvPedidos.Columns["direccion_adicional"] != null)
                {
                    dgvPedidos.Columns["direccion_adicional"].HeaderText = "CLIENTE / DIRECCIÓN";
                    dgvPedidos.Columns["direccion_adicional"].FillWeight = 220;
                }
                if (dgvPedidos.Columns["estado_texto"] != null)
                {
                    dgvPedidos.Columns["estado_texto"].HeaderText = "ESTADO";
                    dgvPedidos.Columns["estado_texto"].FillWeight = 90;
                }
            }
        }

        private void dgvPedidos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dgvPedidos.Columns[e.ColumnIndex].Name;

            if (colName == "estado_texto")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                string estadoStr = e.Value != null ? e.Value.ToString().Trim() : "";

                // Colores predeterminados (Pendiente)
                Color bgBadge = Color.FromArgb(254, 243, 199);
                Color textBadge = Color.FromArgb(180, 130, 20);

                if (estadoStr.Equals("En ruta", StringComparison.OrdinalIgnoreCase))
                {
                    bgBadge = Color.FromArgb(224, 231, 255); // Azul claro suave
                    textBadge = Color.FromArgb(67, 56, 202);  // Azul oscuro/índigo
                }
                else if (estadoStr.Equals("Entregado", StringComparison.OrdinalIgnoreCase) || estadoStr.Equals("Listo", StringComparison.OrdinalIgnoreCase))
                {
                    bgBadge = Color.FromArgb(220, 252, 231); // Verde claro
                    textBadge = Color.FromArgb(22, 101, 52);   // Verde oscuro
                }

                Rectangle rectBadge = new Rectangle(e.CellBounds.Left + 8, e.CellBounds.Top + 10, 95, 26);
                using (GraphicsPath path = CrearPathRedondeado(rectBadge, 12))
                using (SolidBrush brushBg = new SolidBrush(bgBadge))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(brushBg, path);

                    using (Font fontBadge = new Font("Segoe UI", 8.5F, FontStyle.Bold))
                    {
                        TextRenderer.DrawText(e.Graphics, estadoStr, fontBadge, rectBadge, textBadge,
                            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    }
                }
                e.Handled = true;
            }
        }

        private GraphicsPath CrearPathRedondeado(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        private async void btnNuevoPedido_Click(object sender, EventArgs e)
        {
            using (FormRegistrarPedido frm = new FormRegistrarPedido())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    await CargarPedidosDesdeBDAsync();
                }
            }
        }

        private async void btnDespacharPedido_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.SelectedRows.Count > 0)
            {
                int idPedidoSeleccionado = Convert.ToInt32(dgvPedidos.SelectedRows[0].Cells["id_pedido"].Value);

                string mensajeBD = string.Empty;
                bool despachadoBD = objPedidoBl.DespacharPedido(idPedidoSeleccionado, out mensajeBD);

                if (despachadoBD)
                {
                    MessageBox.Show(
                        $"¡Pedido #{idPedidoSeleccionado} despachado con éxito!",
                        "Éxito al Despachar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    await CargarPedidosDesdeBDAsync();
                }
                else
                {
                    MessageBox.Show("No se pudo despachar el pedido: " + mensajeBD, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un pedido de la lista para despachar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ActualizarEtiquetaContador()
        {
            Control lblContador = BuscarControlPorNombre(this, "lblContadorCola") ?? BuscarControlPorNombre(this, "lblPedidosPendientes");
            if (lblContador != null)
            {
                lblContador.Text = $"Pedidos pendientes: {dgvPedidos.Rows.Count}";
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
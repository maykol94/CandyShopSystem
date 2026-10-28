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
    public partial class UC_Ventas : UserControl
    {
        private ClienteBl objClienteBl = new ClienteBl();
        private InventarioBl objInventarioBl = new InventarioBl();
        private VentasBl objVentasBl = new VentasBl();

        private List<ECliente> listaClientes = new List<ECliente>();
        private List<EInventario> listaInventario = new List<EInventario>();
        private DataTable dtCarrito = new DataTable();

        public UC_Ventas()
        {
            InitializeComponent();

            EstilarDataGridViewCarrito();
            InicializarEstructuraCarrito();
            MostrarInformacionSesion();
            CargarFormasDePago();

            this.SizeChanged += (s, e) => AjustarLayoutPantallaCompleta();
        }

        protected override async void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (!DesignMode)
            {
                AjustarLayoutPantallaCompleta();
                await CargarClientesAsync();
                await CargarProductosInventarioAsync();
            }
        }

        private async void UC_Ventas_Load(object sender, EventArgs e)
        {
            MostrarInformacionSesion();
            AjustarLayoutPantallaCompleta();
            await CargarClientesAsync();
            await CargarProductosInventarioAsync();
        }

        private void AjustarLayoutPantallaCompleta()
        {
            int margenIzq = 20;
            int margenDer = 20;
            int anchoDisponible = this.ClientSize.Width - margenIzq - margenDer;

            if (anchoDisponible < 500) return;

            int anchoMediaTarjeta = (anchoDisponible - 15) / 2;

            if (panelCliente != null)
            {
                panelCliente.Left = margenIzq;
                panelCliente.Width = anchoMediaTarjeta;
            }

            if (panelAtendidoPor != null)
            {
                panelAtendidoPor.Left = margenIzq + anchoMediaTarjeta + 15;
                panelAtendidoPor.Width = anchoMediaTarjeta;

                if (lblFechaHora != null)
                {
                    lblFechaHora.Left = panelAtendidoPor.Width - lblFechaHora.Width - 15;
                }
            }

            if (panelFormaPago != null)
            {
                panelFormaPago.Left = margenIzq;
                panelFormaPago.Width = anchoMediaTarjeta;
            }

            if (panelDescuento != null)
            {
                panelDescuento.Left = margenIzq + anchoMediaTarjeta + 15;
                panelDescuento.Width = anchoMediaTarjeta;
            }

            if (panelProductos != null)
            {
                panelProductos.Left = margenIzq;
                panelProductos.Width = anchoDisponible;

                if (cboProducto != null)
                {
                    cboProducto.Width = 280;
                }
            }

            if (panelcarrito != null)
            {
                panelcarrito.Left = margenIzq;
                panelcarrito.Width = anchoDisponible;

                if (dgvCarrito != null)
                {
                    dgvCarrito.Left = 0;
                    dgvCarrito.Top = 0;
                    dgvCarrito.Width = panelcarrito.Width;
                    dgvCarrito.Height = panelcarrito.Height;
                }
            }

            if (panelTotales != null && panelcarrito != null)
            {
                panelTotales.Left = (panelcarrito.Left + panelcarrito.Width) - panelTotales.Width;
            }
        }

        private void EstilarDataGridViewCarrito()
        {
            dgvCarrito.BackgroundColor = Color.White;
            dgvCarrito.BorderStyle = BorderStyle.None;
            dgvCarrito.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCarrito.GridColor = Color.FromArgb(245, 230, 238);

            dgvCarrito.RowHeadersVisible = false;
            dgvCarrito.AllowUserToAddRows = false;
            dgvCarrito.EnableHeadersVisualStyles = false;
            dgvCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarrito.MultiSelect = false;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(253, 226, 236),
                ForeColor = Color.FromArgb(190, 46, 95),
                Font = new Font("Segoe UI", 9.0f, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(4)
            };
            dgvCarrito.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCarrito.ColumnHeadersHeight = 36;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(60, 60, 60),
                Font = new Font("Segoe UI", 9.0f, FontStyle.Regular),
                SelectionBackColor = Color.FromArgb(255, 210, 225),
                SelectionForeColor = Color.FromArgb(190, 46, 95),
                Padding = new Padding(4)
            };
            dgvCarrito.DefaultCellStyle = rowStyle;
            dgvCarrito.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 248, 251);
            dgvCarrito.RowTemplate.Height = 30;

            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void MostrarInformacionSesion()
        {
            if (lblNombreTrabajador != null)
            {
                lblNombreTrabajador.Text = string.IsNullOrWhiteSpace(SesionUsuario.NombreCompleto)
                    ? (string.IsNullOrWhiteSpace(SesionUsuario.NombreUsuario) ? "Daleska" : SesionUsuario.NombreUsuario)
                    : SesionUsuario.NombreCompleto;
            }

            if (lblFechaHora != null)
            {
                lblFechaHora.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void CargarFormasDePago()
        {
            if (cboFormaPago != null)
            {
                cboFormaPago.Items.Clear();
                cboFormaPago.Items.Add("Efectivo");
                cboFormaPago.SelectedIndex = 0;
            }
        }

        private async Task CargarClientesAsync()
        {
            try
            {
                listaClientes = await Task.Run(() => objClienteBl.ObtenerClientes());

                if (listaClientes != null && listaClientes.Count > 0 && cboCliente != null)
                {
                    cboCliente.SelectedIndexChanged -= cboCliente_SelectedIndexChanged;

                    cboCliente.DataSource = listaClientes;
                    cboCliente.DisplayMember = "NombreCliente";
                    cboCliente.ValueMember = "IdCliente";

                    cboCliente.SelectedIndexChanged += cboCliente_SelectedIndexChanged;
                    ActualizarEtiquetaTipoCliente();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarEtiquetaTipoCliente();
        }

        private void ActualizarEtiquetaTipoCliente()
        {
            if (cboCliente != null && cboCliente.SelectedItem is ECliente cliente && lblTipoCliente != null)
            {
                lblTipoCliente.Text = $"Tipo: {cliente.TipoCliente}";
            }
        }

        private async Task CargarProductosInventarioAsync()
        {
            try
            {
                listaInventario = await objInventarioBl.ObtenerInventarioAsync();

                if (listaInventario != null && listaInventario.Count > 0 && cboProducto != null)
                {
                    var disponibles = listaInventario.Where(x => x.CantidadDisponible > 0).ToList();

                    cboProducto.SelectedIndexChanged -= cboProducto_SelectedIndexChanged;

                    cboProducto.DataSource = disponibles;
                    cboProducto.DisplayMember = "Producto";
                    cboProducto.ValueMember = "IdVariacion";

                    cboProducto.SelectedIndexChanged += cboProducto_SelectedIndexChanged;
                    ActualizarDetallesProductoSeleccionado();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar inventario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarDetallesProductoSeleccionado();
        }

        private void ActualizarDetallesProductoSeleccionado()
        {
            if (cboProducto != null && cboProducto.SelectedItem is EInventario prod)
            {
                if (lblC != null) lblC.Text = "";

                if (lblDisponibles != null) lblDisponibles.Text = $"Disponibles: {prod.CantidadDisponible}";
                if (lblPrecioVenta != null) lblPrecioVenta.Text = $"C$ {prod.PrecioVenta:N2}";

                if (nudCantidad != null)
                {
                    nudCantidad.Minimum = 1;
                    nudCantidad.Maximum = prod.CantidadDisponible > 0 ? prod.CantidadDisponible : 1;
                    nudCantidad.Value = 1;
                }
            }
        }

        #region --- 4. CARRITO DE COMPRAS Y DESCUENTOS ---

        private void InicializarEstructuraCarrito()
        {
            dtCarrito = new DataTable();
            dtCarrito.Columns.Add("IdStock", typeof(int));
            dtCarrito.Columns.Add("IdVariacion", typeof(int));
            dtCarrito.Columns.Add("Producto", typeof(string));
            dtCarrito.Columns.Add("Cantidad", typeof(int));
            dtCarrito.Columns.Add("Precio", typeof(decimal));
            dtCarrito.Columns.Add("DescuentoUnitario", typeof(decimal));
            dtCarrito.Columns.Add("Subtotal", typeof(decimal), "Cantidad * (Precio - DescuentoUnitario)");

            dgvCarrito.DataSource = dtCarrito;
            ConfigurarColumnasGrid();
        }

        private void ConfigurarColumnasGrid()
        {
            if (dgvCarrito.Columns["IdStock"] != null) dgvCarrito.Columns["IdStock"].Visible = false;
            if (dgvCarrito.Columns["IdVariacion"] != null) dgvCarrito.Columns["IdVariacion"].Visible = false;

            if (dgvCarrito.Columns["Producto"] != null) dgvCarrito.Columns["Producto"].HeaderText = "PRODUCTO / VARIACIÓN";
            if (dgvCarrito.Columns["Cantidad"] != null) dgvCarrito.Columns["Cantidad"].HeaderText = "CANTIDAD";
            if (dgvCarrito.Columns["Precio"] != null) dgvCarrito.Columns["Precio"].HeaderText = "PRECIO";
            if (dgvCarrito.Columns["DescuentoUnitario"] != null) dgvCarrito.Columns["DescuentoUnitario"].HeaderText = "DESCUENTO UNIT.";
            if (dgvCarrito.Columns["Subtotal"] != null) dgvCarrito.Columns["Subtotal"].HeaderText = "SUBTOTAL";

            if (dgvCarrito.Columns["Producto"] != null) dgvCarrito.Columns["Producto"].FillWeight = 200;
            if (dgvCarrito.Columns["Cantidad"] != null) dgvCarrito.Columns["Cantidad"].FillWeight = 70;
            if (dgvCarrito.Columns["Precio"] != null) dgvCarrito.Columns["Precio"].FillWeight = 90;
            if (dgvCarrito.Columns["DescuentoUnitario"] != null) dgvCarrito.Columns["DescuentoUnitario"].FillWeight = 100;
            if (dgvCarrito.Columns["Subtotal"] != null) dgvCarrito.Columns["Subtotal"].FillWeight = 100;

            if (dgvCarrito.Columns["Precio"] != null) dgvCarrito.Columns["Precio"].DefaultCellStyle.Format = "C$ #,##0.00";
            if (dgvCarrito.Columns["DescuentoUnitario"] != null) dgvCarrito.Columns["DescuentoUnitario"].DefaultCellStyle.Format = "C$ #,##0.00";
            if (dgvCarrito.Columns["Subtotal"] != null) dgvCarrito.Columns["Subtotal"].DefaultCellStyle.Format = "C$ #,##0.00";
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            if (cboProducto == null || !(cboProducto.SelectedItem is EInventario prod))
            {
                MessageBox.Show("Seleccione un producto del catálogo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad = nudCantidad != null ? (int)nudCantidad.Value : 1;
            if (cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string valorTexto = "";

            if (txtDescuentoGlobal != null)
            {
                valorTexto = txtDescuentoGlobal.Text;
            }

            if (string.IsNullOrWhiteSpace(valorTexto) && panelDescuento != null)
            {
                foreach (Control c in panelDescuento.Controls)
                {
                    if (!string.IsNullOrWhiteSpace(c.Text) && c.Text != "Cordobas" && c.Text != "Descuento")
                    {
                        valorTexto = c.Text;
                        break;
                    }
                }
            }

            decimal descuentoIngresado = 0;
            if (!string.IsNullOrWhiteSpace(valorTexto))
            {
                string textoLimpio = new string(valorTexto.Where(c => char.IsDigit(c) || c == '.' || c == ',').ToArray());
                decimal.TryParse(textoLimpio, out descuentoIngresado);
            }

            DataRow filaExistente = dtCarrito.AsEnumerable()
                .FirstOrDefault(row => row.Field<int>("IdVariacion") == prod.IdVariacion);

            if (filaExistente != null)
            {
                int cantidadActual = filaExistente.Field<int>("Cantidad");
                if (cantidadActual + cantidad > prod.CantidadDisponible)
                {
                    MessageBox.Show($"Supera el stock disponible ({prod.CantidadDisponible}).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                filaExistente["Cantidad"] = cantidadActual + cantidad;
                filaExistente["DescuentoUnitario"] = descuentoIngresado;
            }
            else
            {
                dtCarrito.Rows.Add(prod.IdStock, prod.IdVariacion, prod.Producto, cantidad, prod.PrecioVenta, descuentoIngresado);
            }

            CalcularTotalesVenta();
        }

        private void CalcularTotalesVenta()
        {
            decimal subtotalBruto = 0;
            decimal totalDescuentosEnCarrito = 0;

            foreach (DataRow row in dtCarrito.Rows)
            {
                int cant = Convert.ToInt32(row["Cantidad"]);
                decimal prec = Convert.ToDecimal(row["Precio"]);
                decimal descUnit = Convert.ToDecimal(row["DescuentoUnitario"]);

                subtotalBruto += (cant * prec);
                totalDescuentosEnCarrito += (cant * descUnit);
            }

            decimal descuentoAdicionalGlobal = 0;
            if (txtDescuentoGlobal != null && !string.IsNullOrWhiteSpace(txtDescuentoGlobal.Text))
            {
                string textoLimpio = new string(txtDescuentoGlobal.Text.Where(c => char.IsDigit(c) || c == '.' || c == ',').ToArray());
                decimal.TryParse(textoLimpio, out descuentoAdicionalGlobal);
            }

            decimal descuentoTotalFactura = totalDescuentosEnCarrito > 0 ? totalDescuentosEnCarrito : descuentoAdicionalGlobal;
            decimal montoTotalFinal = subtotalBruto - descuentoTotalFactura;

            if (montoTotalFinal < 0) montoTotalFinal = 0;

            if (lblSubtotal != null) lblSubtotal.Text = $"C$ {subtotalBruto:N2}";
            if (lblDescuento != null) lblDescuento.Text = $"C$ {descuentoTotalFactura:N2}";
            if (lblMontoTotal != null) lblMontoTotal.Text = $"C$ {montoTotalFinal:N2}";
        }

        private void txtDescuentoGlobal_TextChanged(object sender, EventArgs e)
        {
            CalcularTotalesVenta();
        }

        private async void btnProcesarVenta_Click(object sender, EventArgs e)
        {
            if (dtCarrito.Rows.Count == 0)
            {
                MessageBox.Show("El carrito de compras está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboCliente == null || cboCliente.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un cliente válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnProcesarVenta.Enabled = false;

                decimal totalDescuentoCalculado = 0;
                foreach (DataRow row in dtCarrito.Rows)
                {
                    totalDescuentoCalculado += (Convert.ToInt32(row["Cantidad"]) * Convert.ToDecimal(row["DescuentoUnitario"]));
                }

                EFactura factura = new EFactura
                {
                    IdCliente = Convert.ToInt32(cboCliente.SelectedValue),
                    IdTrabajador = SesionUsuario.IdTrabajador > 0 ? SesionUsuario.IdTrabajador : 1,
                    FormaPago = cboFormaPago != null && cboFormaPago.SelectedItem != null ? cboFormaPago.SelectedItem.ToString() : "Efectivo",
                    DescuentoFactura = totalDescuentoCalculado
                };

                List<EDetalleFactura> carrito = new List<EDetalleFactura>();
                foreach (DataRow row in dtCarrito.Rows)
                {
                    carrito.Add(new EDetalleFactura
                    {
                        IdVariacion = Convert.ToInt32(row["IdVariacion"]),
                        Cantidad = Convert.ToInt32(row["Cantidad"]),
                        PrecioVenta = Convert.ToDecimal(row["Precio"]),
                        DescuentoUnitario = Convert.ToDecimal(row["DescuentoUnitario"])
                    });
                }

                var (exito, mensaje) = await objVentasBl.RegistrarVentaAsync(factura, carrito);

                if (exito)
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLimpiar_Click(sender, e);
                    await CargarProductosInventarioAsync();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar la venta: " + mensaje, "Error de Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnProcesarVenta.Enabled = true;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dtCarrito.Rows.Clear();
            if (txtDescuentoGlobal != null) txtDescuentoGlobal.Text = "0.00";
            CalcularTotalesVenta();
        }

        #endregion
    }
}
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;
using EntityLayer;

namespace CandyShopSystem
{
    public partial class FormRegistrarPedido : Form
    {
        private PedidoBl objPedidoBl = new PedidoBl();

        public FormRegistrarPedido()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            CargarComboEstados();
        }

        private void CargarComboEstados()
        {
            DataTable dtEstados = new DataTable();
            dtEstados.Columns.Add("IdEstado", typeof(int));
            dtEstados.Columns.Add("NombreEstado", typeof(string));

            dtEstados.Rows.Add(13, "Pendiente");
            dtEstados.Rows.Add(14, "En ruta");
            dtEstados.Rows.Add(15, "Entregado");

            ComboBox cb = BuscarControlPorNombre(this, "cmbEstado") as ComboBox
                       ?? BuscarControlPorNombre(this, "cboEstado") as ComboBox;

            if (cb != null)
            {
                cb.DataSource = dtEstados;
                cb.DisplayMember = "NombreEstado";
                cb.ValueMember = "IdEstado";
                cb.SelectedValue = 13;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //extrae el numero de factura
            Control txtFacturaCtrl = BuscarControlPorNombre(this, "txtFactura")
                                  ?? BuscarControlPorNombre(this, "txtNFactura")
                                  ?? BuscarControlPorNombre(this, "txtNumFactura")
                                  ?? BuscarControlPorNombre(this, "txtFacturaModal");

            string textoFactura = ExtraerTextoDeControl(txtFacturaCtrl);

            if (string.IsNullOrWhiteSpace(textoFactura))
            {
                foreach (Control c in this.Controls)
                {
                    if (c.Name.ToLower().Contains("factura") || c.Name.ToLower().Contains("nfactura"))
                    {
                        textoFactura = ExtraerTextoDeControl(c);
                        if (!string.IsNullOrWhiteSpace(textoFactura)) break;
                    }
                }
            }

            if (!int.TryParse(textoFactura, out int idFactura) || idFactura <= 0)
            {
                MessageBox.Show($"No se pudo leer el número de factura ingresado ('{textoFactura}'). Por favor ingrese un número entero válido.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //extraer datos de los controles de la ventana
            Control txtClienteCtrl = BuscarControlPorNombre(this, "txtCliente");
            Control txtDireccionCtrl = BuscarControlPorNombre(this, "txtDireccion");
            Control txtFechaCtrl = BuscarControlPorNombre(this, "txtFechaEntrega")
                                ?? BuscarControlPorNombre(this, "dtpFechaEntrega")
                                ?? BuscarControlPorNombre(this, "txtFecha");

            ComboBox cmbEstadoCtrl = BuscarControlPorNombre(this, "cmbEstado") as ComboBox
                                  ?? BuscarControlPorNombre(this, "cboEstado") as ComboBox;

            string clienteText = ExtraerTextoDeControl(txtClienteCtrl);
            string direccionText = ExtraerTextoDeControl(txtDireccionCtrl);
            string direccionCliente = $"{clienteText} - {direccionText}".Trim(' ', '-');

            if (string.IsNullOrWhiteSpace(direccionCliente))
            {
                MessageBox.Show("Por favor ingrese la dirección o el cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //se valida q la fecha ingresada sea válida y se convierte a formato yyyy-MM-dd
            string textoFecha = ExtraerTextoDeControl(txtFechaCtrl);

            if (!DateTime.TryParse(textoFecha, out DateTime fechaConvertida))
            {
                MessageBox.Show($"La fecha ingresada ('{textoFecha}') no es válida. Por favor ingrese una fecha válida (Ej. 2026-09-23).",
                                "Fecha Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fechaEntregaFormateada = fechaConvertida.ToString("yyyy-MM-dd");

            //se crea un objeto EPedido con los datos extraídos y validados
            EPedido nuevoPedido = new EPedido
            {
                IdFactura = idFactura,
                FechaEntrega = fechaEntregaFormateada,
                DireccionAdicional = direccionCliente,
                IdEstado = cmbEstadoCtrl != null && cmbEstadoCtrl.SelectedValue != null ? Convert.ToInt32(cmbEstadoCtrl.SelectedValue) : 13
            };

            //con esto se guardará el pedido en la base de datos y se mostrará un mensaje de éxito o error según corresponda
            string mensaje = string.Empty;
            bool exito = objPedidoBl.RegistrarPedido(nuevoPedido, out mensaje);

            if (exito)
            {
                MessageBox.Show($"¡Pedido #{nuevoPedido.IdPedido} registrado con éxito asociado a la Factura #{idFactura}!",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al guardar pedido en BD: " + mensaje, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //metodos seguros para extraer texto de controles y buscar controles por nombre
        private string ExtraerTextoDeControl(Control ctrl)
        {
            if (ctrl == null) return string.Empty;

            if (ctrl.Controls.Count > 0)
            {
                foreach (Control subCtrl in ctrl.Controls)
                {
                    if (subCtrl is TextBox tbSub) return tbSub.Text.Trim();
                }
            }

            return ctrl.Text.Trim();
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
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

            CargarEstados();
        }

        private void CargarEstados()
        {
            Control cboEstadoCtrl = BuscarControlPorNombre(this, "cboEstado") ?? BuscarControlPorNombre(this, "cmbEstado");
            if (cboEstadoCtrl is ComboBox cmb)
            {
                DataTable dtEstado = new DataTable();
                dtEstado.Columns.Add("id_estado", typeof(int));
                dtEstado.Columns.Add("descripcion", typeof(string));

                dtEstado.Rows.Add(13, "Pendiente");
                dtEstado.Rows.Add(14, "En ruta");

                cmb.DataSource = dtEstado;
                cmb.DisplayMember = "descripcion";
                cmb.ValueMember = "id_estado";
                cmb.SelectedValue = 13;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Control txtFacturaCtrl = BuscarControlPorNombre(this, "txtIdFactura") ?? BuscarControlPorNombre(this, "txtFactura") ?? BuscarControlPorNombre(this, "txtNFactura");
            Control txtFechaCtrl = BuscarControlPorNombre(this, "txtFechaEntrega") ?? BuscarControlPorNombre(this, "txtFecha") ?? BuscarControlPorNombre(this, "dtpFechaEntrega");
            Control txtClienteCtrl = BuscarControlPorNombre(this, "txtCliente") ?? BuscarControlPorNombre(this, "txtNombreCliente");
            Control txtDireccionCtrl = BuscarControlPorNombre(this, "txtDireccionAdicional") ?? BuscarControlPorNombre(this, "txtDireccion") ?? BuscarControlPorNombre(this, "txtDir");
            Control cboEstadoCtrl = BuscarControlPorNombre(this, "cboEstado") ?? BuscarControlPorNombre(this, "cmbEstado");

            string idFacturaTexto = ExtraerTexto(txtFacturaCtrl);
            string fechaTexto = ExtraerTexto(txtFechaCtrl);
            string cliente = ExtraerTexto(txtClienteCtrl);
            string direccionSolo = ExtraerTexto(txtDireccionCtrl);

            int idEstado = 13;
            if (cboEstadoCtrl is ComboBox cmb && cmb.SelectedValue != null)
            {
                idEstado = Convert.ToInt32(cmb.SelectedValue);
            }

            // Se valida el número de factura
            if (!int.TryParse(idFacturaTexto, out int idFactura))
            {
                MessageBox.Show("Ingrese un número de factura válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Se valida la fecha de entrega como DateTime (Soporta DateTimePicker o TextBox)
            DateTime fechaValida = DateTime.Now;
            if (txtFechaCtrl is DateTimePicker dtp)
            {
                fechaValida = dtp.Value;
            }
            else if (!DateTime.TryParse(fechaTexto, out fechaValida))
            {
                MessageBox.Show("Ingrese una fecha válida.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Valida la dirección de entrega y el cliente
            if (string.IsNullOrWhiteSpace(direccionSolo) && string.IsNullOrWhiteSpace(cliente))
            {
                MessageBox.Show("Ingrese el cliente o la dirección de entrega.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Conecta las variables en un solo string para guardar en la base de datos
            string direccionCompleta = string.Empty;
            if (!string.IsNullOrWhiteSpace(cliente) && !string.IsNullOrWhiteSpace(direccionSolo))
            {
                direccionCompleta = $"{cliente} - {direccionSolo}";
            }
            else if (!string.IsNullOrWhiteSpace(cliente))
            {
                direccionCompleta = cliente;
            }
            else
            {
                direccionCompleta = direccionSolo;
            }

            EPedido nuevoPedido = new EPedido
            {
                IdFactura = idFactura,
                FechaEntrega = fechaValida, 
                DireccionAdicional = direccionCompleta,
                IdEstado = idEstado
            };

            int idPedidoGenerado = 0;
            string respuesta = objPedidoBl.RegistrarPedido(nuevoPedido, out idPedidoGenerado);

            if (respuesta == "OK")
            {
                MessageBox.Show($"¡Pedido #{idPedidoGenerado} registrado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al registrar pedido: " + respuesta, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private string ExtraerTexto(Control ctrl)
        {
            if (ctrl == null) return string.Empty;

            if (ctrl is DateTimePicker) return string.Empty;

            var propTexts = ctrl.GetType().GetProperty("Texts");
            if (propTexts != null)
            {
                string val = propTexts.GetValue(ctrl, null) as string;
                if (!string.IsNullOrWhiteSpace(val)) return val.Trim();
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
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BusinessLayer;
using EntityLayer;

namespace CandyShopSystem
{
    public partial class FormRegistrarProveedor : Form
    {
        private ProveedorBl objProveedorBl = new ProveedorBl();

        public FormRegistrarProveedor()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;

            CargarEstados();
            VincularValidacionTelefono();
        }

        private void CargarEstados()
        {
            Control cboEstadoCtrl = BuscarControlPorNombre(this, "cboEstado") ?? BuscarControlPorNombre(this, "cmbEstado");
            if (cboEstadoCtrl is ComboBox cmb)
            {
                DataTable dtEstado = new DataTable();
                dtEstado.Columns.Add("id_estado", typeof(int));
                dtEstado.Columns.Add("descripcion", typeof(string));

                dtEstado.Rows.Add(11, "Activo");
                dtEstado.Rows.Add(12, "Inactivo");

                cmb.DataSource = dtEstado;
                cmb.DisplayMember = "descripcion";
                cmb.ValueMember = "id_estado";
                cmb.SelectedValue = 11;
            }
        }

        private void VincularValidacionTelefono()
        {
            Control txtTelefonoCtrl = BuscarControlPorNombre(this, "txtTelefono");
            if (txtTelefonoCtrl != null)
            {
                TextBox tbInterno = BuscarTextBoxInterno(txtTelefonoCtrl);
                if (tbInterno != null)
                {
                    tbInterno.KeyPress -= txtTelefono_KeyPress;
                    tbInterno.KeyPress += txtTelefono_KeyPress;
                }
                else
                {
                    txtTelefonoCtrl.KeyPress -= txtTelefono_KeyPress;
                    txtTelefonoCtrl.KeyPress += txtTelefono_KeyPress;
                }
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;

            char[] caracteresPermitidos = new char[] { '+', '-', '(', ')', ' ' };

            if (!char.IsDigit(e.KeyChar) && Array.IndexOf(caracteresPermitidos, e.KeyChar) < 0)
            {
                e.Handled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Control txtNombreCtrl = BuscarControlPorNombre(this, "txtNombreProveedor") ?? BuscarControlPorNombre(this, "txtNombre");
            Control txtContactoCtrl = BuscarControlPorNombre(this, "txtContacto");
            Control txtDireccionCtrl = BuscarControlPorNombre(this, "txtDireccion") ?? BuscarControlPorNombre(this, "txtDirección") ?? BuscarControlPorNombre(this, "txtDir");
            Control txtTelefonoCtrl = BuscarControlPorNombre(this, "txtTelefono");
            Control cboEstadoCtrl = BuscarControlPorNombre(this, "cboEstado") ?? BuscarControlPorNombre(this, "cmbEstado");

            string nombre = ExtraerTexto(txtNombreCtrl);
            string contacto = ExtraerTexto(txtContactoCtrl);
            string direccion = ExtraerTexto(txtDireccionCtrl);
            string telefono = ExtraerTexto(txtTelefonoCtrl);

            int idEstado = 11;
            if (cboEstadoCtrl is ComboBox cmb && cmb.SelectedValue != null)
            {
                idEstado = Convert.ToInt32(cmb.SelectedValue);
            }

            // Validaciones
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Ingrese el nombre del proveedor.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(telefono))
            {
                MessageBox.Show("Ingrese el teléfono del proveedor.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Regex.IsMatch(telefono, @"[a-zA-Z]"))
            {
                MessageBox.Show("El teléfono no puede contener letras.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EProveedor nuevoProveedor = new EProveedor
            {
                IdProveedor = 0, // 0 indica registro nuevo
                NombreProveedor = nombre,
                Contacto = contacto,
                Direccion = direccion,
                Telefono = telefono,
                IdEstado = idEstado
            };

            string mensaje = string.Empty;
            bool exito = objProveedorBl.GuardarProveedor(nuevoProveedor, out mensaje);

            if (exito)
            {
                MessageBox.Show("¡Proveedor registrado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al registrar proveedor: " + mensaje, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            var propTexts = ctrl.GetType().GetProperty("Texts");
            if (propTexts != null)
            {
                string val = propTexts.GetValue(ctrl, null) as string;
                if (!string.IsNullOrWhiteSpace(val)) return val.Trim();
            }

            return ctrl.Text.Trim();
        }

        private TextBox BuscarTextBoxInterno(Control contenedor)
        {
            if (contenedor is TextBox tb) return tb;
            foreach (Control hijo in contenedor.Controls)
            {
                if (hijo is TextBox t) return t;
            }
            return null;
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
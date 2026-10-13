using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BusinessLayer;
using EntityLayer;

namespace CandyShopSystem
{
    public partial class FormEditarProveedor : Form
    {
        private ProveedorBl objProveedorBl = new ProveedorBl();
        private EProveedor proveedorEditar;

        public FormEditarProveedor(EProveedor proveedor)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;
            this.proveedorEditar = proveedor;

            CargarEstados();
            CargarDatosProveedor();
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
            }
        }

        private void CargarDatosProveedor()
        {
            if (proveedorEditar == null) return;

            Control txtNombreCtrl = BuscarControlPorNombre(this, "txtNombreProveedor") ?? BuscarControlPorNombre(this, "txtNombre");
            Control txtContactoCtrl = BuscarControlPorNombre(this, "txtContacto");
            Control txtTelefonoCtrl = BuscarControlPorNombre(this, "txtTelefono");
            Control txtDireccionCtrl = BuscarControlPorNombre(this, "txtDireccion") ?? BuscarControlPorNombre(this, "txtDir");
            Control cboEstadoCtrl = BuscarControlPorNombre(this, "cboEstado") ?? BuscarControlPorNombre(this, "cmbEstado");

            EstablecerTexto(txtNombreCtrl, proveedorEditar.NombreProveedor);
            EstablecerTexto(txtContactoCtrl, proveedorEditar.Contacto);
            EstablecerTexto(txtTelefonoCtrl, proveedorEditar.Telefono);
            EstablecerTexto(txtDireccionCtrl, proveedorEditar.Direccion);

            if (cboEstadoCtrl is ComboBox cmb)
            {
                cmb.SelectedValue = proveedorEditar.IdEstado;
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
            Control txtTelefonoCtrl = BuscarControlPorNombre(this, "txtTelefono");
            Control txtDireccionCtrl = BuscarControlPorNombre(this, "txtDireccion") ?? BuscarControlPorNombre(this, "txtDir");
            Control cboEstadoCtrl = BuscarControlPorNombre(this, "cboEstado") ?? BuscarControlPorNombre(this, "cmbEstado");

            string nombre = ExtraerTexto(txtNombreCtrl);
            string contacto = ExtraerTexto(txtContactoCtrl);
            string telefono = ExtraerTexto(txtTelefonoCtrl);
            string direccion = ExtraerTexto(txtDireccionCtrl);

            int idEstado = 11;
            if (cboEstadoCtrl is ComboBox cmb && cmb.SelectedValue != null)
            {
                idEstado = Convert.ToInt32(cmb.SelectedValue);
            }
            //vliadiones
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

            //se actiualizan los datos del proveedor
            proveedorEditar.NombreProveedor = nombre;
            proveedorEditar.Contacto = contacto;
            proveedorEditar.Telefono = telefono;
            proveedorEditar.Direccion = direccion;
            proveedorEditar.IdEstado = idEstado;

            string mensaje = string.Empty;
            bool exito = objProveedorBl.EditarProveedor(proveedorEditar, out mensaje);

            if (exito)
            {
                MessageBox.Show("¡Proveedor actualizado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al actualizar proveedor: " + mensaje, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //metodos para establecer y estraer texto de los txt
        private void EstablecerTexto(Control ctrl, string valor)
        {
            if (ctrl == null) return;

            var propTexts = ctrl.GetType().GetProperty("Texts");
            if (propTexts != null)
            {
                propTexts.SetValue(ctrl, valor, null);
            }
            else
            {
                ctrl.Text = valor;
            }
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

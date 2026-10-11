using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;
using EntityLayer;

namespace CandyShopSystem
{
    public partial class FormClienteModal : Form
    {
        private ClienteBL objClienteBL = new ClienteBL();
        private ECliente clienteEdicion = null;
        private bool esModoSoloLectura = false;

        public FormClienteModal(ECliente cliente = null, bool esSoloLectura = false)
        {
            InitializeComponent();

            this.Size = new Size(580, 520);
            this.MinimumSize = new Size(580, 520);
            this.MaximumSize = new Size(580, 520);

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            clienteEdicion = cliente;
            esModoSoloLectura = esSoloLectura;

            this.Load += FormClienteModal_Load;
        }

        private void FormClienteModal_Load(object sender, EventArgs e)
        {
            VincularValidacionTelefono();

            if (clienteEdicion != null)
            {
                SetTexto(ObtenerCampoTexto("Nombre"), clienteEdicion.NombreCliente);
                SetTexto(ObtenerCampoTexto("Negocio"), clienteEdicion.NombreNegocio);
                SetTexto(ObtenerCampoTexto("Direccion"), clienteEdicion.Direccion);
                SetTexto(ObtenerCampoTexto("Telefono"), clienteEdicion.Contacto);

                Control combo = BuscarControl(this, "cmbTipoCliente") ?? BuscarControl(this, "cboTipoCliente") ?? EscanearComboBox(this);
                if (combo != null && !string.IsNullOrEmpty(clienteEdicion.TipoCliente))
                {
                    SetTexto(combo, clienteEdicion.TipoCliente);
                }
            }

            //si se abre en modo solo lectura, bloquear los campos de texto y el combo box, y cambiar el texto del botón cancelar a "Cerrar"
            if (esModoSoloLectura)
            {
                BloquearModoDetalles();
            }
        }

        private void BloquearModoDetalles()
        {
            Control txtNom = ObtenerCampoTexto("Nombre");
            Control txtNeg = ObtenerCampoTexto("Negocio");
            Control txtDir = ObtenerCampoTexto("Direccion");
            Control txtTel = ObtenerCampoTexto("Telefono");
            Control combo = BuscarControl(this, "cmbTipoCliente") ?? BuscarControl(this, "cboTipoCliente") ?? EscanearComboBox(this);
            Control btnG = BuscarControl(this, "btnGuardar");
            Control btnC = BuscarControl(this, "btnCancelar");

            if (txtNom != null) txtNom.Enabled = false;
            if (txtNeg != null) txtNeg.Enabled = false;
            if (txtDir != null) txtDir.Enabled = false;
            if (txtTel != null) txtTel.Enabled = false;
            if (combo != null) combo.Enabled = false;

            if (btnG != null) btnG.Visible = false;
            if (btnC != null) SetTexto(btnC, "Cerrar");
        }

        private void VincularValidacionTelefono()
        {
            Control txtTel = ObtenerCampoTexto("Telefono");
            if (txtTel != null)
            {
                txtTel.KeyPress -= SoloNumeros_KeyPress;
                txtTel.KeyPress += SoloNumeros_KeyPress;

                foreach (Control c in txtTel.Controls)
                {
                    c.KeyPress -= SoloNumeros_KeyPress;
                    c.KeyPress += SoloNumeros_KeyPress;
                }
            }
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private int ObtenerIdTipoCliente(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion)) return 0;

            string texto = descripcion.Trim().ToLower();

            if (texto.Contains("pulper")) return 1;    
            if (texto.Contains("escuela")) return 2;   
            if (texto.Contains("particular")) return 3;

            return 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreVal = GetTexto(ObtenerCampoTexto("Nombre"));
                string negocioVal = GetTexto(ObtenerCampoTexto("Negocio"));
                string direccionVal = GetTexto(ObtenerCampoTexto("Direccion"));
                string telefonoVal = GetTexto(ObtenerCampoTexto("Telefono"));

                Control combo = BuscarControl(this, "cmbTipoCliente") ?? BuscarControl(this, "cboTipoCliente") ?? EscanearComboBox(this);
                string tipoClienteTexto = GetTexto(combo);

                if (string.IsNullOrWhiteSpace(nombreVal))
                {
                    MessageBox.Show("Por favor, ingrese el Nombre Completo del cliente.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(tipoClienteTexto))
                {
                    MessageBox.Show("Debe seleccionar un Tipo de Cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idTipoCliente = ObtenerIdTipoCliente(tipoClienteTexto);

                ECliente oCliente = new ECliente()
                {
                    IdCliente = clienteEdicion != null ? clienteEdicion.IdCliente : 0,
                    NombreCliente = nombreVal,
                    NombreNegocio = negocioVal,
                    Direccion = direccionVal,
                    Contacto = telefonoVal,
                    TipoCliente = tipoClienteTexto,
                    IdTipoCliente = idTipoCliente
                };

                string mensaje = string.Empty;
                bool resultado = objClienteBL.RegistrarCliente(oCliente, out mensaje);

                if (resultado)
                {
                    MessageBox.Show("¡Cliente registrado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private Control ObtenerCampoTexto(string tipoCampo)
        {
            if (tipoCampo == "Nombre")
            {
                Control c = BuscarControl(this, "txtNombre") ?? BuscarControl(this, "txtNombreCompleto");
                if (c != null) return c;
            }
            else if (tipoCampo == "Negocio")
            {
                Control c = BuscarControl(this, "txtNegocio") ?? BuscarControl(this, "txtNombreNegocio");
                if (c != null) return c;
            }
            else if (tipoCampo == "Direccion")
            {
                Control c = BuscarControl(this, "txtDireccion");
                if (c != null) return c;
            }
            else if (tipoCampo == "Telefono")
            {
                Control c = BuscarControl(this, "txtTelefono") ?? BuscarControl(this, "txtContacto");
                if (c != null) return c;
            }

            List<Control> listaCajas = new List<Control>();
            ObtenerTodasLasCajasTexto(this, listaCajas);

            listaCajas.Sort((a, b) => a.PointToScreen(Point.Empty).Y.CompareTo(b.PointToScreen(Point.Empty).Y));

            int indice = 0;
            if (tipoCampo == "Nombre") indice = 0;
            else if (tipoCampo == "Negocio") indice = 1;
            else if (tipoCampo == "Direccion") indice = 2;
            else if (tipoCampo == "Telefono") indice = 3;

            if (indice < listaCajas.Count)
            {
                return listaCajas[indice];
            }

            return null;
        }

        private void ObtenerTodasLasCajasTexto(Control parent, List<Control> lista)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType().Name.Contains("RJTextBox") || (c is TextBox && !(c.Parent is DateTimePicker)))
                {
                    lista.Add(c);
                }
                else if (c.HasChildren)
                {
                    ObtenerTodasLasCajasTexto(c, lista);
                }
            }
        }

        private Control EscanearComboBox(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType().Name.Contains("ComboBox")) return c;
                Control sub = EscanearComboBox(c);
                if (sub != null) return sub;
            }
            return null;
        }

        private Control BuscarControl(Control contenedor, string nombre)
        {
            if (contenedor == null) return null;
            if (string.Equals(contenedor.Name, nombre, StringComparison.OrdinalIgnoreCase)) return contenedor;

            foreach (Control hijo in contenedor.Controls)
            {
                Control encontrado = BuscarControl(hijo, nombre);
                if (encontrado != null) return encontrado;
            }

            return null;
        }

        private string GetTexto(object control)
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

        private void SetTexto(object control, string valor)
        {
            if (control == null) return;

            var propTexts = control.GetType().GetProperty("Texts");
            if (propTexts != null)
            {
                propTexts.SetValue(control, valor ?? "", null);
                return;
            }

            var propText = control.GetType().GetProperty("Text");
            if (propText != null)
            {
                propText.SetValue(control, valor ?? "", null);
            }
        }

        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void cmbTipoCliente_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}

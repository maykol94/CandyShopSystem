using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BusinessLayer;
using FontAwesome.Sharp;

namespace CandyShopSystem
{
    public partial class FormRegistroUsuario : Form
    {
        private UsuarioBL objUsuarioBL = new UsuarioBL();

        //importante: estas variables controlan la visibilidad de las contraseñas en los campos de texto
        private bool mostrarPassword = false;
        private bool mostrarConfirmarPassword = false;

        //para permitir mover el formulario sin bordes
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

        public FormRegistroUsuario()
        {
            InitializeComponent();
            ConfigurarFormulario();
            VincularEventosOjo();
        }

        private void ConfigurarFormulario()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(900, 497);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(243, 244, 248);

            // Asegurar que ambas cajas de texto inicien ocultando la clave
            if (txtClave != null) txtClave.PasswordChar = true;
            if (txtConfirmarClave != null) txtConfirmarClave.PasswordChar = true;
        }

        private void VincularEventosOjo()
        {
            if (btnVerPassword != null)
            {
                btnVerPassword.Click -= btnVerPassword_Click;
                btnVerPassword.Click += btnVerPassword_Click;
                btnVerPassword.BringToFront();
            }

            if (btnConfirmar != null)
            {
                btnConfirmar.Click -= btnConfirmar_Click;
                btnConfirmar.Click += btnConfirmar_Click;
                btnConfirmar.BringToFront();
            }
        }

        private void FormRegistroUsuario_Load(object sender, EventArgs e)
        {
            if (cmbRol != null)
            {
                cmbRol.Items.Clear();
                cmbRol.Items.Add(new OpcionRol { Texto = "Administrador", Valor = 1 });
                cmbRol.Items.Add(new OpcionRol { Texto = "Ventas / Auxiliar", Valor = 2 });
                cmbRol.Items.Add(new OpcionRol { Texto = "Reparto", Valor = 3 });
                cmbRol.DisplayMember = "Texto";
                cmbRol.ValueMember = "Valor";
                cmbRol.SelectedIndex = 1;
            }
        }

        //el boton para ver la contraseña alterna entre mostrar y ocultar
        private void btnVerPassword_Click(object sender, EventArgs e)
        {
            mostrarPassword = !mostrarPassword;

            if (txtClave != null)
            {
                txtClave.PasswordChar = !mostrarPassword;
            }

            if (sender is IconButton btnIcon)
            {
                btnIcon.IconChar = mostrarPassword ? IconChar.EyeSlash : IconChar.Eye;
                btnIcon.IconColor = mostrarPassword ? Color.FromArgb(190, 46, 95) : Color.FromArgb(160, 160, 170);
            }
        }

        //lo mismo para el boton de confirmar contraseña
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            mostrarConfirmarPassword = !mostrarConfirmarPassword;

            if (txtConfirmarClave != null)
            {
                txtConfirmarClave.PasswordChar = !mostrarConfirmarPassword;
            }

            if (sender is IconButton btnIcon)
            {
                btnIcon.IconChar = mostrarConfirmarPassword ? IconChar.EyeSlash : IconChar.Eye;
                btnIcon.IconColor = mostrarConfirmarPassword ? Color.FromArgb(190, 46, 95) : Color.FromArgb(160, 160, 170);
            }
        }

        // Permitir mover el formulario al hacer clic y arrastrar en el panel superior
        private void panelBrand_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Registrar Usuario
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string userVal = ObtenerTexto(txtUsuario);
            string claveVal = ObtenerTexto(txtClave);
            string confirmClaveVal = ObtenerTexto(txtConfirmarClave);

            if (string.IsNullOrWhiteSpace(userVal))
            {
                MessageBox.Show("Por favor, ingrese un nombre de usuario.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(claveVal))
            {
                MessageBox.Show("Por favor, ingrese una contraseña.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (claveVal != confirmClaveVal)
            {
                MessageBox.Show("Las contraseñas no coinciden. Verifíquelas e intente de nuevo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idRol = 2;
            if (cmbRol != null && cmbRol.SelectedItem is OpcionRol rolSeleccionado)
            {
                idRol = rolSeleccionado.Valor;
            }

            string mensaje = string.Empty;
            bool resultado = objUsuarioBL.RegistrarUsuario(userVal, claveVal, idRol, out mensaje);

            if (resultado)
            {
                MessageBox.Show("¡Usuario creado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(mensaje, "Error al Guardar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string ObtenerTexto(Control ctrl)
        {
            if (ctrl == null) return "";
            var propTexts = ctrl.GetType().GetProperty("Texts");
            if (propTexts != null)
            {
                string val = propTexts.GetValue(ctrl, null) as string;
                if (val != null) return val.Trim();
            }
            return ctrl.Text.Trim();
        }

        private class OpcionRol
        {
            public string Texto { get; set; }
            public int Valor { get; set; }
            public override string ToString() => Texto;
        }
    }
}

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BusinessLayer;
using EntityLayer;
using FontAwesome.Sharp;

namespace CandyShopSystem
{
    public partial class FormLogin : Form
    {
        private UsuarioBL objUsuarioBL = new UsuarioBL();

        //almacena la sesion del usuario q ha iniciado sesion
        public static EUsuario UsuarioSesion { get; private set; }

        private bool mostrarPassword = false;

        //para mover el form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

        public FormLogin()
        {
            {
                InitializeComponent();
                this.AutoScaleMode = AutoScaleMode.None;
                this.FormBorderStyle = FormBorderStyle.None;
                this.Size = new Size(900, 497);
                this.StartPosition = FormStartPosition.CenterScreen;
            }
        }

        private void ConfigurarDiseñoFormulario()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(243, 244, 248);

            if (txtClave != null)
            {
                txtClave.PasswordChar = true;
            }
        }

        //para abrir el form
        private void panelBrand_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //boton de iniciar swsion
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuarioVal = txtUsuario != null ? ObtenerTexto(txtUsuario) : "";
            string claveVal = txtClave != null ? ObtenerTexto(txtClave) : "";

            if (string.IsNullOrWhiteSpace(usuarioVal))
            {
                MessageBox.Show("Por favor, ingrese su nombre de usuario.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(claveVal))
            {
                MessageBox.Show("Por favor, ingrese su contraseña.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mensaje = string.Empty;
            EUsuario usuarioValidado = objUsuarioBL.ValidarUsuario(usuarioVal, claveVal, out mensaje);

            if (usuarioValidado != null)
            {
                //aqui se guarda la sesion del usuario q ha iniciado sesion
                UsuarioSesion = usuarioValidado;

                MessageBox.Show($"¡Bienvenido/a {usuarioValidado.NombreUsuario}!", "Acceso Concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //esto es para q no quede abierot el login de inicio si tocan el link de registrarsr
                this.Hide();
                FormPrincipal formPrincipal = new FormPrincipal();
                formPrincipal.FormClosed += (s, args) => this.Close();
                formPrincipal.Show();
            }
            else
            {
                MessageBox.Show(mensaje, "Error de Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //boton para ver la contrasena
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

        // el enlace para registrarse
        private void lblRegistrarse_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el Login de fondo

            using (FormRegistroUsuario modalRegistro = new FormRegistroUsuario())
            {
                modalRegistro.ShowDialog();
            }

            this.Show(); // Reaparece el Login al cerrar
        }
        
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //para traer el texto de control ya sea de la libreria rj o la normal
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
    }
}

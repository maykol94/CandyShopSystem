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

        private bool mostrarPassword = false;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

        public FormLogin()
        {
            InitializeComponent();
            ConfigurarDiseñoFormulario();
        }

        private void ConfigurarDiseñoFormulario()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(900, 497);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(243, 244, 248);

            if (txtClave != null)
            {
                txtClave.PasswordChar = true;
            }
        }

        private void panelBrand_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuarioVal = ObtenerTexto(txtUsuario);
            string claveVal = ObtenerTexto(txtClave);

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
            //usuario de prueba para ingresar sin base de datos
            if (usuarioVal.Equals("admin", StringComparison.OrdinalIgnoreCase) && claveVal == "123")
            {
                SesionUsuario.IdUsuario = 1;
                SesionUsuario.IdTrabajador = 1;
                SesionUsuario.NombreUsuario = "admin";
                SesionUsuario.NombreCompleto = "Administrador del Sistema";
                SesionUsuario.IdRol = 1;
                SesionUsuario.Rol = "Administrador";

                MessageBox.Show("Bienvenido/a Administrador", "Acceso Concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AbrirFormPrincipal();
                return;
            }

            try
            {
                string mensaje = string.Empty;
                EUsuario usuarioValidado = objUsuarioBL.ValidarUsuario(usuarioVal, claveVal, out mensaje);

                if (usuarioValidado != null)
                {
                    SesionUsuario.IdUsuario = usuarioValidado.IdUsuario;
                    SesionUsuario.IdTrabajador = usuarioValidado.IdTrabajador > 0 ? usuarioValidado.IdTrabajador : usuarioValidado.IdUsuario;
                    SesionUsuario.NombreUsuario = usuarioValidado.NombreUsuario;
                    SesionUsuario.NombreCompleto = usuarioValidado.NombreUsuario;
                    SesionUsuario.IdRol = usuarioValidado.IdRol;

                    MessageBox.Show($"¡Bienvenido/a {usuarioValidado.NombreUsuario}!", "Acceso Concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AbrirFormPrincipal();
                    return;
                }
                else
                {
                    MessageBox.Show(mensaje, "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar a la base de datos:\n" + ex.Message + "\n\nPara ingresar de prueba usa:\nUsuario: admin\nContraseña: 123", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirFormPrincipal()
        {
            this.Hide();
            FormPrincipal mainForm = new FormPrincipal();
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();
        }

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

        private void lblRegistrarse_Click(object sender, EventArgs e)
        {
            this.Hide(); //Oculta el Login de fondo

            using (FormRegistroUsuario modalRegistro = new FormRegistroUsuario())
            {
                modalRegistro.ShowDialog();
            }

            this.Show(); //Reaparece el Login al cerrar el modal
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private string ObtenerTexto(Control ctrl)
        {
            if (ctrl == null) return string.Empty;

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
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
            //obtiene lso textos de las librerias rj y la normal
            string usuarioVal = ObtenerTexto(txtUsuario);
            string claveVal = ObtenerTexto(txtClave);

            //se calidan lso campos q los campos no esten vacios
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

            //sin esta vaina no podes entrar al sistema si no tenes la base de datos conectada, asi q para pruebas se puede usar admin / 123
            if (usuarioVal.Equals("admin", StringComparison.OrdinalIgnoreCase) && claveVal == "123")
            {
                //crea un usuario simulado
                UsuarioSesion = new EUsuario
                {
                    IdUsuario = 1,
                    NombreUsuario = "Administrador",
                    IdRol = 1
                };

                MessageBox.Show("Bienvenido", "Acceso Concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ocultar Login y mostrar el FormPrincipal
                this.Hide();
                FormPrincipal mainForm = new FormPrincipal();
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.Show();
                return;
            }

            //si no es admin / 123, intenta con la base de datos cuando esten los procedimientos
            try
            {
                string mensaje = string.Empty;
                EUsuario usuarioValidado = objUsuarioBL.ValidarUsuario(usuarioVal, claveVal, out mensaje);

                if (usuarioValidado != null)
                {
                    UsuarioSesion = usuarioValidado;
                    MessageBox.Show($"¡Bienvenido/a {usuarioValidado.NombreUsuario}!", "Acceso Concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    FormPrincipal mainForm = new FormPrincipal();
                    mainForm.FormClosed += (s, args) => this.Close();
                    mainForm.Show();
                    return;
                }
            }
            catch
            {
                // Si no hay conexion a la base de datos
            }

  
            MessageBox.Show("Usuario o contrasena incorrectos.\n\nPara ingresar usa lo sig\nUsuario: admin\nContrasena: 123", "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // para q se vea el form principal cuando se loguea
        private void AbrirFormPrincipal()
        {
            this.Hide();
            FormPrincipal formPrincipal = new FormPrincipal();

            formPrincipal.FormClosed += (s, args) => this.Close();

            formPrincipal.Show();
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

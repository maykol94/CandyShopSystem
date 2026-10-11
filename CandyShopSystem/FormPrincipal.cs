using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CandyShopSystem
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();

            // Fuerza a que la ventana inicie maximizada en pantalla grande
            this.WindowState = FormWindowState.Maximized;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            // Forzar el estado Maximized y procesar el layout antes de cargar el control user
            this.WindowState = FormWindowState.Maximized;
            this.PerformLayout();

            EstilarBotonesMenu();

            //cargar el UserControl de Dashboard al iniciar la aplicación
            if (btnDashboard != null)
            {
                ResaltarBotonActivo(btnDashboard);
            }
            AbrirControlEnContenedor(new UC_Dashboard());
        }

        private void AbrirControlEnContenedor(UserControl controlHijo)
        {
            //quita los parpadeos al cargar el UserControl en el panel contenedor
            this.panelContenedor.SuspendLayout();
            this.panelContenedor.Controls.Clear();

            //Anular cualquier restricción de AutoSize que traiga el UserControl
            controlHijo.AutoSize = false;

            //furza ek tamano del usercontrol
            controlHijo.Size = this.panelContenedor.ClientSize;

            //establece el Dock del UserControl para que ocupe todo el espacio del panel contenedor
            controlHijo.Dock = DockStyle.Fill;

            //para que el UserControl se muestre correctamente, se agrega al panel contenedor y se trae al frente
            this.panelContenedor.Controls.Add(controlHijo);
            controlHijo.BringToFront();

            //recalcula el layout del panel contenedor y del UserControl para que se muestren correctamente
            this.panelContenedor.ResumeLayout(true);
            this.panelContenedor.PerformLayout();
            controlHijo.PerformLayout();
        }

        private void ResaltarBotonActivo(Button botonActivo)
        {
            foreach (Control ctrl in panelMenu.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.FromArgb(255, 235, 243);
                    btn.ForeColor = Color.FromArgb(70, 70, 70);
                }
            }

            botonActivo.BackColor = Color.FromArgb(255, 77, 136);
            botonActivo.ForeColor = Color.White;
        }

        private void EstilarBotonesMenu()
        {
            Color colorRosaBase = Color.FromArgb(255, 235, 243);

            foreach (Control ctrl in panelMenu.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.UseVisualStyleBackColor = false;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = colorRosaBase;
                    btn.ForeColor = Color.FromArgb(70, 70, 70);

                    btn.FlatAppearance.CheckedBackColor = colorRosaBase;
                    btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 77, 136);
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 210, 228);

                    btn.TabStop = false;
                }
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ResaltarBotonActivo((Button)sender);
            AbrirControlEnContenedor(new UC_Dashboard());
        }

        private void btnClientes_Click_1(object sender, EventArgs e)
        {
            ResaltarBotonActivo((Button)sender);
            AbrirControlEnContenedor(new UC_Clientes());
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            ResaltarBotonActivo((Button)sender);
            AbrirControlEnContenedor(new uc_Productos());
        }


        // Instancia del UserControl en la parte superior de la clase
        private UC_Proveedor ucProveedor;

        // Método de navegación del botón Proveedores
        private void btnProveedores_Click(object sender, EventArgs e)
        {
            // Crear la instancia de UC_Proveedor si no existe
            if (ucProveedor == null)
            {
                ucProveedor = new UC_Proveedor();
                ucProveedor.Dock = DockStyle.Fill;
            }

            // Buscar automáticamente el panel contenedor central
            Control contenedor = BuscarPanelContenedor(this);

            if (contenedor != null)
            {
                contenedor.Controls.Clear();
                contenedor.Controls.Add(ucProveedor);
                ucProveedor.BringToFront();
            }
            else
            {
                MessageBox.Show("No se encontró el panel contenedor en FormPrincipal.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnInventario_Click(object sender, EventArgs e)
        {
            //limpia el panel contenedor antes de agregar el UserControl de Stock
            panelContenedor.Controls.Clear();

            //estancia del UserControl de Stock
            UC_Stock ucStock = new UC_Stock();

            //para q el usercontrol ocupe todo el espacio del panel contenedor
            ucStock.Dock = DockStyle.Fill;

            //para q no quede atras de otros controles
            panelContenedor.Controls.Add(ucStock);
            ucStock.BringToFront();
        }

        // Método auxiliar para localizar el panel principal
        private Control BuscarPanelContenedor(Control padre)
        {
            string[] nombresPosibles = { "pnlContenedor", "panelContenedor", "pnlDesktop", "pnlContent", "pnlCentral", "panel1" };

            foreach (string nombre in nombresPosibles)
            {
                Control[] encontrados = padre.Controls.Find(nombre, true);
                if (encontrados.Length > 0) return encontrados[0];
            }

            // Si no lo encuentra por nombre
            foreach (Control c in padre.Controls)
            {
                if (c is Panel && c.Dock == DockStyle.Fill) return c;
            }

            return null;
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            //instancia del UserControl de Pedidos
            UC_Pedidos ucPedidos = new UC_Pedidos();
            ucPedidos.Dock = DockStyle.Fill;

            //Limpiar el panel contenedor donde se cargan las pantallas
            panelContenedor.Controls.Clear();

            //Agregar el nuevo UserControl y mostrarlo
            panelContenedor.Controls.Add(ucPedidos);
            ucPedidos.BringToFront();
            ucPedidos.Show();
        }
    }
}
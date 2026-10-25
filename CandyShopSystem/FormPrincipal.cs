using BusinessLayer;
using EntityLayer;
using PresentationLayer;
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

            this.WindowState = FormWindowState.Maximized;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.PerformLayout();

            EstilarBotonesMenu();

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

            controlHijo.AutoSize = false;

            controlHijo.Size = this.panelContenedor.ClientSize;

            controlHijo.Dock = DockStyle.Fill;

            this.panelContenedor.Controls.Add(controlHijo);
            controlHijo.BringToFront();

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
            AbrirControlEnContenedor(new UC_Productos());
        }


        //para el usercontrol de proveedores
        UC_Proveedores ucProveedores = new UC_Proveedores();

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            // Crear la instancia de UC_Proveedores si no existe
            if (ucProveedores == null)
            {
                ucProveedores = new UC_Proveedores();
                ucProveedores.Dock = DockStyle.Fill;
            }

            Control contenedor = BuscarPanelContenedor(this);

            if (contenedor != null)
            {
                contenedor.Controls.Clear();
                contenedor.Controls.Add(ucProveedores);
                ucProveedores.BringToFront();
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

            UC_Inventario ucStock = new UC_Inventario();

            ucStock.Dock = DockStyle.Fill;

            //para q no quede atras de otros controles
            panelContenedor.Controls.Add(ucStock);
            ucStock.BringToFront();
        }

        //para localizar el panel contenedor en FormPrincipal
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
            UC_Pedidos ucPedidos = new UC_Pedidos();
            ucPedidos.Dock = DockStyle.Fill;

            panelContenedor.Controls.Clear();

            panelContenedor.Controls.Add(ucPedidos);
            ucPedidos.BringToFront();
            ucPedidos.Show();
        }
    }
}
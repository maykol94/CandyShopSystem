using System;
using System.Drawing;
using System.Windows.Forms;
using EntityLayer;

namespace CandyShopSystem
{
    public partial class FormAtenderCliente : Form
    {
        private ECliente clienteAtendido;

        public FormAtenderCliente(ECliente cliente, int turnosRestantes)
        {
            InitializeComponent();

            this.AutoScaleMode = AutoScaleMode.None;
            this.StartPosition = FormStartPosition.CenterParent;

            this.clienteAtendido = cliente;
            CargarDatosCliente(turnosRestantes);
        }

        private void CargarDatosCliente(int turnosRestantes)
        {
            if (clienteAtendido != null)
            {
                if (lblNombre != null) lblNombre.Text = clienteAtendido.NombreCliente;
                if (lblNombreNegocio != null) lblNombreNegocio.Text = string.IsNullOrWhiteSpace(clienteAtendido.NombreNegocio) ? "Sin Negocio Asignado" : clienteAtendido.NombreNegocio;
                if (lblContacto != null) lblContacto.Text = string.IsNullOrWhiteSpace(clienteAtendido.Contacto) ? "Sin contacto" : clienteAtendido.Contacto;
                if (lblTipoCliente != null) lblTipoCliente.Text = clienteAtendido.TipoClienteDescripcion;
                if (lblClientesRestantes != null) lblClientesRestantes.Text = $"Quedan {turnosRestantes} cliente(s) pendiente(s) en la cola.";
            }
        }

        private void btnCompletarVenta_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
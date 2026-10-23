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

        }




        private void btnCompletarVenta_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
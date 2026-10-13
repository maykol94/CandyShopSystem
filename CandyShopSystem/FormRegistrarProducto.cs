using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;
using EntityLayer;

namespace PresentationLayer
{
    public partial class FormRegistrarProducto : Form
    {
        private ProductoBl objProductoBl = new ProductoBl();

        public FormRegistrarProducto()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(253, 246, 248);

            this.Load += FormRegistrarProducto_Load;
        }

        private void FormRegistrarProducto_Load(object sender, EventArgs e)
        {
            CargarCombos();
        }

        private void CargarCombos()
        {
            //las categorías
            DataTable dtCat = objProductoBl.ObtenerCategoriasCombo();
            cboCategoria.DataSource = dtCat;
            cboCategoria.DisplayMember = "nombre_categoria";
            cboCategoria.ValueMember = "id_categoria";

            //las marcas
            DataTable dtMar = objProductoBl.ObtenerMarcasCombo();
            cboMarca.DataSource = dtMar;
            cboMarca.DisplayMember = "nombre_marca";
            cboMarca.ValueMember = "id_marca";

            //tipos de producto
            DataTable dtTipo = objProductoBl.ObtenerTiposProductoCombo();
            cboTipoProducto.DataSource = dtTipo;
            cboTipoProducto.DisplayMember = "nombre_tipo";
            cboTipoProducto.ValueMember = "id_tipo_producto";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombreProd = ObtenerTexto(txtNombreProducto);

            if (string.IsNullOrWhiteSpace(nombreProd))
            {
                MessageBox.Show("Ingrese el nombre del producto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreProducto.Focus();
                return;
            }

            EProducto nuevo = new EProducto
            {
                NombreProducto = nombreProd,
                IdCategoria = Convert.ToInt32(cboCategoria.SelectedValue),
                IdMarca = Convert.ToInt32(cboMarca.SelectedValue),
                IdTipoProducto = Convert.ToInt32(cboTipoProducto.SelectedValue)
            };

            string mensaje = string.Empty;
            bool exito = objProductoBl.RegistrarProducto(nuevo, out mensaje);

            if (exito)
            {
                MessageBox.Show("¡Producto registrado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo registrar: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private string ObtenerTexto(object control)
        {
            if (control == null) return "";

            //para los txtbox
            var propTexts = control.GetType().GetProperty("Texts");
            if (propTexts != null)
            {
                string valTexts = propTexts.GetValue(control, null) as string;
                if (!string.IsNullOrWhiteSpace(valTexts)) return valTexts.Trim();
            }

            // Si es un TextBox tradicional de Windows Forms
            var propText = control.GetType().GetProperty("Text");
            if (propText != null)
            {
                string valText = propText.GetValue(control, null) as string;
                if (!string.IsNullOrWhiteSpace(valText)) return valText.Trim();
            }

            return "";
        }

    }
}
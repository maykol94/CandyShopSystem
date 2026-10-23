using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;
using EntityLayer;

namespace PresentationLayer
{
    public partial class FormEditarProducto : Form
    {
        private ProductoBl objProductoBl = new ProductoBl();
        private EProducto _producto;

        public FormEditarProducto(EProducto producto)
        {
            InitializeComponent();
            _producto = producto;

            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.None;;
            this.BackColor = Color.FromArgb(255, 235, 243);

            this.Load += FormEditarProducto_Load;
        }

        private void FormEditarProducto_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarDatosProducto();
        }

        private void CargarCombos()
        {
            cboCategoria.DataSource = objProductoBl.ObtenerCategoriasCombo();
            cboCategoria.DisplayMember = "nombre_categoria";
            cboCategoria.ValueMember = "id_categoria";

            cboMarca.DataSource = objProductoBl.ObtenerMarcasCombo();
            cboMarca.DisplayMember = "nombre_marca";
            cboMarca.ValueMember = "id_marca";

            cboTipoProducto.DataSource = objProductoBl.ObtenerTiposProductoCombo();
            cboTipoProducto.DisplayMember = "nombre_tipo";
            cboTipoProducto.ValueMember = "id_tipo_producto";
        }

        private void CargarDatosProducto()
        {
            if (_producto != null)
            {
                // Asignar texto
                var propTexts = txtNombreProducto.GetType().GetProperty("Texts");
                if (propTexts != null)
                {
                    propTexts.SetValue(txtNombreProducto, _producto.NombreProducto);
                }
                else
                {
                    txtNombreProducto.Text = _producto.NombreProducto;
                }

                cboCategoria.SelectedValue = _producto.IdCategoria;
                cboMarca.SelectedValue = _producto.IdMarca;
                cboTipoProducto.SelectedValue = _producto.IdTipoProducto;
            }
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

            _producto.NombreProducto = nombreProd;
            _producto.IdCategoria = Convert.ToInt32(cboCategoria.SelectedValue);
            _producto.IdMarca = Convert.ToInt32(cboMarca.SelectedValue);
            _producto.IdTipoProducto = Convert.ToInt32(cboTipoProducto.SelectedValue);

            string mensaje = string.Empty;
            bool exito = objProductoBl.EditarProducto(_producto, out mensaje);

            if (exito)
            {
                MessageBox.Show("¡Producto actualizado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo editar: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            //si se usa cualquier otrs libreria
            var propTexts = control.GetType().GetProperty("Texts");
            if (propTexts != null)
            {
                string valTexts = propTexts.GetValue(control, null) as string;
                if (!string.IsNullOrWhiteSpace(valTexts)) return valTexts.Trim();
            }

            //si es un control de windows forms
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

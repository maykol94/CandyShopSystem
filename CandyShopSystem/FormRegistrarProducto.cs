using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
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

        private async void FormRegistrarProducto_Load(object sender, EventArgs e)
        {
            await CargarCombosAsync();
            VincularEventos();
        }

        private void VincularEventos()
        {
            Control btnG = BuscarControlPorNombre(this, "btnGuardar");
            if (btnG != null)
            {
                btnG.Click -= btnGuardar_Click;
                btnG.Click += btnGuardar_Click;
            }

            Control btnC = BuscarControlPorNombre(this, "btnCancelar");
            if (btnC != null)
            {
                btnC.Click -= btnCancelar_Click;
                btnC.Click += btnCancelar_Click;
            }
        }

        private async Task CargarCombosAsync()
        {
            try
            {
                DataSet ds = await objProductoBl.ObtenerCatalogosProductoAsync();

                if (ds != null && ds.Tables.Count >= 3)
                {
                    ComboBox cboCat = ObtenerComboBox("cboCategoria");
                    if (cboCat != null)
                    {
                        cboCat.DisplayMember = "nombre_categoria";
                        cboCat.ValueMember = "id_categoria";
                        cboCat.DataSource = ds.Tables[0];
                    }

                    ComboBox cboMar = ObtenerComboBox("cboMarca");
                    if (cboMar != null)
                    {
                        cboMar.DisplayMember = "nombre_marca";
                        cboMar.ValueMember = "id_marca";
                        cboMar.DataSource = ds.Tables[1];
                    }

                    ComboBox cboTip = ObtenerComboBox("cboTipoProducto");
                    if (cboTip != null)
                    {
                        cboTip.DisplayMember = "nombre_tipo";
                        cboTip.ValueMember = "id_tipo_producto";
                        cboTip.DataSource = ds.Tables[2];
                    }

                    ComboBox cboEst = ObtenerComboBox("cboEstado");
                    if (cboEst != null && ds.Tables.Count >= 4)
                    {
                        cboEst.DisplayMember = "nombre_estado";
                        cboEst.ValueMember = "id_estado";
                        cboEst.DataSource = ds.Tables[3];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar catálogos: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            Control txtNombreCtrl = BuscarControlPorNombre(this, "txtNombreProducto") ?? BuscarControlPorNombre(this, "txtNombre");
            string nombreProd = ObtenerTexto(txtNombreCtrl);

            if (string.IsNullOrWhiteSpace(nombreProd))
            {
                MessageBox.Show("Ingrese el nombre del producto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (txtNombreCtrl != null) txtNombreCtrl.Focus();
                return;
            }

            ComboBox cboCat = ObtenerComboBox("cboCategoria");
            ComboBox cboMar = ObtenerComboBox("cboMarca");
            ComboBox cboTip = ObtenerComboBox("cboTipoProducto");
            ComboBox cboEst = ObtenerComboBox("cboEstado");

            int idCategoria = cboCat?.SelectedValue != null ? Convert.ToInt32(cboCat.SelectedValue) : 0;
            int? idMarca = (cboMar?.SelectedValue != null && Convert.ToInt32(cboMar.SelectedValue) > 0) ? Convert.ToInt32(cboMar.SelectedValue) : (int?)null;
            int idTipoProducto = cboTip?.SelectedValue != null ? Convert.ToInt32(cboTip.SelectedValue) : 0;
            int idEstado = cboEst?.SelectedValue != null ? Convert.ToInt32(cboEst.SelectedValue) : 1;

            EProducto nuevo = new EProducto
            {
                IdProducto = 0,
                NombreProducto = nombreProd,
                IdCategoria = idCategoria,
                IdMarca = idMarca,
                IdTipoProducto = idTipoProducto,
                IdEstado = idEstado
            };

            var (exito, mensaje) = await objProductoBl.GuardarProductoAsync(nuevo);

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

        private ComboBox ObtenerComboBox(string nombre)
        {
            Control ctrl = BuscarControlPorNombre(this, nombre);
            return ctrl as ComboBox;
        }

        private Control BuscarControlPorNombre(Control contenedor, string nombre)
        {
            if (contenedor == null) return null;
            if (string.Equals(contenedor.Name, nombre, StringComparison.OrdinalIgnoreCase)) return contenedor;

            foreach (Control hijo in contenedor.Controls)
            {
                Control encontrado = BuscarControlPorNombre(hijo, nombre);
                if (encontrado != null) return encontrado;
            }

            return null;
        }

        private string ObtenerTexto(object control)
        {
            if (control == null) return "";

            var propTexts = control.GetType().GetProperty("Texts");
            if (propTexts != null)
            {
                string valTexts = propTexts.GetValue(control, null) as string;
                if (!string.IsNullOrWhiteSpace(valTexts)) return valTexts.Trim();
            }

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
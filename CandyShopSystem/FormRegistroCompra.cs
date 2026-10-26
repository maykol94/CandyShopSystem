using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CandyShopSystem
{
    public partial class FormRegistroCompra : Form
    {
        private CompraBl objCompraBl;
        private int idUsuarioSesion = 1;

        public FormRegistroCompra()
        {
            InitializeComponent();
            objCompraBl = new CompraBl();
            idUsuarioSesion = 1; // Temporal, después se toma de la sesión
            CargarProveedores();
            CargarProductos();

            txtCantidad.TextChanged += txtCantidad_TextChanged;
            txtCostoUnitario.TextChanged += txtCostoUnitario_TextChanged;
            txtDscuento.TextChanged += txtDescuento_TextChanged;
        }


        private void CargarProveedores()
        {
            try
            {
                DataTable dt = objCompraBl.ObtenerProveedores();

                if (dt != null && dt.Rows.Count > 0)
                {
                    cmbProveedor.DataSource = dt;
                    cmbProveedor.DisplayMember = "nombre_proveedor";
                    cmbProveedor.ValueMember = "id_proveedor";
                    cmbProveedor.SelectedIndex = -1; // No seleccionar ninguno por defecto
                }
                else
                {
                    MessageBox.Show("No hay proveedores registrados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProductos()
        {
            try
            {
                DataTable dt = objCompraBl.ObtenerVariaciones();

                if (dt != null && dt.Rows.Count > 0)
                {
                    cmbProducto.DataSource = dt;
                    cmbProducto.DisplayMember = "nombre_completo";
                    cmbProducto.ValueMember = "id_variacion";
                    cmbProducto.SelectedIndex = -1; // No seleccionar ninguno por defecto
                }
                else
                {
                    MessageBox.Show("No hay productos registrados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            CalcularSubtotal();
        }

        private void txtCostoUnitario_TextChanged(object sender, EventArgs e)
        {
            CalcularSubtotal();
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            CalcularSubtotal();
        }

        private void CalcularSubtotal()
        {
            int cantidad = 0;
            decimal costo = 0;
            decimal descuento = 0;

            // Forzar cultura invariante (usa punto como decimal)
            CultureInfo cultura = CultureInfo.InvariantCulture;

            // Intentar convertir usando la cultura invariante
            bool cantidadValida = int.TryParse(txtCantidad.Text, out cantidad);
            bool costoValido = decimal.TryParse(txtCostoUnitario.Text, NumberStyles.Any, cultura, out costo);
            bool descuentoValido = decimal.TryParse(txtDscuento.Text, NumberStyles.Any, cultura, out descuento);

            if (cantidadValida && costoValido)
            {
                decimal subtotalBruto = cantidad * costo;

                if (descuentoValido && descuento > 0 && descuento <= 100)
                {
                    decimal montoDescuento = subtotalBruto * (descuento / 100);
                    decimal subtotalNeto = subtotalBruto - montoDescuento;
                    lblSubtotal.Text = $"C$ {subtotalNeto:N2}";
                }
                else
                {
                    lblSubtotal.Text = $"C$ {subtotalBruto:N2}";
                }
            }
            else
            {
                lblSubtotal.Text = "C$ 0.00";
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lblCostoUnitario_Click(object sender, EventArgs e)
        {

        }

        private void FormRegistroCompra_Load(object sender, EventArgs e)
        {

        }

        private void txtCantidad_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void txtCostoUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
            {
                e.Handled = true;
            }
        }

        private void txtDscuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            // 1. Validaciones básicas
            if (cmbProveedor.SelectedValue == null || cmbProducto.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un proveedor y un producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad = 0;
            decimal costo = 0;
            decimal descuento = 0;

            if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtCostoUnitario.Text, out costo) || costo <= 0)
            {
                MessageBox.Show("Ingrese un costo unitario válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal.TryParse(txtDscuento.Text, out descuento);

            // 2. Crear las entidades
            ECompra compra = new ECompra
            {
                IdProveedor = Convert.ToInt32(cmbProveedor.SelectedValue),
                IdUsuario = 1, // ⚠️ IMPORTANTE: Aquí debes poner el ID del usuario logueado. Por ahora pon 1 de prueba.
                DescuentoFactura = descuento,
                TotalMonto = 0, // El procedimiento lo calcula
                EstadoPago = "Pendiente"
            };

            EDetalleCompra detalle = new EDetalleCompra
            {
                IdVariacion = Convert.ToInt32(cmbProducto.SelectedValue),
                CantidadCompra = cantidad,
                CostoUnitario = costo,
                DescuentoUnitario = 0
            };

            // 3. Enviar a la base de datos
            string respuesta = objCompraBl.RegistrarCompra(compra, detalle);

            // 4. Mostrar resultado
            if (respuesta == "OK")
            {
                MessageBox.Show("¡Compra registrada exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Esto avisa al UC_Compras que debe recargarse
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al registrar: " + respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

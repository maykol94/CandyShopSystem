using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;
using EntityLayer;

namespace CandyShopSystem
{
    public partial class FormProductoModal : Form
    {
        private ProductoBL objProductoBL = new ProductoBL();

        public FormProductoModal()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.Load += FormProductoModal_Load;
        }

        private void FormProductoModal_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            VincularBotones();
        }

        private void VincularBotones()
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

        private void CargarCategorias()
        {
            try
            {
                var categorias = new[]
                {
                    new { IdCategoria = 1, Descripcion = "Chicles" },
                    new { IdCategoria = 2, Descripcion = "Chocolates" },
                    new { IdCategoria = 3, Descripcion = "Galletas" },
                    new { IdCategoria = 4, Descripcion = "Caramelos Suaves" },
                    new { IdCategoria = 5, Descripcion = "Caramelos Duros" },
                    new { IdCategoria = 6, Descripcion = "Paletas" },
                    new { IdCategoria = 7, Descripcion = "Gomitas" },
                    new { IdCategoria = 8, Descripcion = "Malvaviscos" },
                    new { IdCategoria = 9, Descripcion = "Jaleas" },
                    new { IdCategoria = 10, Descripcion = "Snacks Salados" },
                    new { IdCategoria = 11, Descripcion = "Combos" }
                };

                Control cmb = ObtenerControlCategoria(this);
                if (cmb != null)
                {
                    if (cmb is ComboBox cb)
                    {
                        cb.DataSource = categorias;
                        cb.DisplayMember = "Descripcion";
                        cb.ValueMember = "IdCategoria";
                        if (cb.Items.Count > 0) cb.SelectedIndex = 0;
                    }
                    else
                    {
                        // Soporte si usas un ComboBox personalizado (ej. RJComboBox)
                        var propDS = cmb.GetType().GetProperty("DataSource");
                        var propDM = cmb.GetType().GetProperty("DisplayMember");
                        var propVM = cmb.GetType().GetProperty("ValueMember");

                        if (propDS != null) propDS.SetValue(cmb, categorias, null);
                        if (propDM != null) propDM.SetValue(cmb, "Descripcion", null);
                        if (propVM != null) propVM.SetValue(cmb, "IdCategoria", null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Control txtNombre = BuscarControlPorNombre(this, "txtNombreProducto") ?? BuscarControlPorNombre(this, "txtNombre");
            string nombre = ObtenerTextoControl(txtNombre);

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Por favor, ingrese el nombre de la golosina o producto.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCategoria = 1;
            Control cmb = ObtenerControlCategoria(this);
            if (cmb != null)
            {
                var propSelectedVal = cmb.GetType().GetProperty("SelectedValue");
                if (propSelectedVal != null)
                {
                    object val = propSelectedVal.GetValue(cmb, null);
                    if (val != null) idCategoria = Convert.ToInt32(val);
                }
            }

            EProducto nuevoProducto = new EProducto
            {
                NombreProducto = nombre,
                IdCategoria = idCategoria
            };

            string mensaje = string.Empty;
            bool resultado = objProductoBL.RegistrarProducto(nuevoProducto, out mensaje);

            if (resultado)
            {
                MessageBox.Show("¡Producto registrado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo guardar el producto: " + mensaje, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // --- MÉTODOS AUXILIARES PARA BÚSQUEDA DINÁMICA DE CONTROLES ---

        private Control ObtenerControlCategoria(Control contenedor)
        {
            // Busca por nombres comunes que le pudiste dar en el diseñador
            string[] nombresPosibles = { "cmbCategoria", "cboCategoria", "cbCategoria", "cmbCat", "cboCat" };
            foreach (string nombre in nombresPosibles)
            {
                Control ctrl = BuscarControlPorNombre(contenedor, nombre);
                if (ctrl != null) return ctrl;
            }

            // Si no encuentra por nombre, busca cualquier ComboBox dentro del formulario
            return BuscarControlPorTipo<ComboBox>(contenedor);
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

        private Control BuscarControlPorTipo<T>(Control contenedor) where T : Control
        {
            if (contenedor == null) return null;
            if (contenedor is T) return contenedor;

            foreach (Control hijo in contenedor.Controls)
            {
                Control encontrado = BuscarControlPorTipo<T>(hijo);
                if (encontrado != null) return encontrado;
            }

            return null;
        }

        private string ObtenerTextoControl(object control)
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
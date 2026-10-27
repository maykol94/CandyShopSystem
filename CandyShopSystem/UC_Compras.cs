using BusinessLayer;
using CandyShopSystem;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class UC_Compras : UserControl
    {
        public UC_Compras()
        {
            InitializeComponent();
        }

        private void UC_Compras_Load(object sender, EventArgs e)
        {
            CargarCompras();
        }

        private void CargarCompras()
        {
            CompraBl negocio = new CompraBl();
            DataTable dt = negocio.ObtenerCompras();

            if (dt != null)
            {
                // Usamos el nombre exacto de tu control: dbvCompras
                dbvCompras.DataSource = dt;

                // Validar que la columna de botón no se duplique si recargas el grid
                if (!dbvCompras.Columns.Contains("BtnCambiarEstado"))
                {
                    DataGridViewButtonColumn btnColumna = new DataGridViewButtonColumn();
                    btnColumna.Name = "BtnCambiarEstado";
                    btnColumna.HeaderText = "Acción";
                    btnColumna.Text = "Cambiar Estado";
                    btnColumna.UseColumnTextForButtonValue = true;
                    dbvCompras.Columns.Add(btnColumna);
                }

                // Aplicar el diseño moderno y limpio
                EstilizarGridModerno();
            }
            else
            {
                MessageBox.Show("No se pudieron cargar los registros de compras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EstilizarGridModerno()
        {
            // Configuración general de aspecto y comportamiento limpio usando dbvCompras
            dbvCompras.BackgroundColor = Color.White;
            dbvCompras.BorderStyle = BorderStyle.None;
            dbvCompras.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dbvCompras.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dbvCompras.RowHeadersVisible = false; // Oculta la barra gris lateral izquierda
            dbvCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dbvCompras.MultiSelect = false;
            dbvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dbvCompras.RowTemplate.Height = 38; // Filas más amplias y estéticas

            // Estilo de la cabecera (Tonos suaves y minimalistas)
            dbvCompras.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 240, 245);
            dbvCompras.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(180, 50, 110); // Tono acorde a tus títulos rosas
            dbvCompras.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dbvCompras.ColumnHeadersHeight = 42;
            dbvCompras.EnableHeadersVisualStyles = false;

            // Estilo de las celdas y filas
            dbvCompras.DefaultCellStyle.BackColor = Color.White;
            dbvCompras.DefaultCellStyle.ForeColor = Color.FromArgb(60, 60, 60);
            dbvCompras.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);

            // Filas alternadas (Efecto cebra muy sutil)
            dbvCompras.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(252, 248, 250);

            // Color cuando seleccionas una fila (Rosa suave elegante)
            dbvCompras.DefaultCellStyle.SelectionBackColor = Color.FromArgb(242, 220, 230);
            dbvCompras.DefaultCellStyle.SelectionForeColor = Color.FromArgb(140, 30, 80);

            // Ajuste visual del botón de acción
            if (dbvCompras.Columns.Contains("BtnCambiarEstado"))
            {
                dbvCompras.Columns["BtnCambiarEstado"].DefaultCellStyle.BackColor = Color.FromArgb(235, 100, 150);
                dbvCompras.Columns["BtnCambiarEstado"].DefaultCellStyle.ForeColor = Color.White;
                dbvCompras.Columns["BtnCambiarEstado"].DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 80, 130);
            }
        }

        private void dbvCompras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validar que se hizo clic en una celda válida y no en la cabecera
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string nombreColumna = dbvCompras.Columns[e.ColumnIndex].Name;

                if (nombreColumna == "BtnCambiarEstado")
                {
                    // Obtener el ID de la compra y el estado actual usando dbvCompras
                    int idCompra = Convert.ToInt32(dbvCompras.Rows[e.RowIndex].Cells["ID Compra"].Value);
                    string estadoActual = dbvCompras.Rows[e.RowIndex].Cells["Estado Pago"].Value.ToString();

                    // Alternar estado de forma inteligente entre pendiente y Pagado al contado
                    string nuevoEstado = (estadoActual.ToLower() == "pendiente") ? "Pagado al contado" : "pendiente";

                    DialogResult resultadoPrompt = MessageBox.Show(
                        $"¿Deseas cambiar el estado de la compra #{idCompra} de '{estadoActual}' a '{nuevoEstado}'?",
                        "Confirmar cambio de estado",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (resultadoPrompt == DialogResult.Yes)
                    {
                        CompraBl negocio = new CompraBl();
                        string resultado = negocio.CambiarEstadoCompra(idCompra, nuevoEstado);

                        if (resultado == "OK")
                        {
                            MessageBox.Show("Estado actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarCompras(); // Refresca y actualiza la tabla automáticamente
                        }
                        else
                        {
                            MessageBox.Show("Error al actualizar: " + resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            // Abre tu formulario de registro de compra existente
            FormRegistroCompra formCompra = new FormRegistroCompra();

            if (formCompra.ShowDialog() == DialogResult.OK)
            {
                CargarCompras(); // Recarga la tabla al registrar una nueva compra exitosamente
            }
        }
    }
}
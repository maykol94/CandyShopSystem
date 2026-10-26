namespace CandyShopSystem
{
    partial class UC_Ventas
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new ReaLTaiizor.Controls.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.panelCliente = new ReaLTaiizor.Controls.Panel();
            this.lblTipoCliente = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelAtendidoPor = new ReaLTaiizor.Controls.Panel();
            this.lblRolTrabajador = new System.Windows.Forms.Label();
            this.lblFechaHora = new System.Windows.Forms.Label();
            this.lblNombreTrabajador = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelFormaPago = new ReaLTaiizor.Controls.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelDescuento = new ReaLTaiizor.Controls.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panelProductos = new ReaLTaiizor.Controls.Panel();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnAnadir = new RJCodeAdvance.RJControls.RJButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDisponibles = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panelTotales = new ReaLTaiizor.Controls.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnLimpiar = new RJCodeAdvance.RJControls.RJButton();
            this.btnProcesarVenta = new RJCodeAdvance.RJControls.RJButton();
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.cboFormaPago = new System.Windows.Forms.ComboBox();
            this.cboProducto = new System.Windows.Forms.ComboBox();
            this.dgvCarrito = new Zuby.ADGV.AdvancedDataGridView();
            this.panelcarrito = new ReaLTaiizor.Controls.Panel();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.txtDescuentoGlobal = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panelCliente.SuspendLayout();
            this.panelAtendidoPor.SuspendLayout();
            this.panelFormaPago.SuspendLayout();
            this.panelDescuento.SuspendLayout();
            this.panelProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.panelTotales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.panelcarrito.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(1280, 79);
            this.panel1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.panel1.TabIndex = 0;
            this.panel1.Text = "panel1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(117)))), ((int)(((byte)(152)))));
            this.label1.Location = new System.Drawing.Point(11, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Registro de factura y ventas  ";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(54)))), ((int)(((byte)(124)))));
            this.label.Location = new System.Drawing.Point(8, 5);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(109, 32);
            this.label.TabIndex = 8;
            this.label.Text = "Ventas";
            // 
            // panelCliente
            // 
            this.panelCliente.BackColor = System.Drawing.Color.White;
            this.panelCliente.Controls.Add(this.cboCliente);
            this.panelCliente.Controls.Add(this.lblTipoCliente);
            this.panelCliente.Controls.Add(this.label2);
            this.panelCliente.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.panelCliente.Location = new System.Drawing.Point(14, 95);
            this.panelCliente.Name = "panelCliente";
            this.panelCliente.Padding = new System.Windows.Forms.Padding(5);
            this.panelCliente.Size = new System.Drawing.Size(576, 101);
            this.panelCliente.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.panelCliente.TabIndex = 2;
            this.panelCliente.Text = "panel3";
            // 
            // lblTipoCliente
            // 
            this.lblTipoCliente.AutoSize = true;
            this.lblTipoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoCliente.Location = new System.Drawing.Point(368, 53);
            this.lblTipoCliente.Name = "lblTipoCliente";
            this.lblTipoCliente.Size = new System.Drawing.Size(0, 20);
            this.lblTipoCliente.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cliente";
            // 
            // panelAtendidoPor
            // 
            this.panelAtendidoPor.BackColor = System.Drawing.Color.White;
            this.panelAtendidoPor.Controls.Add(this.lblRolTrabajador);
            this.panelAtendidoPor.Controls.Add(this.lblFechaHora);
            this.panelAtendidoPor.Controls.Add(this.lblNombreTrabajador);
            this.panelAtendidoPor.Controls.Add(this.label3);
            this.panelAtendidoPor.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.panelAtendidoPor.Location = new System.Drawing.Point(651, 95);
            this.panelAtendidoPor.Name = "panelAtendidoPor";
            this.panelAtendidoPor.Padding = new System.Windows.Forms.Padding(5);
            this.panelAtendidoPor.Size = new System.Drawing.Size(599, 101);
            this.panelAtendidoPor.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.panelAtendidoPor.TabIndex = 3;
            this.panelAtendidoPor.Text = "panel2";
            // 
            // lblRolTrabajador
            // 
            this.lblRolTrabajador.AutoSize = true;
            this.lblRolTrabajador.Location = new System.Drawing.Point(556, 57);
            this.lblRolTrabajador.Name = "lblRolTrabajador";
            this.lblRolTrabajador.Size = new System.Drawing.Size(0, 16);
            this.lblRolTrabajador.TabIndex = 6;
            // 
            // lblFechaHora
            // 
            this.lblFechaHora.AutoSize = true;
            this.lblFechaHora.Location = new System.Drawing.Point(556, 18);
            this.lblFechaHora.Name = "lblFechaHora";
            this.lblFechaHora.Size = new System.Drawing.Size(0, 16);
            this.lblFechaHora.TabIndex = 5;
            // 
            // lblNombreTrabajador
            // 
            this.lblNombreTrabajador.AutoSize = true;
            this.lblNombreTrabajador.Location = new System.Drawing.Point(12, 62);
            this.lblNombreTrabajador.Name = "lblNombreTrabajador";
            this.lblNombreTrabajador.Size = new System.Drawing.Size(0, 16);
            this.lblNombreTrabajador.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Atendido Por:";
            // 
            // panelFormaPago
            // 
            this.panelFormaPago.BackColor = System.Drawing.Color.White;
            this.panelFormaPago.Controls.Add(this.cboFormaPago);
            this.panelFormaPago.Controls.Add(this.label4);
            this.panelFormaPago.Controls.Add(this.label5);
            this.panelFormaPago.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.panelFormaPago.Location = new System.Drawing.Point(14, 232);
            this.panelFormaPago.Name = "panelFormaPago";
            this.panelFormaPago.Padding = new System.Windows.Forms.Padding(5);
            this.panelFormaPago.Size = new System.Drawing.Size(576, 101);
            this.panelFormaPago.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.panelFormaPago.TabIndex = 3;
            this.panelFormaPago.Text = "panel4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(368, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Forma de Pago";
            // 
            // panelDescuento
            // 
            this.panelDescuento.BackColor = System.Drawing.Color.White;
            this.panelDescuento.Controls.Add(this.txtDescuentoGlobal);
            this.panelDescuento.Controls.Add(this.label8);
            this.panelDescuento.Controls.Add(this.label6);
            this.panelDescuento.Controls.Add(this.label7);
            this.panelDescuento.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.panelDescuento.Location = new System.Drawing.Point(651, 232);
            this.panelDescuento.Name = "panelDescuento";
            this.panelDescuento.Padding = new System.Windows.Forms.Padding(5);
            this.panelDescuento.Size = new System.Drawing.Size(348, 101);
            this.panelDescuento.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.panelDescuento.TabIndex = 4;
            this.panelDescuento.Text = "panel5";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(163, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Cordobas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(368, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 20);
            this.label6.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Descuento";
            // 
            // panelProductos
            // 
            this.panelProductos.BackColor = System.Drawing.Color.White;
            this.panelProductos.Controls.Add(this.lblPrecioVenta);
            this.panelProductos.Controls.Add(this.cboProducto);
            this.panelProductos.Controls.Add(this.nudCantidad);
            this.panelProductos.Controls.Add(this.btnAnadir);
            this.panelProductos.Controls.Add(this.label12);
            this.panelProductos.Controls.Add(this.label11);
            this.panelProductos.Controls.Add(this.lblDisponibles);
            this.panelProductos.Controls.Add(this.label9);
            this.panelProductos.Controls.Add(this.label10);
            this.panelProductos.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.panelProductos.Location = new System.Drawing.Point(14, 354);
            this.panelProductos.Name = "panelProductos";
            this.panelProductos.Padding = new System.Windows.Forms.Padding(5);
            this.panelProductos.Size = new System.Drawing.Size(1236, 101);
            this.panelProductos.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.panelProductos.TabIndex = 4;
            this.panelProductos.Text = "panel6";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(624, 54);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(120, 22);
            this.nudCantidad.TabIndex = 8;
            // 
            // btnAnadir
            // 
            this.btnAnadir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(46)))), ((int)(((byte)(120)))));
            this.btnAnadir.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(46)))), ((int)(((byte)(120)))));
            this.btnAnadir.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAnadir.BorderRadius = 15;
            this.btnAnadir.BorderSize = 0;
            this.btnAnadir.FlatAppearance.BorderSize = 0;
            this.btnAnadir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnadir.ForeColor = System.Drawing.Color.White;
            this.btnAnadir.Location = new System.Drawing.Point(1061, 47);
            this.btnAnadir.Name = "btnAnadir";
            this.btnAnadir.Size = new System.Drawing.Size(118, 35);
            this.btnAnadir.TabIndex = 7;
            this.btnAnadir.Text = "Añadir";
            this.btnAnadir.TextColor = System.Drawing.Color.White;
            this.btnAnadir.UseVisualStyleBackColor = false;
            this.btnAnadir.Click += new System.EventHandler(this.btnAnadir_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(845, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 20);
            this.label12.TabIndex = 6;
            this.label12.Text = "Precio Venta";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(621, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 20);
            this.label11.TabIndex = 5;
            this.label11.Text = "Cantidad";
            // 
            // lblDisponibles
            // 
            this.lblDisponibles.AutoSize = true;
            this.lblDisponibles.Location = new System.Drawing.Point(407, 56);
            this.lblDisponibles.Name = "lblDisponibles";
            this.lblDisponibles.Size = new System.Drawing.Size(51, 16);
            this.lblDisponibles.TabIndex = 3;
            this.lblDisponibles.Text = "label11";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(368, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 20);
            this.label9.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "Productos";
            // 
            // panelTotales
            // 
            this.panelTotales.BackColor = System.Drawing.Color.White;
            this.panelTotales.Controls.Add(this.label16);
            this.panelTotales.Controls.Add(this.label15);
            this.panelTotales.Controls.Add(this.label14);
            this.panelTotales.Controls.Add(this.btnLimpiar);
            this.panelTotales.Controls.Add(this.btnProcesarVenta);
            this.panelTotales.Controls.Add(this.lblMontoTotal);
            this.panelTotales.Controls.Add(this.lblDescuento);
            this.panelTotales.Controls.Add(this.lblSubtotal);
            this.panelTotales.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.panelTotales.Location = new System.Drawing.Point(847, 775);
            this.panelTotales.Name = "panelTotales";
            this.panelTotales.Padding = new System.Windows.Forms.Padding(5);
            this.panelTotales.Size = new System.Drawing.Size(398, 252);
            this.panelTotales.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.panelTotales.TabIndex = 5;
            this.panelTotales.Text = "panel8";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(33, 128);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(108, 20);
            this.label16.TabIndex = 11;
            this.label16.Text = "Monto Total";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(33, 58);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 20);
            this.label15.TabIndex = 10;
            this.label15.Text = "Descuento";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(33, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 20);
            this.label14.TabIndex = 8;
            this.label14.Text = "SubTotal";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(225)))), ((int)(((byte)(234)))));
            this.btnLimpiar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(225)))), ((int)(((byte)(234)))));
            this.btnLimpiar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnLimpiar.BorderRadius = 15;
            this.btnLimpiar.BorderSize = 0;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.ForeColor = System.Drawing.Color.Black;
            this.btnLimpiar.Location = new System.Drawing.Point(242, 197);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(118, 35);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextColor = System.Drawing.Color.Black;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnProcesarVenta
            // 
            this.btnProcesarVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(46)))), ((int)(((byte)(120)))));
            this.btnProcesarVenta.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(46)))), ((int)(((byte)(120)))));
            this.btnProcesarVenta.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnProcesarVenta.BorderRadius = 15;
            this.btnProcesarVenta.BorderSize = 0;
            this.btnProcesarVenta.FlatAppearance.BorderSize = 0;
            this.btnProcesarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcesarVenta.ForeColor = System.Drawing.Color.White;
            this.btnProcesarVenta.Location = new System.Drawing.Point(32, 197);
            this.btnProcesarVenta.Name = "btnProcesarVenta";
            this.btnProcesarVenta.Size = new System.Drawing.Size(118, 35);
            this.btnProcesarVenta.TabIndex = 8;
            this.btnProcesarVenta.Text = "Procesar Venta";
            this.btnProcesarVenta.TextColor = System.Drawing.Color.White;
            this.btnProcesarVenta.UseVisualStyleBackColor = false;
            this.btnProcesarVenta.Click += new System.EventHandler(this.btnProcesarVenta_Click);
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(54)))), ((int)(((byte)(124)))));
            this.lblMontoTotal.Location = new System.Drawing.Point(291, 128);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(0, 20);
            this.lblMontoTotal.TabIndex = 8;
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuento.Location = new System.Drawing.Point(291, 58);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(0, 20);
            this.lblDescuento.TabIndex = 7;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(291, 17);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(0, 20);
            this.lblSubtotal.TabIndex = 6;
            // 
            // cboCliente
            // 
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(12, 49);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(356, 24);
            this.cboCliente.TabIndex = 3;
            // 
            // cboFormaPago
            // 
            this.cboFormaPago.FormattingEnabled = true;
            this.cboFormaPago.Location = new System.Drawing.Point(13, 59);
            this.cboFormaPago.Name = "cboFormaPago";
            this.cboFormaPago.Size = new System.Drawing.Size(355, 24);
            this.cboFormaPago.TabIndex = 3;
            // 
            // cboProducto
            // 
            this.cboProducto.FormattingEnabled = true;
            this.cboProducto.Location = new System.Drawing.Point(13, 57);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(355, 24);
            this.cboProducto.TabIndex = 9;
            // 
            // dgvCarrito
            // 
            this.dgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCarrito.FilterAndSortEnabled = true;
            this.dgvCarrito.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvCarrito.Location = new System.Drawing.Point(5, 5);
            this.dgvCarrito.MaxFilterButtonImageHeight = 23;
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvCarrito.RowHeadersWidth = 51;
            this.dgvCarrito.RowTemplate.Height = 24;
            this.dgvCarrito.Size = new System.Drawing.Size(1226, 243);
            this.dgvCarrito.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvCarrito.TabIndex = 0;
            // 
            // panelcarrito
            // 
            this.panelcarrito.BackColor = System.Drawing.Color.White;
            this.panelcarrito.Controls.Add(this.dgvCarrito);
            this.panelcarrito.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.panelcarrito.Location = new System.Drawing.Point(14, 487);
            this.panelcarrito.Name = "panelcarrito";
            this.panelcarrito.Padding = new System.Windows.Forms.Padding(5);
            this.panelcarrito.Size = new System.Drawing.Size(1236, 253);
            this.panelcarrito.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.panelcarrito.TabIndex = 4;
            this.panelcarrito.Text = "panel7";
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Location = new System.Drawing.Point(862, 53);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(50, 16);
            this.lblPrecioVenta.TabIndex = 10;
            this.lblPrecioVenta.Text = "C$ 0.00";
            // 
            // txtDescuentoGlobal
            // 
            this.txtDescuentoGlobal.Location = new System.Drawing.Point(15, 59);
            this.txtDescuentoGlobal.Name = "txtDescuentoGlobal";
            this.txtDescuentoGlobal.Size = new System.Drawing.Size(116, 22);
            this.txtDescuentoGlobal.TabIndex = 5;
            // 
            // UC_Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.Controls.Add(this.panelTotales);
            this.Controls.Add(this.panelcarrito);
            this.Controls.Add(this.panelProductos);
            this.Controls.Add(this.panelDescuento);
            this.Controls.Add(this.panelFormaPago);
            this.Controls.Add(this.panelAtendidoPor);
            this.Controls.Add(this.panelCliente);
            this.Controls.Add(this.panel1);
            this.Name = "UC_Ventas";
            this.Size = new System.Drawing.Size(1280, 1050);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelCliente.ResumeLayout(false);
            this.panelCliente.PerformLayout();
            this.panelAtendidoPor.ResumeLayout(false);
            this.panelAtendidoPor.PerformLayout();
            this.panelFormaPago.ResumeLayout(false);
            this.panelFormaPago.PerformLayout();
            this.panelDescuento.ResumeLayout(false);
            this.panelDescuento.PerformLayout();
            this.panelProductos.ResumeLayout(false);
            this.panelProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.panelTotales.ResumeLayout(false);
            this.panelTotales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.panelcarrito.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label;
        private ReaLTaiizor.Controls.Panel panelCliente;
        private System.Windows.Forms.Label label2;
        private ReaLTaiizor.Controls.Panel panelAtendidoPor;
        private System.Windows.Forms.Label lblTipoCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRolTrabajador;
        private System.Windows.Forms.Label lblFechaHora;
        private System.Windows.Forms.Label lblNombreTrabajador;
        private ReaLTaiizor.Controls.Panel panelFormaPago;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ReaLTaiizor.Controls.Panel panelDescuento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private ReaLTaiizor.Controls.Panel panelProductos;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDisponibles;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private RJCodeAdvance.RJControls.RJButton btnAnadir;
        private ReaLTaiizor.Controls.Panel panelTotales;
        private System.Windows.Forms.Label label14;
        private RJCodeAdvance.RJControls.RJButton btnLimpiar;
        private RJCodeAdvance.RJControls.RJButton btnProcesarVenta;
        private System.Windows.Forms.Label lblMontoTotal;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.ComboBox cboFormaPago;
        private System.Windows.Forms.ComboBox cboProducto;
        private Zuby.ADGV.AdvancedDataGridView dgvCarrito;
        private ReaLTaiizor.Controls.Panel panelcarrito;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.TextBox txtDescuentoGlobal;
    }
}

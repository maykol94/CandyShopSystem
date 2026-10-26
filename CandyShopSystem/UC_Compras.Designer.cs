namespace CandyShopSystem
{
    partial class UC_Compras
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnNuevaCompra = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dbvCompras = new System.Windows.Forms.DataGridView();
            this.colIdCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstadoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCambiarEstado = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbvCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(54)))), ((int)(((byte)(124)))));
            this.lblTitulo.Location = new System.Drawing.Point(15, 19);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(135, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Compras";
            this.lblTitulo.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnNuevaCompra
            // 
            this.btnNuevaCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(77)))), ((int)(((byte)(145)))));
            this.btnNuevaCompra.Location = new System.Drawing.Point(1112, 20);
            this.btnNuevaCompra.Name = "btnNuevaCompra";
            this.btnNuevaCompra.Size = new System.Drawing.Size(150, 40);
            this.btnNuevaCompra.TabIndex = 1;
            this.btnNuevaCompra.Text = "Nueva compra +";
            this.btnNuevaCompra.UseVisualStyleBackColor = false;
            this.btnNuevaCompra.Click += new System.EventHandler(this.btnNuevaCompra_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.btnNuevaCompra);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 100);
            this.panel1.TabIndex = 2;
            // 
            // dbvCompras
            // 
            this.dbvCompras.AllowUserToAddRows = false;
            this.dbvCompras.AllowUserToDeleteRows = false;
            this.dbvCompras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dbvCompras.BackgroundColor = System.Drawing.Color.White;
            this.dbvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbvCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCompra,
            this.colProveedor,
            this.colFecha,
            this.colTotal,
            this.colEstadoPago,
            this.colCambiarEstado});
            this.dbvCompras.Location = new System.Drawing.Point(45, 136);
            this.dbvCompras.MultiSelect = false;
            this.dbvCompras.Name = "dbvCompras";
            this.dbvCompras.ReadOnly = true;
            this.dbvCompras.RowHeadersWidth = 51;
            this.dbvCompras.RowTemplate.Height = 24;
            this.dbvCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbvCompras.Size = new System.Drawing.Size(960, 435);
            this.dbvCompras.TabIndex = 3;
            this.dbvCompras.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbvCompras_CellContentClick);
            // 
            // colIdCompra
            // 
            this.colIdCompra.DataPropertyName = "id_compra";
            this.colIdCompra.HeaderText = "ID Compra";
            this.colIdCompra.MinimumWidth = 6;
            this.colIdCompra.Name = "colIdCompra";
            this.colIdCompra.ReadOnly = true;
            // 
            // colProveedor
            // 
            this.colProveedor.DataPropertyName = "nombre_proveedor";
            this.colProveedor.HeaderText = "Proveedor";
            this.colProveedor.MinimumWidth = 6;
            this.colProveedor.Name = "colProveedor";
            this.colProveedor.ReadOnly = true;
            // 
            // colFecha
            // 
            this.colFecha.DataPropertyName = "fecha_compra";
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.MinimumWidth = 6;
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Width = 74;
            // 
            // colTotal
            // 
            this.colTotal.DataPropertyName = "total_monto";
            this.colTotal.HeaderText = "Total (C$)";
            this.colTotal.MinimumWidth = 6;
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 94;
            // 
            // colEstadoPago
            // 
            this.colEstadoPago.DataPropertyName = "estado_pago";
            this.colEstadoPago.HeaderText = "Estado Pago";
            this.colEstadoPago.MinimumWidth = 6;
            this.colEstadoPago.Name = "colEstadoPago";
            this.colEstadoPago.ReadOnly = true;
            this.colEstadoPago.Width = 115;
            // 
            // colCambiarEstado
            // 
            this.colCambiarEstado.HeaderText = "Cambiar estado a pagado";
            this.colCambiarEstado.MinimumWidth = 6;
            this.colCambiarEstado.Name = "colCambiarEstado";
            this.colCambiarEstado.ReadOnly = true;
            this.colCambiarEstado.Text = "Cambiar Estado";
            this.colCambiarEstado.UseColumnTextForButtonValue = true;
            this.colCambiarEstado.Width = 111;
            // 
            // UC_Compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dbvCompras);
            this.Controls.Add(this.panel1);
            this.Name = "UC_Compras";
            this.Size = new System.Drawing.Size(1280, 720);
            this.Load += new System.EventHandler(this.UC_Compras_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbvCompras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnNuevaCompra;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dbvCompras;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstadoPago;
        private System.Windows.Forms.DataGridViewButtonColumn colCambiarEstado;
    }
}

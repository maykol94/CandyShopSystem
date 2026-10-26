namespace CandyShopSystem
{
    partial class UC_Clientes
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
            this.pnlHeaderClientes = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNuevoCliente = new RJCodeAdvance.RJControls.RJButton();
            this.lblGestiondeclientes = new System.Windows.Forms.Label();
            this.txtBuscar = new RJCodeAdvance.RJControls.RJTextBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnAtenderCliente = new RJCodeAdvance.RJControls.RJButton();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvClientes = new Zuby.ADGV.AdvancedDataGridView();
            this.pnlHeaderClientes.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeaderClientes
            // 
            this.pnlHeaderClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlHeaderClientes.Controls.Add(this.label1);
            this.pnlHeaderClientes.Controls.Add(this.btnNuevoCliente);
            this.pnlHeaderClientes.Controls.Add(this.lblGestiondeclientes);
            this.pnlHeaderClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderClientes.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderClientes.Name = "pnlHeaderClientes";
            this.pnlHeaderClientes.Padding = new System.Windows.Forms.Padding(20, 15, 20, 10);
            this.pnlHeaderClientes.Size = new System.Drawing.Size(1280, 70);
            this.pnlHeaderClientes.TabIndex = 0;
            this.pnlHeaderClientes.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeaderClientes_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(117)))), ((int)(((byte)(152)))));
            this.label1.Location = new System.Drawing.Point(3, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Administra los clientes registrados.";
            // 
            // btnNuevoCliente
            // 
            this.btnNuevoCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(77)))), ((int)(((byte)(145)))));
            this.btnNuevoCliente.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(77)))), ((int)(((byte)(145)))));
            this.btnNuevoCliente.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnNuevoCliente.BorderRadius = 8;
            this.btnNuevoCliente.BorderSize = 0;
            this.btnNuevoCliente.FlatAppearance.BorderSize = 0;
            this.btnNuevoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoCliente.ForeColor = System.Drawing.Color.White;
            this.btnNuevoCliente.Location = new System.Drawing.Point(1120, 18);
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Size = new System.Drawing.Size(150, 40);
            this.btnNuevoCliente.TabIndex = 5;
            this.btnNuevoCliente.Text = "Nuevo cliente+";
            this.btnNuevoCliente.TextColor = System.Drawing.Color.White;
            this.btnNuevoCliente.UseVisualStyleBackColor = false;
            this.btnNuevoCliente.Click += new System.EventHandler(this.btnNuevoCliente_Click);
            // 
            // lblGestiondeclientes
            // 
            this.lblGestiondeclientes.AutoSize = true;
            this.lblGestiondeclientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGestiondeclientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(54)))), ((int)(((byte)(124)))));
            this.lblGestiondeclientes.Location = new System.Drawing.Point(-6, 0);
            this.lblGestiondeclientes.Name = "lblGestiondeclientes";
            this.lblGestiondeclientes.Size = new System.Drawing.Size(126, 32);
            this.lblGestiondeclientes.TabIndex = 0;
            this.lblGestiondeclientes.Text = "Clientes";
            this.lblGestiondeclientes.Click += new System.EventHandler(this.lblGestiondeclientes_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtBuscar.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtBuscar.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(107)))), ((int)(((byte)(148)))));
            this.txtBuscar.BorderRadius = 8;
            this.txtBuscar.BorderSize = 2;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBuscar.Location = new System.Drawing.Point(10, 28);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.txtBuscar.Multiline = false;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtBuscar.PasswordChar = false;
            this.txtBuscar.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtBuscar.PlaceholderText = "Buscar Cliente por nombre, telefono o direccion";
            this.txtBuscar.Size = new System.Drawing.Size(541, 35);
            this.txtBuscar.TabIndex = 6;
            this.txtBuscar.Texts = "";
            this.txtBuscar.UnderlinedStyle = false;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnAtenderCliente);
            this.pnlFooter.Controls.Add(this.txtBuscar);
            this.pnlFooter.Controls.Add(this.btnBuscar);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFooter.Location = new System.Drawing.Point(0, 70);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1280, 70);
            this.pnlFooter.TabIndex = 1;
            this.pnlFooter.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFooter_Paint);
            // 
            // btnAtenderCliente
            // 
            this.btnAtenderCliente.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnAtenderCliente.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnAtenderCliente.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAtenderCliente.BorderRadius = 8;
            this.btnAtenderCliente.BorderSize = 0;
            this.btnAtenderCliente.FlatAppearance.BorderSize = 0;
            this.btnAtenderCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtenderCliente.ForeColor = System.Drawing.Color.White;
            this.btnAtenderCliente.Location = new System.Drawing.Point(1120, 23);
            this.btnAtenderCliente.Name = "btnAtenderCliente";
            this.btnAtenderCliente.Size = new System.Drawing.Size(150, 40);
            this.btnAtenderCliente.TabIndex = 7;
            this.btnAtenderCliente.Text = "AtenderCliente";
            this.btnAtenderCliente.TextColor = System.Drawing.Color.White;
            this.btnAtenderCliente.UseVisualStyleBackColor = false;
            this.btnAtenderCliente.Click += new System.EventHandler(this.btnAtenderCliente_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscar.IconColor = System.Drawing.Color.Black;
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 18;
            this.btnBuscar.Location = new System.Drawing.Point(570, 29);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 35);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvClientes);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 140);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(10);
            this.pnlGrid.Size = new System.Drawing.Size(1280, 580);
            this.pnlGrid.TabIndex = 2;
            // 
            // dgvClientes
            // 
            this.dgvClientes.BackgroundColor = System.Drawing.Color.White;
            this.dgvClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.FilterAndSortEnabled = true;
            this.dgvClientes.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvClientes.Location = new System.Drawing.Point(10, 10);
            this.dgvClientes.MaxFilterButtonImageHeight = 23;
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvClientes.RowHeadersWidth = 51;
            this.dgvClientes.RowTemplate.Height = 24;
            this.dgvClientes.Size = new System.Drawing.Size(1260, 560);
            this.dgvClientes.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvClientes.TabIndex = 0;
            // 
            // UC_Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeaderClientes);
            this.Name = "UC_Clientes";
            this.Size = new System.Drawing.Size(1280, 720);
            this.Load += new System.EventHandler(this.UC_Clientes_Load);
            this.pnlHeaderClientes.ResumeLayout(false);
            this.pnlHeaderClientes.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeaderClientes;
        private System.Windows.Forms.Label lblGestiondeclientes;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlGrid;
        private RJCodeAdvance.RJControls.RJButton btnNuevoCliente;
        private RJCodeAdvance.RJControls.RJTextBox txtBuscar;
        private Zuby.ADGV.AdvancedDataGridView dgvClientes;
        private System.Windows.Forms.Label label1;
        private RJCodeAdvance.RJControls.RJButton btnAtenderCliente;
    }
}

namespace CandyShopSystem
{
    partial class UC_Proveedor
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnNuevoProveedor = new RJCodeAdvance.RJControls.RJButton();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.txtBuscar = new RJCodeAdvance.RJControls.RJTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvProveedores = new Zuby.ADGV.AdvancedDataGridView();
            this.pnlHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnNuevoProveedor);
            this.pnlHeader.Controls.Add(this.btnBuscar);
            this.pnlHeader.Controls.Add(this.txtBuscar);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1280, 70);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnNuevoProveedor
            // 
            this.btnNuevoProveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(200)))), ((int)(((byte)(136)))));
            this.btnNuevoProveedor.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(200)))), ((int)(((byte)(136)))));
            this.btnNuevoProveedor.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnNuevoProveedor.BorderRadius = 12;
            this.btnNuevoProveedor.BorderSize = 0;
            this.btnNuevoProveedor.FlatAppearance.BorderSize = 0;
            this.btnNuevoProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoProveedor.ForeColor = System.Drawing.Color.White;
            this.btnNuevoProveedor.Location = new System.Drawing.Point(830, 10);
            this.btnNuevoProveedor.Name = "btnNuevoProveedor";
            this.btnNuevoProveedor.Size = new System.Drawing.Size(150, 40);
            this.btnNuevoProveedor.TabIndex = 6;
            this.btnNuevoProveedor.Text = "Nuevo Proveedor+";
            this.btnNuevoProveedor.TextColor = System.Drawing.Color.White;
            this.btnNuevoProveedor.UseVisualStyleBackColor = false;
            this.btnNuevoProveedor.Click += new System.EventHandler(this.btnNuevoProveedor_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(235)))));
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscar.IconColor = System.Drawing.Color.Black;
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 17;
            this.btnBuscar.Location = new System.Drawing.Point(507, 10);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 35);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.SystemColors.Window;
            this.txtBuscar.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtBuscar.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtBuscar.BorderRadius = 10;
            this.txtBuscar.BorderSize = 2;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBuscar.Location = new System.Drawing.Point(250, 10);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.txtBuscar.Multiline = false;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtBuscar.PasswordChar = false;
            this.txtBuscar.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtBuscar.PlaceholderText = "Buscar Proveedor";
            this.txtBuscar.Size = new System.Drawing.Size(250, 35);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.Texts = "";
            this.txtBuscar.UnderlinedStyle = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.11F);
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "GESTION DE PROVEEDORES";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvProveedores);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 70);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15, 0, 15, 15);
            this.panel1.Size = new System.Drawing.Size(1280, 650);
            this.panel1.TabIndex = 1;
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProveedores.FilterAndSortEnabled = true;
            this.dgvProveedores.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvProveedores.Location = new System.Drawing.Point(15, 0);
            this.dgvProveedores.MaxFilterButtonImageHeight = 23;
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvProveedores.RowHeadersWidth = 51;
            this.dgvProveedores.RowTemplate.Height = 24;
            this.dgvProveedores.Size = new System.Drawing.Size(1250, 635);
            this.dgvProveedores.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvProveedores.TabIndex = 0;
            // 
            // UC_Proveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(235)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UC_Proveedor";
            this.Size = new System.Drawing.Size(1280, 720);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label label1;
        private RJCodeAdvance.RJControls.RJTextBox txtBuscar;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private RJCodeAdvance.RJControls.RJButton btnNuevoProveedor;
        private System.Windows.Forms.Panel panel1;
        private Zuby.ADGV.AdvancedDataGridView dgvProveedores;
    }
}

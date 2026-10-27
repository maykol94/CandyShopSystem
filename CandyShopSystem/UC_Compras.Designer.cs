namespace PresentationLayer
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNuevaCompra = new RJCodeAdvance.RJControls.RJButton();
            this.dbvCompras = new Zuby.ADGV.AdvancedDataGridView();
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
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnNuevaCompra);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 100);
            this.panel1.TabIndex = 2;
            // 
            // btnNuevaCompra
            // 
            this.btnNuevaCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(77)))), ((int)(((byte)(145)))));
            this.btnNuevaCompra.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(77)))), ((int)(((byte)(145)))));
            this.btnNuevaCompra.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnNuevaCompra.BorderRadius = 15;
            this.btnNuevaCompra.BorderSize = 0;
            this.btnNuevaCompra.FlatAppearance.BorderSize = 0;
            this.btnNuevaCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaCompra.ForeColor = System.Drawing.Color.White;
            this.btnNuevaCompra.Location = new System.Drawing.Point(1014, 20);
            this.btnNuevaCompra.Name = "btnNuevaCompra";
            this.btnNuevaCompra.Size = new System.Drawing.Size(253, 40);
            this.btnNuevaCompra.TabIndex = 2;
            this.btnNuevaCompra.Text = "Nueva Compra+";
            this.btnNuevaCompra.TextColor = System.Drawing.Color.White;
            this.btnNuevaCompra.UseVisualStyleBackColor = false;
            this.btnNuevaCompra.Click += new System.EventHandler(this.btnNueva_Click);
            // 
            // dbvCompras
            // 
            this.dbvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbvCompras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbvCompras.FilterAndSortEnabled = true;
            this.dbvCompras.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dbvCompras.Location = new System.Drawing.Point(0, 100);
            this.dbvCompras.MaxFilterButtonImageHeight = 23;
            this.dbvCompras.Name = "dbvCompras";
            this.dbvCompras.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dbvCompras.RowHeadersWidth = 51;
            this.dbvCompras.RowTemplate.Height = 24;
            this.dbvCompras.Size = new System.Drawing.Size(1280, 620);
            this.dbvCompras.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dbvCompras.TabIndex = 3;
            this.dbvCompras.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbvCompras_CellClick);
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
        private System.Windows.Forms.Panel panel1;
        private RJCodeAdvance.RJControls.RJButton btnNuevaCompra;
        private Zuby.ADGV.AdvancedDataGridView dbvCompras;
    }
}

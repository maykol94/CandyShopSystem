namespace CandyShopSystem
{
    partial class UC_Stock
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
            this.label1 = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlHeader2 = new System.Windows.Forms.Panel();
            this.txtBuscarInventario = new RJCodeAdvance.RJControls.RJTextBox();
            this.pnlAlerta = new System.Windows.Forms.Panel();
            this.dgvInventario = new Zuby.ADGV.AdvancedDataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlHeader2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(54)))), ((int)(((byte)(124)))));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inventario";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlHeader.Controls.Add(this.label2);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1280, 79);
            this.pnlHeader.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(282, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Control de existencias y minimos establecidos";
            // 
            // pnlHeader2
            // 
            this.pnlHeader2.BackColor = System.Drawing.Color.White;
            this.pnlHeader2.Controls.Add(this.txtBuscarInventario);
            this.pnlHeader2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader2.Location = new System.Drawing.Point(0, 79);
            this.pnlHeader2.Name = "pnlHeader2";
            this.pnlHeader2.Size = new System.Drawing.Size(1280, 52);
            this.pnlHeader2.TabIndex = 2;
            // 
            // txtBuscarInventario
            // 
            this.txtBuscarInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtBuscarInventario.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtBuscarInventario.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtBuscarInventario.BorderRadius = 15;
            this.txtBuscarInventario.BorderSize = 2;
            this.txtBuscarInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarInventario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBuscarInventario.Location = new System.Drawing.Point(9, 7);
            this.txtBuscarInventario.Margin = new System.Windows.Forms.Padding(4);
            this.txtBuscarInventario.Multiline = false;
            this.txtBuscarInventario.Name = "txtBuscarInventario";
            this.txtBuscarInventario.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtBuscarInventario.PasswordChar = false;
            this.txtBuscarInventario.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtBuscarInventario.PlaceholderText = "Buscar en inventario";
            this.txtBuscarInventario.Size = new System.Drawing.Size(473, 35);
            this.txtBuscarInventario.TabIndex = 0;
            this.txtBuscarInventario.Texts = "";
            this.txtBuscarInventario.UnderlinedStyle = false;
            // 
            // pnlAlerta
            // 
            this.pnlAlerta.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAlerta.Location = new System.Drawing.Point(0, 131);
            this.pnlAlerta.Name = "pnlAlerta";
            this.pnlAlerta.Size = new System.Drawing.Size(1280, 50);
            this.pnlAlerta.TabIndex = 3;
            // 
            // dgvInventario
            // 
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventario.FilterAndSortEnabled = true;
            this.dgvInventario.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvInventario.Location = new System.Drawing.Point(0, 181);
            this.dgvInventario.MaxFilterButtonImageHeight = 23;
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvInventario.RowHeadersWidth = 51;
            this.dgvInventario.RowTemplate.Height = 24;
            this.dgvInventario.Size = new System.Drawing.Size(1280, 539);
            this.dgvInventario.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvInventario.TabIndex = 4;
            // 
            // UC_Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.dgvInventario);
            this.Controls.Add(this.pnlAlerta);
            this.Controls.Add(this.pnlHeader2);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UC_Stock";
            this.Size = new System.Drawing.Size(1280, 720);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlHeader2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlHeader2;
        private RJCodeAdvance.RJControls.RJTextBox txtBuscarInventario;
        private System.Windows.Forms.Panel pnlAlerta;
        private Zuby.ADGV.AdvancedDataGridView dgvInventario;
    }
}

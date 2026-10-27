namespace CandyShopSystem
{
    partial class UC_Reportes
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlVentasDia = new System.Windows.Forms.Panel();
            this.dgvVentasDia = new Zuby.ADGV.AdvancedDataGridView();
            this.pnlVentasRecientes = new System.Windows.Forms.Panel();
            this.dgvFacturas = new Zuby.ADGV.AdvancedDataGridView();
            this.panel1.SuspendLayout();
            this.pnlVentasDia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentasDia)).BeginInit();
            this.pnlVentasRecientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 91);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(117)))), ((int)(((byte)(152)))));
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Resumen operativo de la dulcería.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(54)))), ((int)(((byte)(124)))));
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reportes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(54)))), ((int)(((byte)(124)))));
            this.label3.Location = new System.Drawing.Point(3, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 32);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ventas del dia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(54)))), ((int)(((byte)(124)))));
            this.label4.Location = new System.Drawing.Point(3, 446);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(253, 32);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ventas Recientes";
            // 
            // pnlVentasDia
            // 
            this.pnlVentasDia.Controls.Add(this.dgvVentasDia);
            this.pnlVentasDia.Location = new System.Drawing.Point(12, 170);
            this.pnlVentasDia.Name = "pnlVentasDia";
            this.pnlVentasDia.Size = new System.Drawing.Size(1248, 273);
            this.pnlVentasDia.TabIndex = 13;
            // 
            // dgvVentasDia
            // 
            this.dgvVentasDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentasDia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVentasDia.FilterAndSortEnabled = true;
            this.dgvVentasDia.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvVentasDia.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvVentasDia.Location = new System.Drawing.Point(0, 0);
            this.dgvVentasDia.MaxFilterButtonImageHeight = 23;
            this.dgvVentasDia.MultiSelect = false;
            this.dgvVentasDia.Name = "dgvVentasDia";
            this.dgvVentasDia.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvVentasDia.RowHeadersWidth = 51;
            this.dgvVentasDia.RowTemplate.Height = 24;
            this.dgvVentasDia.Size = new System.Drawing.Size(1248, 273);
            this.dgvVentasDia.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvVentasDia.TabIndex = 13;
            // 
            // pnlVentasRecientes
            // 
            this.pnlVentasRecientes.Controls.Add(this.dgvFacturas);
            this.pnlVentasRecientes.Location = new System.Drawing.Point(9, 495);
            this.pnlVentasRecientes.Name = "pnlVentasRecientes";
            this.pnlVentasRecientes.Size = new System.Drawing.Size(1251, 222);
            this.pnlVentasRecientes.TabIndex = 14;
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFacturas.FilterAndSortEnabled = true;
            this.dgvFacturas.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvFacturas.Location = new System.Drawing.Point(0, 0);
            this.dgvFacturas.MaxFilterButtonImageHeight = 23;
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvFacturas.RowHeadersWidth = 51;
            this.dgvFacturas.RowTemplate.Height = 24;
            this.dgvFacturas.Size = new System.Drawing.Size(1251, 222);
            this.dgvFacturas.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvFacturas.TabIndex = 14;
            // 
            // UC_Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.Controls.Add(this.pnlVentasRecientes);
            this.Controls.Add(this.pnlVentasDia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Name = "UC_Reportes";
            this.Size = new System.Drawing.Size(1280, 720);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlVentasDia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentasDia)).EndInit();
            this.pnlVentasRecientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlVentasDia;
        private System.Windows.Forms.Panel pnlVentasRecientes;
        private Zuby.ADGV.AdvancedDataGridView dgvVentasDia;
        private Zuby.ADGV.AdvancedDataGridView dgvFacturas;
    }
}

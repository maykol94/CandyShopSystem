namespace CandyShopSystem
{
    partial class UC_Pedidos
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblGestiondeclientes = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblContadorCola = new System.Windows.Forms.Label();
            this.btnDespacharPedido = new RJCodeAdvance.RJControls.RJButton();
            this.btnNuevosPedidos = new RJCodeAdvance.RJControls.RJButton();
            this.dgvPedidos = new Zuby.ADGV.AdvancedDataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblGestiondeclientes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 74);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(117)))), ((int)(((byte)(152)))));
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Administra los clientes registrados.";
            // 
            // lblGestiondeclientes
            // 
            this.lblGestiondeclientes.AutoSize = true;
            this.lblGestiondeclientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGestiondeclientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(54)))), ((int)(((byte)(124)))));
            this.lblGestiondeclientes.Location = new System.Drawing.Point(3, 0);
            this.lblGestiondeclientes.Name = "lblGestiondeclientes";
            this.lblGestiondeclientes.Size = new System.Drawing.Size(125, 32);
            this.lblGestiondeclientes.TabIndex = 1;
            this.lblGestiondeclientes.Text = "Pedidos";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblContadorCola);
            this.panel2.Controls.Add(this.btnDespacharPedido);
            this.panel2.Controls.Add(this.btnNuevosPedidos);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1280, 77);
            this.panel2.TabIndex = 1;
            // 
            // lblContadorCola
            // 
            this.lblContadorCola.AutoSize = true;
            this.lblContadorCola.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContadorCola.Location = new System.Drawing.Point(436, 30);
            this.lblContadorCola.Name = "lblContadorCola";
            this.lblContadorCola.Size = new System.Drawing.Size(250, 23);
            this.lblContadorCola.TabIndex = 2;
            this.lblContadorCola.Text = "\"Pedidos pendientes en cola: 0\"";
            // 
            // btnDespacharPedido
            // 
            this.btnDespacharPedido.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnDespacharPedido.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnDespacharPedido.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnDespacharPedido.BorderRadius = 10;
            this.btnDespacharPedido.BorderSize = 0;
            this.btnDespacharPedido.FlatAppearance.BorderSize = 0;
            this.btnDespacharPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDespacharPedido.ForeColor = System.Drawing.Color.White;
            this.btnDespacharPedido.Location = new System.Drawing.Point(223, 23);
            this.btnDespacharPedido.Name = "btnDespacharPedido";
            this.btnDespacharPedido.Size = new System.Drawing.Size(150, 40);
            this.btnDespacharPedido.TabIndex = 1;
            this.btnDespacharPedido.Text = "Despachar Pedido";
            this.btnDespacharPedido.TextColor = System.Drawing.Color.White;
            this.btnDespacharPedido.UseVisualStyleBackColor = false;
            // 
            // btnNuevosPedidos
            // 
            this.btnNuevosPedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(77)))), ((int)(((byte)(145)))));
            this.btnNuevosPedidos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(77)))), ((int)(((byte)(145)))));
            this.btnNuevosPedidos.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnNuevosPedidos.BorderRadius = 10;
            this.btnNuevosPedidos.BorderSize = 0;
            this.btnNuevosPedidos.FlatAppearance.BorderSize = 0;
            this.btnNuevosPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevosPedidos.ForeColor = System.Drawing.Color.White;
            this.btnNuevosPedidos.Location = new System.Drawing.Point(37, 23);
            this.btnNuevosPedidos.Name = "btnNuevosPedidos";
            this.btnNuevosPedidos.Size = new System.Drawing.Size(150, 40);
            this.btnNuevosPedidos.TabIndex = 0;
            this.btnNuevosPedidos.Text = "+Nuevos Pedidos";
            this.btnNuevosPedidos.TextColor = System.Drawing.Color.White;
            this.btnNuevosPedidos.UseVisualStyleBackColor = false;
            this.btnNuevosPedidos.Click += new System.EventHandler(this.btnNuevoPedido_Click);
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPedidos.FilterAndSortEnabled = true;
            this.dgvPedidos.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvPedidos.Location = new System.Drawing.Point(0, 151);
            this.dgvPedidos.MaxFilterButtonImageHeight = 23;
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.ReadOnly = true;
            this.dgvPedidos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvPedidos.RowHeadersWidth = 51;
            this.dgvPedidos.RowTemplate.Height = 24;
            this.dgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidos.Size = new System.Drawing.Size(1280, 569);
            this.dgvPedidos.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvPedidos.TabIndex = 2;
            // 
            // UC_Pedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvPedidos);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UC_Pedidos";
            this.Size = new System.Drawing.Size(1280, 720);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblGestiondeclientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private RJCodeAdvance.RJControls.RJButton btnNuevosPedidos;
        private System.Windows.Forms.Label lblContadorCola;
        private RJCodeAdvance.RJControls.RJButton btnDespacharPedido;
        private Zuby.ADGV.AdvancedDataGridView dgvPedidos;
    }
}

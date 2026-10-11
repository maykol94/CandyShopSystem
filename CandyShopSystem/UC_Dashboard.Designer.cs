namespace CandyShopSystem
{
    partial class UC_Dashboard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flowTarjetas = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCardClientes = new System.Windows.Forms.Panel();
            this.pnlCardProductos = new System.Windows.Forms.Panel();
            this.pnlCardVentas = new System.Windows.Forms.Panel();
            this.pnlCardPedidos = new System.Windows.Forms.Panel();
            this.lblClientesRegistrados = new System.Windows.Forms.Label();
            this.lblValorClientes = new System.Windows.Forms.Label();
            this.lblProductos = new System.Windows.Forms.Label();
            this.lblValorProductos = new System.Windows.Forms.Label();
            this.lblVentasDelDia = new System.Windows.Forms.Label();
            this.lblValorVentas = new System.Windows.Forms.Label();
            this.lblPedidosPendientes = new System.Windows.Forms.Label();
            this.lblValorPedidos = new System.Windows.Forms.Label();
            this.pnlContenidoInferior = new System.Windows.Forms.Panel();
            this.dgvUltimasVentas = new System.Windows.Forms.DataGridView();
            this.flowTarjetas.SuspendLayout();
            this.pnlCardClientes.SuspendLayout();
            this.pnlCardProductos.SuspendLayout();
            this.pnlCardVentas.SuspendLayout();
            this.pnlCardPedidos.SuspendLayout();
            this.pnlContenidoInferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUltimasVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // flowTarjetas
            // 
            this.flowTarjetas.BackColor = System.Drawing.Color.Transparent;
            this.flowTarjetas.Controls.Add(this.pnlCardClientes);
            this.flowTarjetas.Controls.Add(this.pnlCardProductos);
            this.flowTarjetas.Controls.Add(this.pnlCardVentas);
            this.flowTarjetas.Controls.Add(this.pnlCardPedidos);
            this.flowTarjetas.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowTarjetas.Location = new System.Drawing.Point(0, 0);
            this.flowTarjetas.Name = "flowTarjetas";
            this.flowTarjetas.Padding = new System.Windows.Forms.Padding(15, 15, 15, 10);
            this.flowTarjetas.Size = new System.Drawing.Size(1000, 140);
            this.flowTarjetas.TabIndex = 0;
            // 
            // pnlCardClientes
            // 
            this.pnlCardClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.pnlCardClientes.Controls.Add(this.lblValorClientes);
            this.pnlCardClientes.Controls.Add(this.lblClientesRegistrados);
            this.pnlCardClientes.Location = new System.Drawing.Point(18, 18);
            this.pnlCardClientes.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.pnlCardClientes.Name = "pnlCardClientes";
            this.pnlCardClientes.Size = new System.Drawing.Size(200, 100);
            this.pnlCardClientes.TabIndex = 0;
            // 
            // pnlCardProductos
            // 
            this.pnlCardProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.pnlCardProductos.Controls.Add(this.lblValorProductos);
            this.pnlCardProductos.Controls.Add(this.lblProductos);
            this.pnlCardProductos.Location = new System.Drawing.Point(236, 18);
            this.pnlCardProductos.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.pnlCardProductos.Name = "pnlCardProductos";
            this.pnlCardProductos.Size = new System.Drawing.Size(200, 100);
            this.pnlCardProductos.TabIndex = 1;
            // 
            // pnlCardVentas
            // 
            this.pnlCardVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.pnlCardVentas.Controls.Add(this.lblValorVentas);
            this.pnlCardVentas.Controls.Add(this.lblVentasDelDia);
            this.pnlCardVentas.Location = new System.Drawing.Point(454, 18);
            this.pnlCardVentas.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.pnlCardVentas.Name = "pnlCardVentas";
            this.pnlCardVentas.Size = new System.Drawing.Size(200, 100);
            this.pnlCardVentas.TabIndex = 2;
            // 
            // pnlCardPedidos
            // 
            this.pnlCardPedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(224)))));
            this.pnlCardPedidos.Controls.Add(this.lblValorPedidos);
            this.pnlCardPedidos.Controls.Add(this.lblPedidosPendientes);
            this.pnlCardPedidos.Location = new System.Drawing.Point(672, 18);
            this.pnlCardPedidos.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.pnlCardPedidos.Name = "pnlCardPedidos";
            this.pnlCardPedidos.Size = new System.Drawing.Size(200, 100);
            this.pnlCardPedidos.TabIndex = 3;
            // 
            // lblClientesRegistrados
            // 
            this.lblClientesRegistrados.AutoSize = true;
            this.lblClientesRegistrados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(27)))), ((int)(((byte)(96)))));
            this.lblClientesRegistrados.Location = new System.Drawing.Point(15, 15);
            this.lblClientesRegistrados.Name = "lblClientesRegistrados";
            this.lblClientesRegistrados.Size = new System.Drawing.Size(173, 16);
            this.lblClientesRegistrados.TabIndex = 0;
            this.lblClientesRegistrados.Text = "CLIENTES REGISTRADOS";
            // 
            // lblValorClientes
            // 
            this.lblValorClientes.AutoSize = true;
            this.lblValorClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(27)))), ((int)(((byte)(96)))));
            this.lblValorClientes.Location = new System.Drawing.Point(15, 40);
            this.lblValorClientes.Name = "lblValorClientes";
            this.lblValorClientes.Size = new System.Drawing.Size(28, 16);
            this.lblValorClientes.TabIndex = 1;
            this.lblValorClientes.Text = "128";
            // 
            // lblProductos
            // 
            this.lblProductos.AutoSize = true;
            this.lblProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblProductos.Location = new System.Drawing.Point(15, 15);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(93, 16);
            this.lblProductos.TabIndex = 0;
            this.lblProductos.Text = "PRODUCTOS";
            // 
            // lblValorProductos
            // 
            this.lblValorProductos.AutoSize = true;
            this.lblValorProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblValorProductos.Location = new System.Drawing.Point(15, 40);
            this.lblValorProductos.Name = "lblValorProductos";
            this.lblValorProductos.Size = new System.Drawing.Size(21, 16);
            this.lblValorProductos.TabIndex = 1;
            this.lblValorProductos.Text = "45";
            // 
            // lblVentasDelDia
            // 
            this.lblVentasDelDia.AutoSize = true;
            this.lblVentasDelDia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.lblVentasDelDia.Location = new System.Drawing.Point(15, 15);
            this.lblVentasDelDia.Name = "lblVentasDelDia";
            this.lblVentasDelDia.Size = new System.Drawing.Size(116, 16);
            this.lblVentasDelDia.TabIndex = 0;
            this.lblVentasDelDia.Text = "VENTAS DEL DIA";
            // 
            // lblValorVentas
            // 
            this.lblValorVentas.AutoSize = true;
            this.lblValorVentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.lblValorVentas.Location = new System.Drawing.Point(15, 40);
            this.lblValorVentas.Name = "lblValorVentas";
            this.lblValorVentas.Size = new System.Drawing.Size(71, 16);
            this.lblValorVentas.TabIndex = 1;
            this.lblValorVentas.Text = "C$1,450,00";
            // 
            // lblPedidosPendientes
            // 
            this.lblPedidosPendientes.AutoSize = true;
            this.lblPedidosPendientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(87)))), ((int)(((byte)(0)))));
            this.lblPedidosPendientes.Location = new System.Drawing.Point(15, 15);
            this.lblPedidosPendientes.Name = "lblPedidosPendientes";
            this.lblPedidosPendientes.Size = new System.Drawing.Size(157, 16);
            this.lblPedidosPendientes.TabIndex = 0;
            this.lblPedidosPendientes.Text = "PEDIDOS PENDIENTES";
            // 
            // lblValorPedidos
            // 
            this.lblValorPedidos.AutoSize = true;
            this.lblValorPedidos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(87)))), ((int)(((byte)(0)))));
            this.lblValorPedidos.Location = new System.Drawing.Point(15, 40);
            this.lblValorPedidos.Name = "lblValorPedidos";
            this.lblValorPedidos.Size = new System.Drawing.Size(14, 16);
            this.lblValorPedidos.TabIndex = 1;
            this.lblValorPedidos.Text = "8";
            // 
            // pnlContenidoInferior
            // 
            this.pnlContenidoInferior.BackColor = System.Drawing.Color.Transparent;
            this.pnlContenidoInferior.Controls.Add(this.dgvUltimasVentas);
            this.pnlContenidoInferior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenidoInferior.Location = new System.Drawing.Point(0, 140);
            this.pnlContenidoInferior.Name = "pnlContenidoInferior";
            this.pnlContenidoInferior.Padding = new System.Windows.Forms.Padding(15, 10, 15, 15);
            this.pnlContenidoInferior.Size = new System.Drawing.Size(1000, 460);
            this.pnlContenidoInferior.TabIndex = 1;
            // 
            // dgvUltimasVentas
            // 
            this.dgvUltimasVentas.AllowUserToAddRows = false;
            this.dgvUltimasVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUltimasVentas.BackgroundColor = System.Drawing.Color.White;
            this.dgvUltimasVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUltimasVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUltimasVentas.ColumnHeadersHeight = 35;
            this.dgvUltimasVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUltimasVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUltimasVentas.EnableHeadersVisualStyles = false;
            this.dgvUltimasVentas.Location = new System.Drawing.Point(15, 10);
            this.dgvUltimasVentas.Name = "dgvUltimasVentas";
            this.dgvUltimasVentas.ReadOnly = true;
            this.dgvUltimasVentas.RowHeadersVisible = false;
            this.dgvUltimasVentas.RowHeadersWidth = 51;
            this.dgvUltimasVentas.RowTemplate.Height = 24;
            this.dgvUltimasVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUltimasVentas.Size = new System.Drawing.Size(970, 435);
            this.dgvUltimasVentas.TabIndex = 0;
            // 
            // UC_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.pnlContenidoInferior);
            this.Controls.Add(this.flowTarjetas);
            this.Name = "UC_Dashboard";
            this.Size = new System.Drawing.Size(1000, 600);
            this.flowTarjetas.ResumeLayout(false);
            this.pnlCardClientes.ResumeLayout(false);
            this.pnlCardClientes.PerformLayout();
            this.pnlCardProductos.ResumeLayout(false);
            this.pnlCardProductos.PerformLayout();
            this.pnlCardVentas.ResumeLayout(false);
            this.pnlCardVentas.PerformLayout();
            this.pnlCardPedidos.ResumeLayout(false);
            this.pnlCardPedidos.PerformLayout();
            this.pnlContenidoInferior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUltimasVentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowTarjetas;
        private System.Windows.Forms.Panel pnlCardClientes;
        private System.Windows.Forms.Panel pnlCardProductos;
        private System.Windows.Forms.Panel pnlCardVentas;
        private System.Windows.Forms.Panel pnlCardPedidos;
        private System.Windows.Forms.Label lblValorClientes;
        private System.Windows.Forms.Label lblClientesRegistrados;
        private System.Windows.Forms.Label lblValorProductos;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.Label lblValorVentas;
        private System.Windows.Forms.Label lblVentasDelDia;
        private System.Windows.Forms.Label lblValorPedidos;
        private System.Windows.Forms.Label lblPedidosPendientes;
        private System.Windows.Forms.Panel pnlContenidoInferior;
        private System.Windows.Forms.DataGridView dgvUltimasVentas;
    }
}

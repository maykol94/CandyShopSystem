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
            this.flowTarjetas = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCardClientes = new System.Windows.Forms.Panel();
            this.lblTotalClientes = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.pnlCardProductos = new System.Windows.Forms.Panel();
            this.lblTotalProductos = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.pnlCardVentas = new System.Windows.Forms.Panel();
            this.lblVentasHoy = new System.Windows.Forms.Label();
            this.lblVentasDelDia = new System.Windows.Forms.Label();
            this.pnlCardPedidos = new System.Windows.Forms.Panel();
            this.lblPedidosPendientesCard = new System.Windows.Forms.Label();
            this.lblPedidosPendientes = new System.Windows.Forms.Label();
            this.pnlVentasRecientes = new System.Windows.Forms.Panel();
            this.dgvVentasRecientes = new Zuby.ADGV.AdvancedDataGridView();
            this.pnlProductosMasVendidos = new System.Windows.Forms.Panel();
            this.dgvProductosMasVendidos = new Zuby.ADGV.AdvancedDataGridView();
            this.pnlResumenInventario = new System.Windows.Forms.Panel();
            this.pnlCardPedidosResumen = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPedidosPendientesResumen = new System.Windows.Forms.Label();
            this.pnlCardPorReponer = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPorReponer = new System.Windows.Forms.Label();
            this.pnlCardStockDisponible = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStockDisponible = new System.Windows.Forms.Label();
            this.lblVentas = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowTarjetas.SuspendLayout();
            this.pnlCardClientes.SuspendLayout();
            this.pnlCardProductos.SuspendLayout();
            this.pnlCardVentas.SuspendLayout();
            this.pnlCardPedidos.SuspendLayout();
            this.pnlVentasRecientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentasRecientes)).BeginInit();
            this.pnlProductosMasVendidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosMasVendidos)).BeginInit();
            this.pnlResumenInventario.SuspendLayout();
            this.pnlCardPedidosResumen.SuspendLayout();
            this.pnlCardPorReponer.SuspendLayout();
            this.pnlCardStockDisponible.SuspendLayout();
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
            this.flowTarjetas.Size = new System.Drawing.Size(1122, 140);
            this.flowTarjetas.TabIndex = 0;
            // 
            // pnlCardClientes
            // 
            this.pnlCardClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.pnlCardClientes.Controls.Add(this.lblTotalClientes);
            this.pnlCardClientes.Controls.Add(this.lbl2);
            this.pnlCardClientes.Location = new System.Drawing.Point(18, 18);
            this.pnlCardClientes.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.pnlCardClientes.Name = "pnlCardClientes";
            this.pnlCardClientes.Size = new System.Drawing.Size(200, 100);
            this.pnlCardClientes.TabIndex = 0;
            // 
            // lblTotalClientes
            // 
            this.lblTotalClientes.AutoSize = true;
            this.lblTotalClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(27)))), ((int)(((byte)(96)))));
            this.lblTotalClientes.Location = new System.Drawing.Point(15, 40);
            this.lblTotalClientes.Name = "lblTotalClientes";
            this.lblTotalClientes.Size = new System.Drawing.Size(28, 16);
            this.lblTotalClientes.TabIndex = 1;
            this.lblTotalClientes.Text = "128";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(27)))), ((int)(((byte)(96)))));
            this.lbl2.Location = new System.Drawing.Point(15, 15);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(173, 16);
            this.lbl2.TabIndex = 0;
            this.lbl2.Text = "CLIENTES REGISTRADOS";
            // 
            // pnlCardProductos
            // 
            this.pnlCardProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.pnlCardProductos.Controls.Add(this.lblTotalProductos);
            this.pnlCardProductos.Controls.Add(this.label);
            this.pnlCardProductos.Location = new System.Drawing.Point(236, 18);
            this.pnlCardProductos.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.pnlCardProductos.Name = "pnlCardProductos";
            this.pnlCardProductos.Size = new System.Drawing.Size(200, 100);
            this.pnlCardProductos.TabIndex = 1;
            // 
            // lblTotalProductos
            // 
            this.lblTotalProductos.AutoSize = true;
            this.lblTotalProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblTotalProductos.Location = new System.Drawing.Point(15, 40);
            this.lblTotalProductos.Name = "lblTotalProductos";
            this.lblTotalProductos.Size = new System.Drawing.Size(21, 16);
            this.lblTotalProductos.TabIndex = 1;
            this.lblTotalProductos.Text = "45";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.label.Location = new System.Drawing.Point(15, 15);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(93, 16);
            this.label.TabIndex = 0;
            this.label.Text = "PRODUCTOS";
            // 
            // pnlCardVentas
            // 
            this.pnlCardVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.pnlCardVentas.Controls.Add(this.lblVentasHoy);
            this.pnlCardVentas.Controls.Add(this.lblVentasDelDia);
            this.pnlCardVentas.Location = new System.Drawing.Point(454, 18);
            this.pnlCardVentas.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.pnlCardVentas.Name = "pnlCardVentas";
            this.pnlCardVentas.Size = new System.Drawing.Size(200, 100);
            this.pnlCardVentas.TabIndex = 2;
            // 
            // lblVentasHoy
            // 
            this.lblVentasHoy.AutoSize = true;
            this.lblVentasHoy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.lblVentasHoy.Location = new System.Drawing.Point(15, 40);
            this.lblVentasHoy.Name = "lblVentasHoy";
            this.lblVentasHoy.Size = new System.Drawing.Size(71, 16);
            this.lblVentasHoy.TabIndex = 1;
            this.lblVentasHoy.Text = "C$1,450,00";
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
            // pnlCardPedidos
            // 
            this.pnlCardPedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(224)))));
            this.pnlCardPedidos.Controls.Add(this.lblPedidosPendientesCard);
            this.pnlCardPedidos.Controls.Add(this.lblPedidosPendientes);
            this.pnlCardPedidos.Location = new System.Drawing.Point(669, 15);
            this.pnlCardPedidos.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCardPedidos.Name = "pnlCardPedidos";
            this.pnlCardPedidos.Size = new System.Drawing.Size(200, 100);
            this.pnlCardPedidos.TabIndex = 3;
            // 
            // lblPedidosPendientesCard
            // 
            this.lblPedidosPendientesCard.AutoSize = true;
            this.lblPedidosPendientesCard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(87)))), ((int)(((byte)(0)))));
            this.lblPedidosPendientesCard.Location = new System.Drawing.Point(15, 40);
            this.lblPedidosPendientesCard.Name = "lblPedidosPendientesCard";
            this.lblPedidosPendientesCard.Size = new System.Drawing.Size(14, 16);
            this.lblPedidosPendientesCard.TabIndex = 1;
            this.lblPedidosPendientesCard.Text = "8";
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
            // pnlVentasRecientes
            // 
            this.pnlVentasRecientes.Controls.Add(this.dgvVentasRecientes);
            this.pnlVentasRecientes.Location = new System.Drawing.Point(3, 186);
            this.pnlVentasRecientes.Name = "pnlVentasRecientes";
            this.pnlVentasRecientes.Size = new System.Drawing.Size(1116, 311);
            this.pnlVentasRecientes.TabIndex = 1;
            // 
            // dgvVentasRecientes
            // 
            this.dgvVentasRecientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentasRecientes.FilterAndSortEnabled = true;
            this.dgvVentasRecientes.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvVentasRecientes.Location = new System.Drawing.Point(3, 22);
            this.dgvVentasRecientes.MaxFilterButtonImageHeight = 23;
            this.dgvVentasRecientes.Name = "dgvVentasRecientes";
            this.dgvVentasRecientes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvVentasRecientes.RowHeadersWidth = 51;
            this.dgvVentasRecientes.RowTemplate.Height = 24;
            this.dgvVentasRecientes.Size = new System.Drawing.Size(1110, 277);
            this.dgvVentasRecientes.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvVentasRecientes.TabIndex = 0;
            // 
            // pnlProductosMasVendidos
            // 
            this.pnlProductosMasVendidos.Controls.Add(this.dgvProductosMasVendidos);
            this.pnlProductosMasVendidos.Location = new System.Drawing.Point(18, 694);
            this.pnlProductosMasVendidos.Name = "pnlProductosMasVendidos";
            this.pnlProductosMasVendidos.Size = new System.Drawing.Size(633, 270);
            this.pnlProductosMasVendidos.TabIndex = 2;
            // 
            // dgvProductosMasVendidos
            // 
            this.dgvProductosMasVendidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductosMasVendidos.FilterAndSortEnabled = true;
            this.dgvProductosMasVendidos.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvProductosMasVendidos.Location = new System.Drawing.Point(3, 10);
            this.dgvProductosMasVendidos.MaxFilterButtonImageHeight = 23;
            this.dgvProductosMasVendidos.Name = "dgvProductosMasVendidos";
            this.dgvProductosMasVendidos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvProductosMasVendidos.RowHeadersWidth = 51;
            this.dgvProductosMasVendidos.RowTemplate.Height = 24;
            this.dgvProductosMasVendidos.Size = new System.Drawing.Size(627, 257);
            this.dgvProductosMasVendidos.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvProductosMasVendidos.TabIndex = 0;
            // 
            // pnlResumenInventario
            // 
            this.pnlResumenInventario.Controls.Add(this.pnlCardPedidosResumen);
            this.pnlResumenInventario.Controls.Add(this.pnlCardPorReponer);
            this.pnlResumenInventario.Controls.Add(this.pnlCardStockDisponible);
            this.pnlResumenInventario.Location = new System.Drawing.Point(9, 503);
            this.pnlResumenInventario.Name = "pnlResumenInventario";
            this.pnlResumenInventario.Size = new System.Drawing.Size(1113, 139);
            this.pnlResumenInventario.TabIndex = 3;
            // 
            // pnlCardPedidosResumen
            // 
            this.pnlCardPedidosResumen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.pnlCardPedidosResumen.Controls.Add(this.label6);
            this.pnlCardPedidosResumen.Controls.Add(this.lblPedidosPendientesResumen);
            this.pnlCardPedidosResumen.Location = new System.Drawing.Point(808, 21);
            this.pnlCardPedidosResumen.Name = "pnlCardPedidosResumen";
            this.pnlCardPedidosResumen.Size = new System.Drawing.Size(200, 100);
            this.pnlCardPedidosResumen.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Pedidos Pendietes";
            // 
            // lblPedidosPendientesResumen
            // 
            this.lblPedidosPendientesResumen.AutoSize = true;
            this.lblPedidosPendientesResumen.Location = new System.Drawing.Point(14, 54);
            this.lblPedidosPendientesResumen.Name = "lblPedidosPendientesResumen";
            this.lblPedidosPendientesResumen.Size = new System.Drawing.Size(13, 16);
            this.lblPedidosPendientesResumen.TabIndex = 0;
            this.lblPedidosPendientesResumen.Text = "ll";
            // 
            // pnlCardPorReponer
            // 
            this.pnlCardPorReponer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(224)))));
            this.pnlCardPorReponer.Controls.Add(this.label5);
            this.pnlCardPorReponer.Controls.Add(this.lblPorReponer);
            this.pnlCardPorReponer.Location = new System.Drawing.Point(445, 21);
            this.pnlCardPorReponer.Name = "pnlCardPorReponer";
            this.pnlCardPorReponer.Size = new System.Drawing.Size(200, 100);
            this.pnlCardPorReponer.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Por Reponer";
            // 
            // lblPorReponer
            // 
            this.lblPorReponer.AutoSize = true;
            this.lblPorReponer.Location = new System.Drawing.Point(18, 45);
            this.lblPorReponer.Name = "lblPorReponer";
            this.lblPorReponer.Size = new System.Drawing.Size(44, 16);
            this.lblPorReponer.TabIndex = 0;
            this.lblPorReponer.Text = "label2";
            // 
            // pnlCardStockDisponible
            // 
            this.pnlCardStockDisponible.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.pnlCardStockDisponible.Controls.Add(this.label4);
            this.pnlCardStockDisponible.Controls.Add(this.lblStockDisponible);
            this.pnlCardStockDisponible.Location = new System.Drawing.Point(79, 21);
            this.pnlCardStockDisponible.Name = "pnlCardStockDisponible";
            this.pnlCardStockDisponible.Size = new System.Drawing.Size(200, 100);
            this.pnlCardStockDisponible.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Stock Disponible";
            // 
            // lblStockDisponible
            // 
            this.lblStockDisponible.AutoSize = true;
            this.lblStockDisponible.Location = new System.Drawing.Point(38, 45);
            this.lblStockDisponible.Name = "lblStockDisponible";
            this.lblStockDisponible.Size = new System.Drawing.Size(44, 16);
            this.lblStockDisponible.TabIndex = 0;
            this.lblStockDisponible.Text = "label1";
            // 
            // lblVentas
            // 
            this.lblVentas.AutoSize = true;
            this.lblVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(54)))), ((int)(((byte)(124)))));
            this.lblVentas.Location = new System.Drawing.Point(3, 163);
            this.lblVentas.Name = "lblVentas";
            this.lblVentas.Size = new System.Drawing.Size(151, 20);
            this.lblVentas.TabIndex = 1;
            this.lblVentas.Text = "Ventas recientes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(54)))), ((int)(((byte)(124)))));
            this.label1.Location = new System.Drawing.Point(17, 659);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Productos mas vendidos";
            // 
            // UC_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblVentas);
            this.Controls.Add(this.pnlResumenInventario);
            this.Controls.Add(this.pnlProductosMasVendidos);
            this.Controls.Add(this.pnlVentasRecientes);
            this.Controls.Add(this.flowTarjetas);
            this.Name = "UC_Dashboard";
            this.Size = new System.Drawing.Size(1122, 967);
            this.flowTarjetas.ResumeLayout(false);
            this.pnlCardClientes.ResumeLayout(false);
            this.pnlCardClientes.PerformLayout();
            this.pnlCardProductos.ResumeLayout(false);
            this.pnlCardProductos.PerformLayout();
            this.pnlCardVentas.ResumeLayout(false);
            this.pnlCardVentas.PerformLayout();
            this.pnlCardPedidos.ResumeLayout(false);
            this.pnlCardPedidos.PerformLayout();
            this.pnlVentasRecientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentasRecientes)).EndInit();
            this.pnlProductosMasVendidos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosMasVendidos)).EndInit();
            this.pnlResumenInventario.ResumeLayout(false);
            this.pnlCardPedidosResumen.ResumeLayout(false);
            this.pnlCardPedidosResumen.PerformLayout();
            this.pnlCardPorReponer.ResumeLayout(false);
            this.pnlCardPorReponer.PerformLayout();
            this.pnlCardStockDisponible.ResumeLayout(false);
            this.pnlCardStockDisponible.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowTarjetas;
        private System.Windows.Forms.Panel pnlCardClientes;
        private System.Windows.Forms.Panel pnlCardProductos;
        private System.Windows.Forms.Panel pnlCardVentas;
        private System.Windows.Forms.Panel pnlCardPedidos;
        private System.Windows.Forms.Label lblTotalClientes;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lblTotalProductos;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label lblVentasHoy;
        private System.Windows.Forms.Label lblVentasDelDia;
        private System.Windows.Forms.Label lblPedidosPendientesCard;
        private System.Windows.Forms.Label lblPedidosPendientes;
        private System.Windows.Forms.Panel pnlVentasRecientes;
        private Zuby.ADGV.AdvancedDataGridView dgvVentasRecientes;
        private System.Windows.Forms.Panel pnlProductosMasVendidos;
        private Zuby.ADGV.AdvancedDataGridView dgvProductosMasVendidos;
        private System.Windows.Forms.Panel pnlResumenInventario;
        private System.Windows.Forms.Panel pnlCardPedidosResumen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPedidosPendientesResumen;
        private System.Windows.Forms.Panel pnlCardPorReponer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPorReponer;
        private System.Windows.Forms.Panel pnlCardStockDisponible;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStockDisponible;
        private System.Windows.Forms.Label lblVentas;
        private System.Windows.Forms.Label label1;
    }
}

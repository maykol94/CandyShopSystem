namespace CandyShopSystem
{
    partial class FormRegistroCompra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblCostoUnitario = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtCostoUnitario = new System.Windows.Forms.TextBox();
            this.txtDscuento = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agregar compra";
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Location = new System.Drawing.Point(12, 72);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(74, 16);
            this.lblProveedor.TabIndex = 1;
            this.lblProveedor.Text = "Proveedor:";
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(180, 64);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(255, 24);
            this.cmbProveedor.TabIndex = 2;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(12, 114);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(123, 16);
            this.lblProducto.TabIndex = 3;
            this.lblProducto.Text = "Producto/variacion:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(12, 154);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(64, 16);
            this.lblCantidad.TabIndex = 4;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Location = new System.Drawing.Point(177, 285);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(23, 16);
            this.lblSubtotal.TabIndex = 5;
            this.lblSubtotal.Text = "C$";
            // 
            // lblCostoUnitario
            // 
            this.lblCostoUnitario.AutoSize = true;
            this.lblCostoUnitario.Location = new System.Drawing.Point(12, 192);
            this.lblCostoUnitario.Name = "lblCostoUnitario";
            this.lblCostoUnitario.Size = new System.Drawing.Size(94, 16);
            this.lblCostoUnitario.TabIndex = 6;
            this.lblCostoUnitario.Text = "Costo Unitario:";
            this.lblCostoUnitario.Click += new System.EventHandler(this.lblCostoUnitario_Click);
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Location = new System.Drawing.Point(12, 233);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(75, 16);
            this.lblDescuento.TabIndex = 7;
            this.lblDescuento.Text = "Descuento:";
            // 
            // cmbProducto
            // 
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(180, 106);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(255, 24);
            this.cmbProducto.TabIndex = 8;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(180, 148);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 22);
            this.txtCantidad.TabIndex = 12;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged_1);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // txtCostoUnitario
            // 
            this.txtCostoUnitario.Location = new System.Drawing.Point(180, 189);
            this.txtCostoUnitario.Name = "txtCostoUnitario";
            this.txtCostoUnitario.Size = new System.Drawing.Size(100, 22);
            this.txtCostoUnitario.TabIndex = 13;
            this.txtCostoUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCostoUnitario_KeyPress);
            // 
            // txtDscuento
            // 
            this.txtDscuento.Location = new System.Drawing.Point(180, 230);
            this.txtDscuento.Name = "txtDscuento";
            this.txtDscuento.Size = new System.Drawing.Size(100, 22);
            this.txtDscuento.TabIndex = 14;
            this.txtDscuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDscuento_KeyPress);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(77)))), ((int)(((byte)(145)))));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(309, 430);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(126, 35);
            this.btnAgregar.TabIndex = 15;
            this.btnAgregar.Text = "Agregar +";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(470, 430);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 35);
            this.button1.TabIndex = 16;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Subtotal:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 342);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Precio Venta";
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Location = new System.Drawing.Point(180, 336);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(100, 22);
            this.txtPrecioVenta.TabIndex = 19;
            // 
            // FormRegistroCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(645, 477);
            this.Controls.Add(this.txtPrecioVenta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtDscuento);
            this.Controls.Add(this.txtCostoUnitario);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.cmbProducto);
            this.Controls.Add(this.lblDescuento);
            this.Controls.Add(this.lblCostoUnitario);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.cmbProveedor);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRegistroCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormRegistroCompra";
            this.Load += new System.EventHandler(this.FormRegistroCompra_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblCostoUnitario;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtCostoUnitario;
        private System.Windows.Forms.TextBox txtDscuento;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrecioVenta;
    }
}
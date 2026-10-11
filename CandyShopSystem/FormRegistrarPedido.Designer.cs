namespace CandyShopSystem
{
    partial class FormRegistrarPedido
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNfactura = new RJCodeAdvance.RJControls.RJTextBox();
            this.txtFechaEntrega = new RJCodeAdvance.RJControls.RJTextBox();
            this.txtCliente = new RJCodeAdvance.RJControls.RJTextBox();
            this.txtDireccion = new RJCodeAdvance.RJControls.RJTextBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new RJCodeAdvance.RJControls.RJButton();
            this.btnGuardar = new RJCodeAdvance.RJControls.RJButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(54)))), ((int)(((byte)(124)))));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registrar Nuevo Pedido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "N.Factura:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha de Entrega";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cliente";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Direccion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 335);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Estado";
            // 
            // txtNfactura
            // 
            this.txtNfactura.BackColor = System.Drawing.SystemColors.Window;
            this.txtNfactura.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtNfactura.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtNfactura.BorderRadius = 15;
            this.txtNfactura.BorderSize = 2;
            this.txtNfactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNfactura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNfactura.Location = new System.Drawing.Point(133, 71);
            this.txtNfactura.Margin = new System.Windows.Forms.Padding(4);
            this.txtNfactura.Multiline = false;
            this.txtNfactura.Name = "txtNfactura";
            this.txtNfactura.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtNfactura.PasswordChar = false;
            this.txtNfactura.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtNfactura.PlaceholderText = "Factura";
            this.txtNfactura.Size = new System.Drawing.Size(250, 35);
            this.txtNfactura.TabIndex = 6;
            this.txtNfactura.Texts = "";
            this.txtNfactura.UnderlinedStyle = false;
            // 
            // txtFechaEntrega
            // 
            this.txtFechaEntrega.BackColor = System.Drawing.SystemColors.Window;
            this.txtFechaEntrega.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtFechaEntrega.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtFechaEntrega.BorderRadius = 15;
            this.txtFechaEntrega.BorderSize = 2;
            this.txtFechaEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaEntrega.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFechaEntrega.Location = new System.Drawing.Point(167, 131);
            this.txtFechaEntrega.Margin = new System.Windows.Forms.Padding(4);
            this.txtFechaEntrega.Multiline = false;
            this.txtFechaEntrega.Name = "txtFechaEntrega";
            this.txtFechaEntrega.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFechaEntrega.PasswordChar = false;
            this.txtFechaEntrega.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtFechaEntrega.PlaceholderText = "yy/mm/dd";
            this.txtFechaEntrega.Size = new System.Drawing.Size(216, 35);
            this.txtFechaEntrega.TabIndex = 7;
            this.txtFechaEntrega.Texts = "";
            this.txtFechaEntrega.UnderlinedStyle = false;
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.SystemColors.Window;
            this.txtCliente.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtCliente.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtCliente.BorderRadius = 15;
            this.txtCliente.BorderSize = 2;
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCliente.Location = new System.Drawing.Point(133, 185);
            this.txtCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtCliente.Multiline = false;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtCliente.PasswordChar = false;
            this.txtCliente.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtCliente.PlaceholderText = "Nombre Cliente";
            this.txtCliente.Size = new System.Drawing.Size(250, 35);
            this.txtCliente.TabIndex = 8;
            this.txtCliente.Texts = "";
            this.txtCliente.UnderlinedStyle = false;
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.SystemColors.Window;
            this.txtDireccion.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtDireccion.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtDireccion.BorderRadius = 15;
            this.txtDireccion.BorderSize = 2;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDireccion.Location = new System.Drawing.Point(133, 246);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDireccion.Multiline = false;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtDireccion.PasswordChar = false;
            this.txtDireccion.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtDireccion.PlaceholderText = "Direccion";
            this.txtDireccion.Size = new System.Drawing.Size(250, 35);
            this.txtDireccion.TabIndex = 9;
            this.txtDireccion.Texts = "";
            this.txtDireccion.UnderlinedStyle = false;
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "En Ruta",
            "Pendiente",
            "Entregado"});
            this.cmbEstado.Location = new System.Drawing.Point(133, 332);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(121, 24);
            this.cmbEstado.TabIndex = 10;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnCancelar.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnCancelar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCancelar.BorderRadius = 15;
            this.btnCancelar.BorderSize = 0;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(27, 405);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(150, 40);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(77)))), ((int)(((byte)(145)))));
            this.btnGuardar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(77)))), ((int)(((byte)(145)))));
            this.btnGuardar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnGuardar.BorderRadius = 15;
            this.btnGuardar.BorderSize = 0;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(288, 405);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 40);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextColor = System.Drawing.Color.White;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FormRegistrarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(595, 450);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.txtFechaEntrega);
            this.Controls.Add(this.txtNfactura);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormRegistrarPedido";
            this.Text = "FormRegistrarPedido";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private RJCodeAdvance.RJControls.RJTextBox txtNfactura;
        private RJCodeAdvance.RJControls.RJTextBox txtFechaEntrega;
        private RJCodeAdvance.RJControls.RJTextBox txtCliente;
        private RJCodeAdvance.RJControls.RJTextBox txtDireccion;
        private System.Windows.Forms.ComboBox cmbEstado;
        private RJCodeAdvance.RJControls.RJButton btnCancelar;
        private RJCodeAdvance.RJControls.RJButton btnGuardar;
    }
}
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
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.txtDireccionAdicional = new RJCodeAdvance.RJControls.RJTextBox();
            this.txtIdFactura = new RJCodeAdvance.RJControls.RJTextBox();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlHeaderModal = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTituloModal = new System.Windows.Forms.Label();
            this.txtFechaEntrega = new RJCodeAdvance.RJControls.RJTextBox();
            this.txtCliente = new RJCodeAdvance.RJControls.RJTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlHeaderModal.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(235)))), ((int)(((byte)(241)))));
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(81)))), ((int)(((byte)(111)))));
            this.btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Ban;
            this.btnCancelar.IconColor = System.Drawing.Color.Black;
            this.btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar.IconSize = 15;
            this.btnCancelar.Location = new System.Drawing.Point(162, 426);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(142, 40);
            this.btnCancelar.TabIndex = 30;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(77)))), ((int)(((byte)(145)))));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnGuardar.IconColor = System.Drawing.Color.White;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 15;
            this.btnGuardar.Location = new System.Drawing.Point(319, 426);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(142, 40);
            this.btnGuardar.TabIndex = 29;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtDireccionAdicional
            // 
            this.txtDireccionAdicional.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.txtDireccionAdicional.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtDireccionAdicional.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtDireccionAdicional.BorderRadius = 15;
            this.txtDireccionAdicional.BorderSize = 2;
            this.txtDireccionAdicional.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccionAdicional.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDireccionAdicional.Location = new System.Drawing.Point(10, 294);
            this.txtDireccionAdicional.Margin = new System.Windows.Forms.Padding(4);
            this.txtDireccionAdicional.Multiline = false;
            this.txtDireccionAdicional.Name = "txtDireccionAdicional";
            this.txtDireccionAdicional.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtDireccionAdicional.PasswordChar = false;
            this.txtDireccionAdicional.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtDireccionAdicional.PlaceholderText = "Direccion";
            this.txtDireccionAdicional.Size = new System.Drawing.Size(294, 35);
            this.txtDireccionAdicional.TabIndex = 28;
            this.txtDireccionAdicional.Texts = "";
            this.txtDireccionAdicional.UnderlinedStyle = false;
            // 
            // txtIdFactura
            // 
            this.txtIdFactura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.txtIdFactura.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtIdFactura.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtIdFactura.BorderRadius = 15;
            this.txtIdFactura.BorderSize = 2;
            this.txtIdFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdFactura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtIdFactura.Location = new System.Drawing.Point(10, 79);
            this.txtIdFactura.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdFactura.Multiline = false;
            this.txtIdFactura.Name = "txtIdFactura";
            this.txtIdFactura.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtIdFactura.PasswordChar = false;
            this.txtIdFactura.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtIdFactura.PlaceholderText = "Numero de factura";
            this.txtIdFactura.Size = new System.Drawing.Size(294, 35);
            this.txtIdFactura.TabIndex = 24;
            this.txtIdFactura.Texts = "";
            this.txtIdFactura.UnderlinedStyle = false;
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "Pendiente",
            "En Ruta"});
            this.cboEstado.Location = new System.Drawing.Point(136, 349);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(168, 24);
            this.cboEstado.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 352);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "Estado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "Direccion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Fecha de entrega";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Numero de factura";
            // 
            // pnlHeaderModal
            // 
            this.pnlHeaderModal.Controls.Add(this.label6);
            this.pnlHeaderModal.Controls.Add(this.lblTituloModal);
            this.pnlHeaderModal.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderModal.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderModal.Name = "pnlHeaderModal";
            this.pnlHeaderModal.Size = new System.Drawing.Size(493, 56);
            this.pnlHeaderModal.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Complete los Datos del Pedido";
            // 
            // lblTituloModal
            // 
            this.lblTituloModal.AutoSize = true;
            this.lblTituloModal.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloModal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(27)))), ((int)(((byte)(96)))));
            this.lblTituloModal.Location = new System.Drawing.Point(12, 9);
            this.lblTituloModal.Name = "lblTituloModal";
            this.lblTituloModal.Size = new System.Drawing.Size(103, 16);
            this.lblTituloModal.TabIndex = 0;
            this.lblTituloModal.Text = "Agregar Pedido";
            // 
            // txtFechaEntrega
            // 
            this.txtFechaEntrega.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.txtFechaEntrega.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtFechaEntrega.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtFechaEntrega.BorderRadius = 15;
            this.txtFechaEntrega.BorderSize = 2;
            this.txtFechaEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaEntrega.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFechaEntrega.Location = new System.Drawing.Point(10, 154);
            this.txtFechaEntrega.Margin = new System.Windows.Forms.Padding(4);
            this.txtFechaEntrega.Multiline = false;
            this.txtFechaEntrega.Name = "txtFechaEntrega";
            this.txtFechaEntrega.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFechaEntrega.PasswordChar = false;
            this.txtFechaEntrega.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtFechaEntrega.PlaceholderText = "";
            this.txtFechaEntrega.Size = new System.Drawing.Size(294, 35);
            this.txtFechaEntrega.TabIndex = 31;
            this.txtFechaEntrega.Texts = "";
            this.txtFechaEntrega.UnderlinedStyle = false;
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.txtCliente.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtCliente.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtCliente.BorderRadius = 15;
            this.txtCliente.BorderSize = 2;
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCliente.Location = new System.Drawing.Point(10, 226);
            this.txtCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtCliente.Multiline = false;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtCliente.PasswordChar = false;
            this.txtCliente.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtCliente.PlaceholderText = "Cliente";
            this.txtCliente.Size = new System.Drawing.Size(294, 35);
            this.txtCliente.TabIndex = 32;
            this.txtCliente.Texts = "";
            this.txtCliente.UnderlinedStyle = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 33;
            this.label5.Text = "Cliente";
            // 
            // FormRegistrarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(493, 524);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.txtFechaEntrega);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtDireccionAdicional);
            this.Controls.Add(this.txtIdFactura);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlHeaderModal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRegistrarPedido";
            this.Text = "FormRegistrarPedido";
            this.pnlHeaderModal.ResumeLayout(false);
            this.pnlHeaderModal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private RJCodeAdvance.RJControls.RJTextBox txtDireccionAdicional;
        private RJCodeAdvance.RJControls.RJTextBox txtIdFactura;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlHeaderModal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTituloModal;
        private RJCodeAdvance.RJControls.RJTextBox txtFechaEntrega;
        private RJCodeAdvance.RJControls.RJTextBox txtCliente;
        private System.Windows.Forms.Label label5;
    }
}
namespace CandyShopSystem
{
    partial class FormClienteModal
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
            this.cmbTipoCliente = new System.Windows.Forms.ComboBox();
            this.pnlHeaderModal = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTituloModal = new System.Windows.Forms.Label();
            this.txtNombreCliente = new RJCodeAdvance.RJControls.RJTextBox();
            this.txtNombreNegocio = new RJCodeAdvance.RJControls.RJTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTelefono = new RJCodeAdvance.RJControls.RJTextBox();
            this.txtDireccionCliente = new RJCodeAdvance.RJControls.RJTextBox();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.pnlHeaderModal.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre Completo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre del Negocio";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Direccion";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 390);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tipo Cliente";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // cmbTipoCliente
            // 
            this.cmbTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoCliente.FormattingEnabled = true;
            this.cmbTipoCliente.Items.AddRange(new object[] {
            "Pulperia",
            "Escuela",
            "Particular"});
            this.cmbTipoCliente.Location = new System.Drawing.Point(142, 382);
            this.cmbTipoCliente.Name = "cmbTipoCliente";
            this.cmbTipoCliente.Size = new System.Drawing.Size(168, 24);
            this.cmbTipoCliente.TabIndex = 8;
            this.cmbTipoCliente.SelectedIndexChanged += new System.EventHandler(this.cmbTipoCliente_SelectedIndexChanged);
            // 
            // pnlHeaderModal
            // 
            this.pnlHeaderModal.Controls.Add(this.label6);
            this.pnlHeaderModal.Controls.Add(this.lblTituloModal);
            this.pnlHeaderModal.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderModal.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderModal.Name = "pnlHeaderModal";
            this.pnlHeaderModal.Size = new System.Drawing.Size(577, 62);
            this.pnlHeaderModal.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Complete los Datos del Cliente";
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
            this.lblTituloModal.Text = "Agregar Cliente";
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.txtNombreCliente.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtNombreCliente.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtNombreCliente.BorderRadius = 15;
            this.txtNombreCliente.BorderSize = 2;
            this.txtNombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNombreCliente.Location = new System.Drawing.Point(10, 94);
            this.txtNombreCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreCliente.Multiline = false;
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtNombreCliente.PasswordChar = false;
            this.txtNombreCliente.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtNombreCliente.PlaceholderText = "Nombre Completo";
            this.txtNombreCliente.Size = new System.Drawing.Size(457, 35);
            this.txtNombreCliente.TabIndex = 11;
            this.txtNombreCliente.Texts = "";
            this.txtNombreCliente.UnderlinedStyle = false;
            // 
            // txtNombreNegocio
            // 
            this.txtNombreNegocio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.txtNombreNegocio.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtNombreNegocio.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtNombreNegocio.BorderRadius = 15;
            this.txtNombreNegocio.BorderSize = 2;
            this.txtNombreNegocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreNegocio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNombreNegocio.Location = new System.Drawing.Point(10, 169);
            this.txtNombreNegocio.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreNegocio.Multiline = false;
            this.txtNombreNegocio.Name = "txtNombreNegocio";
            this.txtNombreNegocio.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtNombreNegocio.PasswordChar = false;
            this.txtNombreNegocio.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtNombreNegocio.PlaceholderText = "Nombre del Negocio";
            this.txtNombreNegocio.Size = new System.Drawing.Size(452, 35);
            this.txtNombreNegocio.TabIndex = 12;
            this.txtNombreNegocio.Texts = "";
            this.txtNombreNegocio.UnderlinedStyle = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Telefono";
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.txtTelefono.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtTelefono.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtTelefono.BorderRadius = 15;
            this.txtTelefono.BorderSize = 2;
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTelefono.Location = new System.Drawing.Point(10, 321);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefono.Multiline = false;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtTelefono.PasswordChar = false;
            this.txtTelefono.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtTelefono.PlaceholderText = "Telefono";
            this.txtTelefono.Size = new System.Drawing.Size(182, 35);
            this.txtTelefono.TabIndex = 14;
            this.txtTelefono.Texts = "";
            this.txtTelefono.UnderlinedStyle = false;
            // 
            // txtDireccionCliente
            // 
            this.txtDireccionCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.txtDireccionCliente.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtDireccionCliente.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtDireccionCliente.BorderRadius = 15;
            this.txtDireccionCliente.BorderSize = 2;
            this.txtDireccionCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccionCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDireccionCliente.Location = new System.Drawing.Point(10, 246);
            this.txtDireccionCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtDireccionCliente.Multiline = false;
            this.txtDireccionCliente.Name = "txtDireccionCliente";
            this.txtDireccionCliente.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtDireccionCliente.PasswordChar = false;
            this.txtDireccionCliente.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtDireccionCliente.PlaceholderText = "Direccion";
            this.txtDireccionCliente.Size = new System.Drawing.Size(250, 35);
            this.txtDireccionCliente.TabIndex = 15;
            this.txtDireccionCliente.Texts = "";
            this.txtDireccionCliente.UnderlinedStyle = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(77)))), ((int)(((byte)(145)))));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnGuardar.IconColor = System.Drawing.Color.White;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 15;
            this.btnGuardar.Location = new System.Drawing.Point(423, 441);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(142, 40);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(235)))), ((int)(((byte)(241)))));
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(81)))), ((int)(((byte)(111)))));
            this.btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Ban;
            this.btnCancelar.IconColor = System.Drawing.Color.Black;
            this.btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar.IconSize = 15;
            this.btnCancelar.Location = new System.Drawing.Point(269, 441);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(142, 40);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormClienteModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(577, 493);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtDireccionCliente);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNombreNegocio);
            this.Controls.Add(this.txtNombreCliente);
            this.Controls.Add(this.cmbTipoCliente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlHeaderModal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FormClienteModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormClienteModal";
            this.pnlHeaderModal.ResumeLayout(false);
            this.pnlHeaderModal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTipoCliente;
        private System.Windows.Forms.Panel pnlHeaderModal;
        private System.Windows.Forms.Label lblTituloModal;
        private RJCodeAdvance.RJControls.RJTextBox txtNombreCliente;
        private RJCodeAdvance.RJControls.RJTextBox txtNombreNegocio;
        private System.Windows.Forms.Label label5;
        private RJCodeAdvance.RJControls.RJTextBox txtTelefono;
        private RJCodeAdvance.RJControls.RJTextBox txtDireccionCliente;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private System.Windows.Forms.Label label6;
    }
}
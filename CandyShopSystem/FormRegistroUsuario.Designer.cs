namespace CandyShopSystem
{
    partial class FormRegistroUsuario
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuario = new RJCodeAdvance.RJControls.RJTextBox();
            this.txtClave = new RJCodeAdvance.RJControls.RJTextBox();
            this.txtConfirmarClave = new RJCodeAdvance.RJControls.RJTextBox();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRegistrar = new RJCodeAdvance.RJControls.RJButton();
            this.btnCancelar = new RJCodeAdvance.RJControls.RJButton();
            this.btnVerPassword = new FontAwesome.Sharp.IconButton();
            this.btnConfirmar = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(45)))), ((int)(((byte)(85)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.picLogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 497);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(219)))));
            this.label2.Location = new System.Drawing.Point(23, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sistema de Gestion y Ventas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "CandyShop System";
            // 
            // picLogo
            // 
            this.picLogo.Image = global::CandyShopSystem.Properties.Resources.WhatsApp_Image_2026_08_23_at_4_44_35_PM;
            this.picLogo.Location = new System.Drawing.Point(0, 35);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(221, 137);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 2;
            this.picLogo.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(415, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(259, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "CREAR USUARIO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(417, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Bienvenido, Ingrese sus Datos";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.SystemColors.Window;
            this.txtUsuario.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtUsuario.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtUsuario.BorderRadius = 10;
            this.txtUsuario.BorderSize = 2;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUsuario.Location = new System.Drawing.Point(370, 106);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsuario.Multiline = false;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtUsuario.PasswordChar = false;
            this.txtUsuario.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtUsuario.PlaceholderText = "Nombre de Usuario";
            this.txtUsuario.Size = new System.Drawing.Size(340, 35);
            this.txtUsuario.TabIndex = 4;
            this.txtUsuario.Texts = "";
            this.txtUsuario.UnderlinedStyle = false;
            // 
            // txtClave
            // 
            this.txtClave.BackColor = System.Drawing.SystemColors.Window;
            this.txtClave.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtClave.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtClave.BorderRadius = 10;
            this.txtClave.BorderSize = 2;
            this.txtClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtClave.Location = new System.Drawing.Point(370, 178);
            this.txtClave.Margin = new System.Windows.Forms.Padding(4);
            this.txtClave.Multiline = false;
            this.txtClave.Name = "txtClave";
            this.txtClave.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtClave.PasswordChar = false;
            this.txtClave.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtClave.PlaceholderText = "Contraseña";
            this.txtClave.Size = new System.Drawing.Size(340, 35);
            this.txtClave.TabIndex = 5;
            this.txtClave.Texts = "";
            this.txtClave.UnderlinedStyle = false;
            // 
            // txtConfirmarClave
            // 
            this.txtConfirmarClave.BackColor = System.Drawing.SystemColors.Window;
            this.txtConfirmarClave.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtConfirmarClave.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtConfirmarClave.BorderRadius = 10;
            this.txtConfirmarClave.BorderSize = 2;
            this.txtConfirmarClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmarClave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConfirmarClave.Location = new System.Drawing.Point(370, 248);
            this.txtConfirmarClave.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfirmarClave.Multiline = false;
            this.txtConfirmarClave.Name = "txtConfirmarClave";
            this.txtConfirmarClave.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtConfirmarClave.PasswordChar = false;
            this.txtConfirmarClave.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtConfirmarClave.PlaceholderText = "Confirmar contraseña";
            this.txtConfirmarClave.Size = new System.Drawing.Size(340, 35);
            this.txtConfirmarClave.TabIndex = 6;
            this.txtConfirmarClave.Texts = "";
            this.txtConfirmarClave.UnderlinedStyle = false;
            // 
            // cmbRol
            // 
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Items.AddRange(new object[] {
            "Administrador",
            "Auxiliar de Ventas",
            "Repartidor"});
            this.cmbRol.Location = new System.Drawing.Point(491, 314);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(219, 24);
            this.cmbRol.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(367, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Seleccione su Rol";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(45)))), ((int)(((byte)(85)))));
            this.btnRegistrar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(45)))), ((int)(((byte)(85)))));
            this.btnRegistrar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnRegistrar.BorderRadius = 15;
            this.btnRegistrar.BorderSize = 0;
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(547, 430);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(150, 40);
            this.btnRegistrar.TabIndex = 9;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.TextColor = System.Drawing.Color.White;
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
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
            this.btnCancelar.Location = new System.Drawing.Point(723, 430);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(150, 40);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnVerPassword
            // 
            this.btnVerPassword.BackColor = System.Drawing.Color.Transparent;
            this.btnVerPassword.FlatAppearance.BorderSize = 0;
            this.btnVerPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerPassword.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btnVerPassword.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(170)))));
            this.btnVerPassword.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVerPassword.IconSize = 20;
            this.btnVerPassword.Location = new System.Drawing.Point(717, 186);
            this.btnVerPassword.Name = "btnVerPassword";
            this.btnVerPassword.Size = new System.Drawing.Size(39, 27);
            this.btnVerPassword.TabIndex = 11;
            this.btnVerPassword.UseVisualStyleBackColor = false;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btnConfirmar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(170)))));
            this.btnConfirmar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnConfirmar.IconSize = 20;
            this.btnConfirmar.Location = new System.Drawing.Point(717, 256);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(39, 27);
            this.btnConfirmar.TabIndex = 12;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            // 
            // FormRegistroUsuario
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(900, 497);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnVerPassword);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.txtConfirmarClave);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRegistroUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormRegistroUsuario";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private RJCodeAdvance.RJControls.RJTextBox txtUsuario;
        private RJCodeAdvance.RJControls.RJTextBox txtClave;
        private RJCodeAdvance.RJControls.RJTextBox txtConfirmarClave;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.Label label5;
        private RJCodeAdvance.RJControls.RJButton btnRegistrar;
        private RJCodeAdvance.RJControls.RJButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnVerPassword;
        private FontAwesome.Sharp.IconButton btnConfirmar;
    }
}
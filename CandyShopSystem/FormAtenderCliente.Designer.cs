namespace CandyShopSystem
{
    partial class FormAtenderCliente
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblLabelTipo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLabelNombreCliente = new System.Windows.Forms.Label();
            this.lblNombreNegocio = new System.Windows.Forms.Label();
            this.lblLabelContacto = new System.Windows.Forms.Label();
            this.btnCompletarVenta = new RJCodeAdvance.RJControls.RJButton();
            this.lblClientesRestantes = new System.Windows.Forms.Label();
            this.lblTipoCliente = new System.Windows.Forms.Label();
            this.lblContacto = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(46)))), ((int)(((byte)(95)))));
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(238)))));
            this.label1.Location = new System.Drawing.Point(279, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "cliente extraido de la cola";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitulo.Location = new System.Drawing.Point(237, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(258, 31);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "ATENCION DE CLIENTES";
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.pnlCard.Controls.Add(this.lblLabelTipo);
            this.pnlCard.Controls.Add(this.label2);
            this.pnlCard.Controls.Add(this.lblLabelNombreCliente);
            this.pnlCard.Controls.Add(this.lblNombreNegocio);
            this.pnlCard.Controls.Add(this.lblLabelContacto);
            this.pnlCard.Controls.Add(this.btnCompletarVenta);
            this.pnlCard.Controls.Add(this.lblClientesRestantes);
            this.pnlCard.Controls.Add(this.lblTipoCliente);
            this.pnlCard.Controls.Add(this.lblContacto);
            this.pnlCard.Controls.Add(this.picLogo);
            this.pnlCard.Controls.Add(this.lblNombre);
            this.pnlCard.Location = new System.Drawing.Point(52, 66);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(690, 270);
            this.pnlCard.TabIndex = 1;
            // 
            // lblLabelTipo
            // 
            this.lblLabelTipo.AutoSize = true;
            this.lblLabelTipo.Location = new System.Drawing.Point(199, 137);
            this.lblLabelTipo.Name = "lblLabelTipo";
            this.lblLabelTipo.Size = new System.Drawing.Size(35, 16);
            this.lblLabelTipo.TabIndex = 17;
            this.lblLabelTipo.Text = "Tipo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Nombre Negocio";
            // 
            // lblLabelNombreCliente
            // 
            this.lblLabelNombreCliente.AutoSize = true;
            this.lblLabelNombreCliente.Location = new System.Drawing.Point(199, 32);
            this.lblLabelNombreCliente.Name = "lblLabelNombreCliente";
            this.lblLabelNombreCliente.Size = new System.Drawing.Size(51, 16);
            this.lblLabelNombreCliente.TabIndex = 15;
            this.lblLabelNombreCliente.Text = "Cliente:";
            // 
            // lblNombreNegocio
            // 
            this.lblNombreNegocio.AutoSize = true;
            this.lblNombreNegocio.Location = new System.Drawing.Point(316, 68);
            this.lblNombreNegocio.Name = "lblNombreNegocio";
            this.lblNombreNegocio.Size = new System.Drawing.Size(141, 16);
            this.lblNombreNegocio.TabIndex = 13;
            this.lblNombreNegocio.Text = "[Nombre del Negocio]";
            // 
            // lblLabelContacto
            // 
            this.lblLabelContacto.AutoSize = true;
            this.lblLabelContacto.Location = new System.Drawing.Point(199, 108);
            this.lblLabelContacto.Name = "lblLabelContacto";
            this.lblLabelContacto.Size = new System.Drawing.Size(60, 16);
            this.lblLabelContacto.TabIndex = 12;
            this.lblLabelContacto.Text = "Contacto";
            // 
            // btnCompletarVenta
            // 
            this.btnCompletarVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(46)))), ((int)(((byte)(95)))));
            this.btnCompletarVenta.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(46)))), ((int)(((byte)(95)))));
            this.btnCompletarVenta.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCompletarVenta.BorderRadius = 15;
            this.btnCompletarVenta.BorderSize = 0;
            this.btnCompletarVenta.FlatAppearance.BorderSize = 0;
            this.btnCompletarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompletarVenta.ForeColor = System.Drawing.Color.White;
            this.btnCompletarVenta.Location = new System.Drawing.Point(271, 227);
            this.btnCompletarVenta.Name = "btnCompletarVenta";
            this.btnCompletarVenta.Size = new System.Drawing.Size(150, 40);
            this.btnCompletarVenta.TabIndex = 10;
            this.btnCompletarVenta.Text = "Completar Atencion";
            this.btnCompletarVenta.TextColor = System.Drawing.Color.White;
            this.btnCompletarVenta.UseVisualStyleBackColor = false;
            this.btnCompletarVenta.Click += new System.EventHandler(this.btnCompletarVenta_Click);
            // 
            // lblClientesRestantes
            // 
            this.lblClientesRestantes.AutoSize = true;
            this.lblClientesRestantes.ForeColor = System.Drawing.Color.Blue;
            this.lblClientesRestantes.Location = new System.Drawing.Point(268, 199);
            this.lblClientesRestantes.Name = "lblClientesRestantes";
            this.lblClientesRestantes.Size = new System.Drawing.Size(167, 16);
            this.lblClientesRestantes.TabIndex = 9;
            this.lblClientesRestantes.Text = "Quedan X clientes en la fila";
            // 
            // lblTipoCliente
            // 
            this.lblTipoCliente.AutoSize = true;
            this.lblTipoCliente.Location = new System.Drawing.Point(316, 137);
            this.lblTipoCliente.Name = "lblTipoCliente";
            this.lblTipoCliente.Size = new System.Drawing.Size(35, 16);
            this.lblTipoCliente.TabIndex = 8;
            this.lblTipoCliente.Text = "Tipo";
            // 
            // lblContacto
            // 
            this.lblContacto.AutoSize = true;
            this.lblContacto.Location = new System.Drawing.Point(316, 108);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(60, 16);
            this.lblContacto.TabIndex = 7;
            this.lblContacto.Text = "Contacto";
            // 
            // picLogo
            // 
            this.picLogo.Image = global::CandyShopSystem.Properties.Resources.WhatsApp_Image_2026_08_23_at_4_44_35_PM;
            this.picLogo.Location = new System.Drawing.Point(0, 32);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(182, 137);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 3;
            this.picLogo.TabStop = false;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(316, 32);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(51, 16);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Cliente:";
            // 
            // FormAtenderCliente
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 382);
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAtenderCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormAtenderCliente";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblContacto;
        private RJCodeAdvance.RJControls.RJButton btnCompletarVenta;
        private System.Windows.Forms.Label lblClientesRestantes;
        private System.Windows.Forms.Label lblTipoCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLabelNombreCliente;
        private System.Windows.Forms.Label lblNombreNegocio;
        private System.Windows.Forms.Label lblLabelContacto;
        private System.Windows.Forms.Label lblLabelTipo;
    }
}
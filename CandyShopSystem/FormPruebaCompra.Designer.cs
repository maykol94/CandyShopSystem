using PresentationLayer;

namespace CandyShopSystem
{
    partial class FormPruebaCompra
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
            this.uC_Compras1 = new PresentationLayer.UC_Compras();
            this.SuspendLayout();
            // 
            // uC_Compras1
            // 
            this.uC_Compras1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_Compras1.Location = new System.Drawing.Point(0, 0);
            this.uC_Compras1.Name = "uC_Compras1";
            this.uC_Compras1.Size = new System.Drawing.Size(1281, 717);
            this.uC_Compras1.TabIndex = 0;
            // 
            // FormPruebaCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 717);
            this.Controls.Add(this.uC_Compras1);
            this.Name = "FormPruebaCompra";
            this.Text = "FormPruebaCompra";
            this.ResumeLayout(false);

        }

        #endregion

        private UC_Compras uC_Compras1;
    }
}
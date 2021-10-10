
namespace Cyber
{
    partial class FrmFactura
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
            this.rtbFactura = new System.Windows.Forms.RichTextBox();
            this.btnSobreFacturar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbFactura
            // 
            this.rtbFactura.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rtbFactura.Location = new System.Drawing.Point(27, 12);
            this.rtbFactura.Name = "rtbFactura";
            this.rtbFactura.ReadOnly = true;
            this.rtbFactura.Size = new System.Drawing.Size(338, 452);
            this.rtbFactura.TabIndex = 0;
            this.rtbFactura.Text = "";
            // 
            // btnSobreFacturar
            // 
            this.btnSobreFacturar.Location = new System.Drawing.Point(130, 470);
            this.btnSobreFacturar.Name = "btnSobreFacturar";
            this.btnSobreFacturar.Size = new System.Drawing.Size(137, 42);
            this.btnSobreFacturar.TabIndex = 1;
            this.btnSobreFacturar.Text = "Sobre Facturar";
            this.btnSobreFacturar.UseVisualStyleBackColor = true;
            this.btnSobreFacturar.Click += new System.EventHandler(this.btnSobreFacturar_Click);
            // 
            // FrmFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 524);
            this.Controls.Add(this.btnSobreFacturar);
            this.Controls.Add(this.rtbFactura);
            this.Name = "FrmFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Factura";
            this.Load += new System.EventHandler(this.FrmFactura_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbFactura;
        private System.Windows.Forms.Button btnSobreFacturar;
    }
}
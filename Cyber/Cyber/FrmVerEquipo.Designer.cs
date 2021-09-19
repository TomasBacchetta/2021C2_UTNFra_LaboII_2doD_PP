
namespace Cyber
{
    partial class FrmVerEquipo
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
            this.richTextBoxDatosEquipo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBoxDatosEquipo
            // 
            this.richTextBoxDatosEquipo.Location = new System.Drawing.Point(23, 30);
            this.richTextBoxDatosEquipo.Name = "richTextBoxDatosEquipo";
            this.richTextBoxDatosEquipo.Size = new System.Drawing.Size(322, 366);
            this.richTextBoxDatosEquipo.TabIndex = 0;
            this.richTextBoxDatosEquipo.Text = "";
            // 
            // FrmVerEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 436);
            this.Controls.Add(this.richTextBoxDatosEquipo);
            this.Name = "FrmVerEquipo";
            this.Text = "FrmVerEquipo";
            this.Load += new System.EventHandler(this.FrmVerEquipo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxDatosEquipo;
    }
}
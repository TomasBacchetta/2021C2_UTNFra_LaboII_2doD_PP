
namespace Cyber
{
    partial class FrmHistorialEquipo
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
            this.richTextBoxHistorial = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBoxHistorial
            // 
            this.richTextBoxHistorial.Location = new System.Drawing.Point(42, 33);
            this.richTextBoxHistorial.Name = "richTextBoxHistorial";
            this.richTextBoxHistorial.Size = new System.Drawing.Size(286, 384);
            this.richTextBoxHistorial.TabIndex = 0;
            this.richTextBoxHistorial.Text = "";
            // 
            // FrmHistorialEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 450);
            this.Controls.Add(this.richTextBoxHistorial);
            this.Name = "FrmHistorialEquipo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmHistorialEquipo";
            this.Load += new System.EventHandler(this.FrmHistorialEquipo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxHistorial;
    }
}
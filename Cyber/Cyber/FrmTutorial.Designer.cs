
namespace Cyber
{
    partial class FrmTutorial
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
            this.rtbTutorial1 = new System.Windows.Forms.RichTextBox();
            this.rtbTutorial2 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbTutorial1
            // 
            this.rtbTutorial1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rtbTutorial1.Location = new System.Drawing.Point(12, 60);
            this.rtbTutorial1.Name = "rtbTutorial1";
            this.rtbTutorial1.ReadOnly = true;
            this.rtbTutorial1.Size = new System.Drawing.Size(244, 516);
            this.rtbTutorial1.TabIndex = 0;
            this.rtbTutorial1.Text = "";
            // 
            // rtbTutorial2
            // 
            this.rtbTutorial2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rtbTutorial2.Location = new System.Drawing.Point(722, 60);
            this.rtbTutorial2.Name = "rtbTutorial2";
            this.rtbTutorial2.ReadOnly = true;
            this.rtbTutorial2.Size = new System.Drawing.Size(241, 516);
            this.rtbTutorial2.TabIndex = 1;
            this.rtbTutorial2.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Conceptos básicos:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(722, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sobre la felicidad:";
            // 
            // FrmTutorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Cyber.Properties.Resources.Smtjack;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(984, 606);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbTutorial2);
            this.Controls.Add(this.rtbTutorial1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "FrmTutorial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tutorial";
            this.Load += new System.EventHandler(this.FrmTutorial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbTutorial1;
        private System.Windows.Forms.RichTextBox rtbTutorial2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
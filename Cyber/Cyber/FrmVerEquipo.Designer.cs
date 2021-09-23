
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
            this.buttonTerminarSesion = new System.Windows.Forms.Button();
            this.richTextBoxProximoCliente = new System.Windows.Forms.RichTextBox();
            this.labelSubColaClientes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBoxDatosEquipo
            // 
            this.richTextBoxDatosEquipo.Location = new System.Drawing.Point(23, 30);
            this.richTextBoxDatosEquipo.Name = "richTextBoxDatosEquipo";
            this.richTextBoxDatosEquipo.Size = new System.Drawing.Size(234, 346);
            this.richTextBoxDatosEquipo.TabIndex = 0;
            this.richTextBoxDatosEquipo.Text = "";
            // 
            // buttonTerminarSesion
            // 
            this.buttonTerminarSesion.Location = new System.Drawing.Point(78, 382);
            this.buttonTerminarSesion.Name = "buttonTerminarSesion";
            this.buttonTerminarSesion.Size = new System.Drawing.Size(114, 42);
            this.buttonTerminarSesion.TabIndex = 1;
            this.buttonTerminarSesion.Text = "Terminar Sesión";
            this.buttonTerminarSesion.UseVisualStyleBackColor = true;
            this.buttonTerminarSesion.Click += new System.EventHandler(this.buttonTerminarSesion_Click);
            // 
            // richTextBoxProximoCliente
            // 
            this.richTextBoxProximoCliente.Location = new System.Drawing.Point(281, 192);
            this.richTextBoxProximoCliente.Name = "richTextBoxProximoCliente";
            this.richTextBoxProximoCliente.Size = new System.Drawing.Size(158, 184);
            this.richTextBoxProximoCliente.TabIndex = 2;
            this.richTextBoxProximoCliente.Text = "";
            // 
            // labelSubColaClientes
            // 
            this.labelSubColaClientes.AutoSize = true;
            this.labelSubColaClientes.Location = new System.Drawing.Point(281, 174);
            this.labelSubColaClientes.Name = "labelSubColaClientes";
            this.labelSubColaClientes.Size = new System.Drawing.Size(90, 15);
            this.labelSubColaClientes.TabIndex = 3;
            this.labelSubColaClientes.Text = "Proximo cliente";
            // 
            // FrmVerEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 436);
            this.Controls.Add(this.labelSubColaClientes);
            this.Controls.Add(this.richTextBoxProximoCliente);
            this.Controls.Add(this.buttonTerminarSesion);
            this.Controls.Add(this.richTextBoxDatosEquipo);
            this.Name = "FrmVerEquipo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVerEquipo";
            this.Load += new System.EventHandler(this.FrmVerEquipo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxDatosEquipo;
        private System.Windows.Forms.Button buttonTerminarSesion;
        private System.Windows.Forms.RichTextBox richTextBoxProximoCliente;
        private System.Windows.Forms.Label labelSubColaClientes;
    }
}
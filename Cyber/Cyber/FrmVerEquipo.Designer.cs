﻿
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
            this.components = new System.ComponentModel.Container();
            this.richTextBoxDatosEquipo = new System.Windows.Forms.RichTextBox();
            this.buttonTerminarSesion = new System.Windows.Forms.Button();
            this.richTextBoxProximoCliente = new System.Windows.Forms.RichTextBox();
            this.labelSubColaClientes = new System.Windows.Forms.Label();
            this.buttonHistorialSesiones = new System.Windows.Forms.Button();
            this.pictureBoxJack = new System.Windows.Forms.PictureBox();
            this.labelFelicidad = new System.Windows.Forms.Label();
            this.btnComprarProd = new System.Windows.Forms.Button();
            this.lblEfectos = new System.Windows.Forms.Label();
            this.pctChino = new System.Windows.Forms.PictureBox();
            this.pctTabaco = new System.Windows.Forms.PictureBox();
            this.toolTipEfectoChino = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipEfectoTabaco = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxJack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctChino)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctTabaco)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBoxDatosEquipo
            // 
            this.richTextBoxDatosEquipo.Location = new System.Drawing.Point(23, 30);
            this.richTextBoxDatosEquipo.Name = "richTextBoxDatosEquipo";
            this.richTextBoxDatosEquipo.ReadOnly = true;
            this.richTextBoxDatosEquipo.Size = new System.Drawing.Size(216, 388);
            this.richTextBoxDatosEquipo.TabIndex = 0;
            this.richTextBoxDatosEquipo.Text = "";
            // 
            // buttonTerminarSesion
            // 
            this.buttonTerminarSesion.Location = new System.Drawing.Point(268, 89);
            this.buttonTerminarSesion.Name = "buttonTerminarSesion";
            this.buttonTerminarSesion.Size = new System.Drawing.Size(146, 74);
            this.buttonTerminarSesion.TabIndex = 1;
            this.buttonTerminarSesion.Text = "Cerrar Sesión";
            this.buttonTerminarSesion.UseVisualStyleBackColor = true;
            this.buttonTerminarSesion.Click += new System.EventHandler(this.ButtonTerminarSesion_Click);
            // 
            // richTextBoxProximoCliente
            // 
            this.richTextBoxProximoCliente.Location = new System.Drawing.Point(258, 230);
            this.richTextBoxProximoCliente.Name = "richTextBoxProximoCliente";
            this.richTextBoxProximoCliente.ReadOnly = true;
            this.richTextBoxProximoCliente.Size = new System.Drawing.Size(170, 188);
            this.richTextBoxProximoCliente.TabIndex = 2;
            this.richTextBoxProximoCliente.Text = "";
            // 
            // labelSubColaClientes
            // 
            this.labelSubColaClientes.AutoSize = true;
            this.labelSubColaClientes.Location = new System.Drawing.Point(258, 212);
            this.labelSubColaClientes.Name = "labelSubColaClientes";
            this.labelSubColaClientes.Size = new System.Drawing.Size(170, 15);
            this.labelSubColaClientes.TabIndex = 3;
            this.labelSubColaClientes.Text = "Proximo cliente de este equipo";
            // 
            // buttonHistorialSesiones
            // 
            this.buttonHistorialSesiones.Location = new System.Drawing.Point(336, 490);
            this.buttonHistorialSesiones.Name = "buttonHistorialSesiones";
            this.buttonHistorialSesiones.Size = new System.Drawing.Size(103, 42);
            this.buttonHistorialSesiones.TabIndex = 4;
            this.buttonHistorialSesiones.Text = "Ver historial";
            this.buttonHistorialSesiones.UseVisualStyleBackColor = true;
            this.buttonHistorialSesiones.Click += new System.EventHandler(this.ButtonHistorialSesiones_Click);
            // 
            // pictureBoxJack
            // 
            this.pictureBoxJack.BackgroundImage = global::Cyber.Properties.Resources.iconoJack;
            this.pictureBoxJack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxJack.Location = new System.Drawing.Point(12, 465);
            this.pictureBoxJack.Name = "pictureBoxJack";
            this.pictureBoxJack.Size = new System.Drawing.Size(72, 67);
            this.pictureBoxJack.TabIndex = 5;
            this.pictureBoxJack.TabStop = false;
            // 
            // labelFelicidad
            // 
            this.labelFelicidad.AutoSize = true;
            this.labelFelicidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelFelicidad.Location = new System.Drawing.Point(99, 465);
            this.labelFelicidad.Name = "labelFelicidad";
            this.labelFelicidad.Size = new System.Drawing.Size(161, 21);
            this.labelFelicidad.TabIndex = 6;
            this.labelFelicidad.Text = "Puntos de felicidad:";
            // 
            // btnComprarProd
            // 
            this.btnComprarProd.Location = new System.Drawing.Point(99, 489);
            this.btnComprarProd.Name = "btnComprarProd";
            this.btnComprarProd.Size = new System.Drawing.Size(159, 43);
            this.btnComprarProd.TabIndex = 8;
            this.btnComprarProd.Text = "Comprar Productos";
            this.btnComprarProd.UseVisualStyleBackColor = true;
            this.btnComprarProd.Click += new System.EventHandler(this.BtnComprarProd_Click);
            // 
            // lblEfectos
            // 
            this.lblEfectos.AutoSize = true;
            this.lblEfectos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEfectos.Location = new System.Drawing.Point(275, 9);
            this.lblEfectos.Name = "lblEfectos";
            this.lblEfectos.Size = new System.Drawing.Size(64, 20);
            this.lblEfectos.TabIndex = 9;
            this.lblEfectos.Text = "Efectos:";
            this.lblEfectos.Visible = false;
            // 
            // pctChino
            // 
            this.pctChino.BackgroundImage = global::Cyber.Properties.Resources.efectoBebidaChina1;
            this.pctChino.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctChino.Location = new System.Drawing.Point(275, 32);
            this.pctChino.Name = "pctChino";
            this.pctChino.Size = new System.Drawing.Size(47, 43);
            this.pctChino.TabIndex = 10;
            this.pctChino.TabStop = false;
            this.pctChino.Visible = false;
            // 
            // pctTabaco
            // 
            this.pctTabaco.BackgroundImage = global::Cyber.Properties.Resources.efectoTabaco;
            this.pctTabaco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctTabaco.Location = new System.Drawing.Point(336, 32);
            this.pctTabaco.Name = "pctTabaco";
            this.pctTabaco.Size = new System.Drawing.Size(47, 43);
            this.pctTabaco.TabIndex = 11;
            this.pctTabaco.TabStop = false;
            this.pctTabaco.Visible = false;
            // 
            // FrmVerEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 544);
            this.Controls.Add(this.pctTabaco);
            this.Controls.Add(this.pctChino);
            this.Controls.Add(this.lblEfectos);
            this.Controls.Add(this.btnComprarProd);
            this.Controls.Add(this.labelFelicidad);
            this.Controls.Add(this.pictureBoxJack);
            this.Controls.Add(this.buttonHistorialSesiones);
            this.Controls.Add(this.labelSubColaClientes);
            this.Controls.Add(this.richTextBoxProximoCliente);
            this.Controls.Add(this.buttonTerminarSesion);
            this.Controls.Add(this.richTextBoxDatosEquipo);
            this.MaximizeBox = false;
            this.Name = "FrmVerEquipo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVerEquipo";
            this.Load += new System.EventHandler(this.FrmVerEquipo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxJack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctChino)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctTabaco)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxDatosEquipo;
        private System.Windows.Forms.Button buttonTerminarSesion;
        private System.Windows.Forms.RichTextBox richTextBoxProximoCliente;
        private System.Windows.Forms.Label labelSubColaClientes;
        private System.Windows.Forms.Button buttonHistorialSesiones;
        private System.Windows.Forms.PictureBox pictureBoxJack;
        private System.Windows.Forms.Label labelFelicidad;
        private System.Windows.Forms.Button btnComprarProd;
        private System.Windows.Forms.Label lblEfectos;
        private System.Windows.Forms.PictureBox pctChino;
        private System.Windows.Forms.PictureBox pctTabaco;
        private System.Windows.Forms.ToolTip toolTipEfectoChino;
        private System.Windows.Forms.ToolTip toolTipEfectoTabaco;
    }
}
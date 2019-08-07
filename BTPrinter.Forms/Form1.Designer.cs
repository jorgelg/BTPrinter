namespace BTPrinter.Forms
{
    partial class Form1
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
            this.BtnRecibirImagen = new System.Windows.Forms.Button();
            this.imgVista = new System.Windows.Forms.PictureBox();
            this.BtnImprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgVista)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnRecibirImagen
            // 
            this.BtnRecibirImagen.Location = new System.Drawing.Point(702, 66);
            this.BtnRecibirImagen.Name = "BtnRecibirImagen";
            this.BtnRecibirImagen.Size = new System.Drawing.Size(133, 57);
            this.BtnRecibirImagen.TabIndex = 0;
            this.BtnRecibirImagen.Text = "Recibir imagen";
            this.BtnRecibirImagen.UseVisualStyleBackColor = true;
            this.BtnRecibirImagen.Click += new System.EventHandler(this.BtnRecibir_click);
            // 
            // imgVista
            // 
            this.imgVista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgVista.Location = new System.Drawing.Point(110, 46);
            this.imgVista.Name = "imgVista";
            this.imgVista.Size = new System.Drawing.Size(406, 399);
            this.imgVista.TabIndex = 1;
            this.imgVista.TabStop = false;
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Location = new System.Drawing.Point(702, 160);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(133, 64);
            this.BtnImprimir.TabIndex = 2;
            this.BtnImprimir.Text = "Imprimir";
            this.BtnImprimir.UseVisualStyleBackColor = true;
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 486);
            this.Controls.Add(this.BtnImprimir);
            this.Controls.Add(this.imgVista);
            this.Controls.Add(this.BtnRecibirImagen);
            this.Name = "Form1";
            this.Text = "Receptor de imagenes";
            ((System.ComponentModel.ISupportInitialize)(this.imgVista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnRecibirImagen;
        private System.Windows.Forms.PictureBox imgVista;
        private System.Windows.Forms.Button BtnImprimir;
    }
}


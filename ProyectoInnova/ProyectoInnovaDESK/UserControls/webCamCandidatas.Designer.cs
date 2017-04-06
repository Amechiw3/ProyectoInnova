namespace ProyectoInnovaDESK.userControl
{
    partial class webCamCandidatas
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.picImagen = new System.Windows.Forms.PictureBox();
            this.cmbCamaras = new System.Windows.Forms.ComboBox();
            this.btnTomarFoto = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // picImagen
            // 
            this.picImagen.Location = new System.Drawing.Point(3, 3);
            this.picImagen.Name = "picImagen";
            this.picImagen.Size = new System.Drawing.Size(194, 145);
            this.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImagen.TabIndex = 0;
            this.picImagen.TabStop = false;
            // 
            // cmbCamaras
            // 
            this.cmbCamaras.FormattingEnabled = true;
            this.cmbCamaras.Location = new System.Drawing.Point(3, 154);
            this.cmbCamaras.Name = "cmbCamaras";
            this.cmbCamaras.Size = new System.Drawing.Size(194, 21);
            this.cmbCamaras.TabIndex = 2;
            // 
            // btnTomarFoto
            // 
            this.btnTomarFoto.Location = new System.Drawing.Point(3, 181);
            this.btnTomarFoto.Name = "btnTomarFoto";
            this.btnTomarFoto.Size = new System.Drawing.Size(194, 23);
            this.btnTomarFoto.TabIndex = 3;
            this.btnTomarFoto.Text = "Iniciar / Finalizar";
            this.btnTomarFoto.UseVisualStyleBackColor = true;
            this.btnTomarFoto.Click += new System.EventHandler(this.btnTomarFoto_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(3, 207);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(165, 13);
            this.lblError.TabIndex = 4;
            this.lblError.Text = "NO SE DETECTO DISPOSITIVO";
            this.lblError.Visible = false;
            // 
            // webCamCandidatas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnTomarFoto);
            this.Controls.Add(this.cmbCamaras);
            this.Controls.Add(this.picImagen);
            this.Name = "webCamCandidatas";
            this.Size = new System.Drawing.Size(200, 229);
            this.Load += new System.EventHandler(this.webCamCandidatas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picImagen;
        private System.Windows.Forms.ComboBox cmbCamaras;
        private System.Windows.Forms.Button btnTomarFoto;
        private System.Windows.Forms.Label lblError;
    }
}

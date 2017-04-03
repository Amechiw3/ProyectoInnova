namespace ProyectoInnovaDESK.userControl
{
    partial class ucFichaMunicipio
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pBoxFoto = new System.Windows.Forms.PictureBox();
            this.cmbCamaras = new System.Windows.Forms.ComboBox();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pBoxFoto
            // 
            this.pBoxFoto.Location = new System.Drawing.Point(3, 3);
            this.pBoxFoto.Name = "pBoxFoto";
            this.pBoxFoto.Size = new System.Drawing.Size(194, 115);
            this.pBoxFoto.TabIndex = 0;
            this.pBoxFoto.TabStop = false;
            // 
            // cmbCamaras
            // 
            this.cmbCamaras.FormattingEnabled = true;
            this.cmbCamaras.Location = new System.Drawing.Point(3, 124);
            this.cmbCamaras.Name = "cmbCamaras";
            this.cmbCamaras.Size = new System.Drawing.Size(194, 21);
            this.cmbCamaras.TabIndex = 1;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(4, 152);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(193, 23);
            this.btnIniciar.TabIndex = 2;
            this.btnIniciar.Text = "Iniciar/ Cancelar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnExaminar
            // 
            this.btnExaminar.Location = new System.Drawing.Point(4, 181);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(193, 23);
            this.btnExaminar.TabIndex = 3;
            this.btnExaminar.Text = "Examinar";
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(3, 207);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(185, 20);
            this.lblError.TabIndex = 4;
            this.lblError.Text = "No se detecto dispositivo";
            // 
            // ucFichaMunicipio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.cmbCamaras);
            this.Controls.Add(this.pBoxFoto);
            this.Name = "ucFichaMunicipio";
            this.Size = new System.Drawing.Size(200, 230);
            this.Load += new System.EventHandler(this.ucFichaMunicipio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pBoxFoto;
        private System.Windows.Forms.ComboBox cmbCamaras;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.Label lblError;
    }
}

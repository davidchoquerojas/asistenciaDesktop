namespace ControlAsistenciaApp.forms
{
    partial class frmCalificarTardanzas
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_desde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_hasta = new System.Windows.Forms.DateTimePicker();
            this.btn_calcular = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_minuto = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desde";
            // 
            // txt_desde
            // 
            this.txt_desde.Location = new System.Drawing.Point(114, 37);
            this.txt_desde.Name = "txt_desde";
            this.txt_desde.Size = new System.Drawing.Size(200, 20);
            this.txt_desde.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(376, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hasta";
            // 
            // txt_hasta
            // 
            this.txt_hasta.Location = new System.Drawing.Point(439, 36);
            this.txt_hasta.Name = "txt_hasta";
            this.txt_hasta.Size = new System.Drawing.Size(200, 20);
            this.txt_hasta.TabIndex = 3;
            // 
            // btn_calcular
            // 
            this.btn_calcular.Location = new System.Drawing.Point(114, 106);
            this.btn_calcular.Name = "btn_calcular";
            this.btn_calcular.Size = new System.Drawing.Size(210, 23);
            this.btn_calcular.TabIndex = 4;
            this.btn_calcular.Text = "Calcular";
            this.btn_calcular.UseVisualStyleBackColor = true;
            this.btn_calcular.Click += new System.EventHandler(this.btn_calcular_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(694, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Minutos de tardanza";
            // 
            // txt_minuto
            // 
            this.txt_minuto.Location = new System.Drawing.Point(818, 37);
            this.txt_minuto.Name = "txt_minuto";
            this.txt_minuto.Size = new System.Drawing.Size(59, 20);
            this.txt_minuto.TabIndex = 6;
            this.txt_minuto.Text = "20";
            // 
            // frmCalificarTardanzas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 437);
            this.Controls.Add(this.txt_minuto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_calcular);
            this.Controls.Add(this.txt_hasta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_desde);
            this.Controls.Add(this.label1);
            this.Name = "frmCalificarTardanzas";
            this.Text = "frmCalificarTardanzas";
            this.Load += new System.EventHandler(this.frmCalificarTardanzas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txt_desde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txt_hasta;
        private System.Windows.Forms.Button btn_calcular;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_minuto;
    }
}
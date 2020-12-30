
namespace CapaPresentacion
{
    partial class RegitrosCP
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
            this.btnGuardarRegistro = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPromedio = new System.Windows.Forms.TextBox();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lstEvaluacion = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEstudiante = new System.Windows.Forms.TextBox();
            this.txtCurso = new System.Windows.Forms.TextBox();
            this.txtProfesor = new System.Windows.Forms.TextBox();
            this.btnBuscarEstudiante = new System.Windows.Forms.Button();
            this.txtIdEstudiante = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBuscarCurso = new System.Windows.Forms.Button();
            this.btnBuscarProfesor = new System.Windows.Forms.Button();
            this.txtIdCurso = new System.Windows.Forms.TextBox();
            this.txtIdProfesor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFTermino = new System.Windows.Forms.DateTimePicker();
            this.dtpFInicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardarRegistro
            // 
            this.btnGuardarRegistro.Location = new System.Drawing.Point(23, 515);
            this.btnGuardarRegistro.Name = "btnGuardarRegistro";
            this.btnGuardarRegistro.Size = new System.Drawing.Size(141, 23);
            this.btnGuardarRegistro.TabIndex = 50;
            this.btnGuardarRegistro.Text = "GUARDAR REGISTRO";
            this.btnGuardarRegistro.UseVisualStyleBackColor = true;
            this.btnGuardarRegistro.Click += new System.EventHandler(this.btnGuardarRegistro_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(808, 521);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 49;
            this.label8.Text = "PROMEDIO FINAL";
            // 
            // txtPromedio
            // 
            this.txtPromedio.Location = new System.Drawing.Point(912, 518);
            this.txtPromedio.Name = "txtPromedio";
            this.txtPromedio.ReadOnly = true;
            this.txtPromedio.Size = new System.Drawing.Size(65, 20);
            this.txtPromedio.TabIndex = 48;
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(23, 163);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(954, 332);
            this.dgvDatos.TabIndex = 47;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(847, 119);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(130, 25);
            this.btnAgregar.TabIndex = 46;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtNota
            // 
            this.txtNota.Location = new System.Drawing.Point(750, 124);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(65, 20);
            this.txtNota.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(747, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "NOTA";
            // 
            // lstEvaluacion
            // 
            this.lstEvaluacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstEvaluacion.FormattingEnabled = true;
            this.lstEvaluacion.Location = new System.Drawing.Point(586, 124);
            this.lstEvaluacion.Name = "lstEvaluacion";
            this.lstEvaluacion.Size = new System.Drawing.Size(138, 21);
            this.lstEvaluacion.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(583, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "EVALUACIÓN";
            // 
            // txtEstudiante
            // 
            this.txtEstudiante.Location = new System.Drawing.Point(274, 125);
            this.txtEstudiante.Name = "txtEstudiante";
            this.txtEstudiante.ReadOnly = true;
            this.txtEstudiante.Size = new System.Drawing.Size(283, 20);
            this.txtEstudiante.TabIndex = 41;
            // 
            // txtCurso
            // 
            this.txtCurso.Location = new System.Drawing.Point(274, 48);
            this.txtCurso.Name = "txtCurso";
            this.txtCurso.ReadOnly = true;
            this.txtCurso.Size = new System.Drawing.Size(274, 20);
            this.txtCurso.TabIndex = 40;
            // 
            // txtProfesor
            // 
            this.txtProfesor.Location = new System.Drawing.Point(274, 18);
            this.txtProfesor.Name = "txtProfesor";
            this.txtProfesor.ReadOnly = true;
            this.txtProfesor.Size = new System.Drawing.Size(274, 20);
            this.txtProfesor.TabIndex = 39;
            // 
            // btnBuscarEstudiante
            // 
            this.btnBuscarEstudiante.Location = new System.Drawing.Point(182, 125);
            this.btnBuscarEstudiante.Name = "btnBuscarEstudiante";
            this.btnBuscarEstudiante.Size = new System.Drawing.Size(75, 20);
            this.btnBuscarEstudiante.TabIndex = 38;
            this.btnBuscarEstudiante.Text = "BUSCAR";
            this.btnBuscarEstudiante.UseVisualStyleBackColor = true;
            this.btnBuscarEstudiante.Click += new System.EventHandler(this.btnBuscarEstudiante_Click);
            // 
            // txtIdEstudiante
            // 
            this.txtIdEstudiante.Location = new System.Drawing.Point(110, 125);
            this.txtIdEstudiante.Name = "txtIdEstudiante";
            this.txtIdEstudiante.Size = new System.Drawing.Size(54, 20);
            this.txtIdEstudiante.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "ESTUDIANTE";
            // 
            // btnBuscarCurso
            // 
            this.btnBuscarCurso.Location = new System.Drawing.Point(182, 48);
            this.btnBuscarCurso.Name = "btnBuscarCurso";
            this.btnBuscarCurso.Size = new System.Drawing.Size(66, 20);
            this.btnBuscarCurso.TabIndex = 35;
            this.btnBuscarCurso.Text = "BUSCAR";
            this.btnBuscarCurso.UseVisualStyleBackColor = true;
            this.btnBuscarCurso.Click += new System.EventHandler(this.btnBuscarCurso_Click);
            // 
            // btnBuscarProfesor
            // 
            this.btnBuscarProfesor.Location = new System.Drawing.Point(182, 18);
            this.btnBuscarProfesor.Name = "btnBuscarProfesor";
            this.btnBuscarProfesor.Size = new System.Drawing.Size(66, 20);
            this.btnBuscarProfesor.TabIndex = 34;
            this.btnBuscarProfesor.Text = "BUSCAR";
            this.btnBuscarProfesor.UseVisualStyleBackColor = true;
            this.btnBuscarProfesor.Click += new System.EventHandler(this.btnBuscarProfesor_Click);
            // 
            // txtIdCurso
            // 
            this.txtIdCurso.Location = new System.Drawing.Point(110, 48);
            this.txtIdCurso.Name = "txtIdCurso";
            this.txtIdCurso.Size = new System.Drawing.Size(45, 20);
            this.txtIdCurso.TabIndex = 33;
            // 
            // txtIdProfesor
            // 
            this.txtIdProfesor.Location = new System.Drawing.Point(110, 18);
            this.txtIdProfesor.Name = "txtIdProfesor";
            this.txtIdProfesor.Size = new System.Drawing.Size(45, 20);
            this.txtIdProfesor.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "CURSO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "PROFESOR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(686, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "FECHA TERMINO";
            // 
            // dtpFTermino
            // 
            this.dtpFTermino.Location = new System.Drawing.Point(786, 48);
            this.dtpFTermino.Name = "dtpFTermino";
            this.dtpFTermino.Size = new System.Drawing.Size(191, 20);
            this.dtpFTermino.TabIndex = 28;
            // 
            // dtpFInicio
            // 
            this.dtpFInicio.Location = new System.Drawing.Point(786, 18);
            this.dtpFInicio.Name = "dtpFInicio";
            this.dtpFInicio.Size = new System.Drawing.Size(191, 20);
            this.dtpFInicio.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(686, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "FECHA INICIO";
            // 
            // RegitrosCP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 617);
            this.Controls.Add(this.btnGuardarRegistro);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPromedio);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtNota);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lstEvaluacion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEstudiante);
            this.Controls.Add(this.txtCurso);
            this.Controls.Add(this.txtProfesor);
            this.Controls.Add(this.btnBuscarEstudiante);
            this.Controls.Add(this.txtIdEstudiante);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnBuscarCurso);
            this.Controls.Add(this.btnBuscarProfesor);
            this.Controls.Add(this.txtIdCurso);
            this.Controls.Add(this.txtIdProfesor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFTermino);
            this.Controls.Add(this.dtpFInicio);
            this.Controls.Add(this.label1);
            this.Name = "RegitrosCP";
            this.Text = "RegitrosCP";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardarRegistro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPromedio;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox lstEvaluacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEstudiante;
        private System.Windows.Forms.TextBox txtCurso;
        private System.Windows.Forms.TextBox txtProfesor;
        private System.Windows.Forms.Button btnBuscarEstudiante;
        private System.Windows.Forms.TextBox txtIdEstudiante;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBuscarCurso;
        private System.Windows.Forms.Button btnBuscarProfesor;
        private System.Windows.Forms.TextBox txtIdCurso;
        private System.Windows.Forms.TextBox txtIdProfesor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFTermino;
        private System.Windows.Forms.DateTimePicker dtpFInicio;
        private System.Windows.Forms.Label label1;
    }
}
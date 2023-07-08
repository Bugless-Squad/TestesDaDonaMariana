namespace TestesDaDonaMariana.WinApp.ModuloTeste
{
    partial class TelaVisualizacaoTesteForm
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
            btnGravar = new Button();
            cmbSerie = new ComboBox();
            txtTitulo = new TextBox();
            txtId = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            comboBox1 = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnGravar
            // 
            btnGravar.Location = new Point(586, 416);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(101, 34);
            btnGravar.TabIndex = 10;
            btnGravar.Text = "Fechar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // cmbSerie
            // 
            cmbSerie.FormattingEnabled = true;
            cmbSerie.Location = new Point(123, 120);
            cmbSerie.Name = "cmbSerie";
            cmbSerie.Size = new Size(564, 23);
            cmbSerie.TabIndex = 7;
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(123, 78);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(564, 23);
            txtTitulo.TabIndex = 5;
            // 
            // txtId
            // 
            txtId.Location = new Point(123, 39);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.Location = new Point(50, 81);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 1;
            label2.Text = "Titulo:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(79, 42);
            label1.Name = "label1";
            label1.Size = new Size(27, 20);
            label1.TabIndex = 0;
            label1.Text = "Id:";
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnGravar);
            panel1.Controls.Add(cmbSerie);
            panel1.Controls.Add(txtTitulo);
            panel1.Controls.Add(txtId);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(31, 18);
            panel1.Name = "panel1";
            panel1.Size = new Size(738, 473);
            panel1.TabIndex = 19;
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(123, 209);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(564, 185);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "Questões";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(123, 160);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(564, 23);
            comboBox1.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.Location = new Point(21, 163);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 15;
            label3.Text = "Materia:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.Location = new Point(21, 120);
            label4.Name = "label4";
            label4.Size = new Size(85, 20);
            label4.TabIndex = 3;
            label4.Text = "Disciplina:";
            // 
            // TelaVisualizacaoTesteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 552);
            Controls.Add(panel1);
            Name = "TelaVisualizacaoTesteForm";
            ShowIcon = false;
            Text = "   Testes Dona Mariana";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnGravar;
        private ComboBox cmbSerie;
        private TextBox txtTitulo;
        private TextBox txtId;
        private Label label2;
        private Label label1;
        private Panel panel1;
        private GroupBox groupBox1;
        private ComboBox comboBox1;
        private Label label3;
        private Label label4;
    }
}
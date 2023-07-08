namespace TestesDaDonaMariana.WinApp.ModuloTeste
{
    partial class TelaTesteForm
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
            txtId = new TextBox();
            label8 = new Label();
            txtTitulo = new TextBox();
            label2 = new Label();
            cmbDisciplina = new ComboBox();
            label1 = new Label();
            cmbMaterias = new ComboBox();
            label7 = new Label();
            panelAlternativas = new Panel();
            btnCancelar = new Button();
            btnGravar = new Button();
            btnGerarTeste = new Button();
            numericUpDown1 = new NumericUpDown();
            label3 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // txtId
            // 
            txtId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtId.Location = new Point(175, 22);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(194, 29);
            txtId.TabIndex = 76;
            txtId.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(143, 25);
            label8.Name = "label8";
            label8.Size = new Size(26, 21);
            label8.TabIndex = 75;
            label8.Text = "Id:";
            // 
            // txtTitulo
            // 
            txtTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtTitulo.Location = new Point(175, 57);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(467, 29);
            txtTitulo.TabIndex = 78;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(117, 57);
            label2.Name = "label2";
            label2.Size = new Size(52, 21);
            label2.TabIndex = 77;
            label2.Text = "Título:";
            // 
            // cmbDisciplina
            // 
            cmbDisciplina.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDisciplina.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbDisciplina.FormattingEnabled = true;
            cmbDisciplina.Location = new Point(175, 92);
            cmbDisciplina.Name = "cmbDisciplina";
            cmbDisciplina.Size = new Size(467, 29);
            cmbDisciplina.TabIndex = 87;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(89, 92);
            label1.Name = "label1";
            label1.Size = new Size(80, 21);
            label1.TabIndex = 86;
            label1.Text = "Disciplina:";
            // 
            // cmbMaterias
            // 
            cmbMaterias.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaterias.Enabled = false;
            cmbMaterias.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbMaterias.FormattingEnabled = true;
            cmbMaterias.Location = new Point(175, 126);
            cmbMaterias.Name = "cmbMaterias";
            cmbMaterias.Size = new Size(467, 29);
            cmbMaterias.TabIndex = 89;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(103, 126);
            label7.Name = "label7";
            label7.Size = new Size(66, 21);
            label7.TabIndex = 88;
            label7.Text = "Matéria:";
            // 
            // panelAlternativas
            // 
            panelAlternativas.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            panelAlternativas.Location = new Point(175, 195);
            panelAlternativas.Name = "panelAlternativas";
            panelAlternativas.Size = new Size(467, 309);
            panelAlternativas.TabIndex = 90;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancelar.ImageAlign = ContentAlignment.BottomRight;
            btnCancelar.Location = new Point(548, 577);
            btnCancelar.Margin = new Padding(4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 40);
            btnCancelar.TabIndex = 92;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.TextAboveImage;
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnGravar.ImageAlign = ContentAlignment.BottomRight;
            btnGravar.Location = new Point(448, 577);
            btnGravar.Margin = new Padding(4);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(94, 40);
            btnGravar.TabIndex = 91;
            btnGravar.Text = "Gravar";
            btnGravar.TextImageRelation = TextImageRelation.TextAboveImage;
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // btnGerarTeste
            // 
            btnGerarTeste.Enabled = false;
            btnGerarTeste.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnGerarTeste.Location = new Point(448, 510);
            btnGerarTeste.Name = "btnGerarTeste";
            btnGerarTeste.Size = new Size(194, 40);
            btnGerarTeste.TabIndex = 93;
            btnGerarTeste.Text = "Gerar Teste";
            btnGerarTeste.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDown1.Location = new Point(175, 160);
            numericUpDown1.Maximum = new decimal(new int[] { 25, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(194, 29);
            numericUpDown1.TabIndex = 94;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(8, 160);
            label3.Name = "label3";
            label3.Size = new Size(161, 21);
            label3.TabIndex = 95;
            label3.Text = "Número de Questões:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(30, 195);
            label5.Name = "label5";
            label5.Size = new Size(139, 21);
            label5.TabIndex = 96;
            label5.Text = "Questões Geradas:";
            // 
            // TelaTesteForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(676, 644);
            Controls.Add(label5);
            Controls.Add(numericUpDown1);
            Controls.Add(label3);
            Controls.Add(btnGerarTeste);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(panelAlternativas);
            Controls.Add(cmbMaterias);
            Controls.Add(label7);
            Controls.Add(cmbDisciplina);
            Controls.Add(label1);
            Controls.Add(txtTitulo);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label8);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "TelaTesteForm";
            Text = "TelaTesteForm";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtId;
        private Label label8;
        private TextBox txtTitulo;
        private Label label2;
        private ComboBox cmbDisciplina;
        private Label label1;
        private ComboBox cmbMaterias;
        private Label label7;
        private Panel panelAlternativas;
        private Button btnCancelar;
        private Button btnGravar;
        private Button btnGerarTeste;
        private NumericUpDown numericUpDown1;
        private Label label3;
        private Label label5;
    }
}
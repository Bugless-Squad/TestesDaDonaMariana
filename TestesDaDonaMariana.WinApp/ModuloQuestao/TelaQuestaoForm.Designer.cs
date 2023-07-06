namespace TestesDaDonaMariana.WinApp.ModuloQuestao
{
    partial class TelaQuestaoForm
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
            cmbMaterias = new ComboBox();
            txtId = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label4 = new Label();
            txtEnunciado = new TextBox();
            panelItensTema = new Panel();
            btnCancelar = new Button();
            btnGravar = new Button();
            label1 = new Label();
            btnAdicionar = new Button();
            txtNumero = new TextBox();
            cmbDisciplina = new ComboBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // cmbMaterias
            // 
            cmbMaterias.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaterias.Enabled = false;
            cmbMaterias.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbMaterias.FormattingEnabled = true;
            cmbMaterias.Location = new Point(112, 84);
            cmbMaterias.Name = "cmbMaterias";
            cmbMaterias.Size = new Size(395, 28);
            cmbMaterias.TabIndex = 75;
            // 
            // txtId
            // 
            txtId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtId.Location = new Point(112, 15);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(183, 29);
            txtId.TabIndex = 74;
            txtId.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(80, 18);
            label8.Name = "label8";
            label8.Size = new Size(26, 21);
            label8.TabIndex = 73;
            label8.Text = "Id:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(40, 84);
            label7.Name = "label7";
            label7.Size = new Size(66, 21);
            label7.TabIndex = 72;
            label7.Text = "Matéria:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(21, 118);
            label4.Name = "label4";
            label4.Size = new Size(85, 21);
            label4.TabIndex = 77;
            label4.Text = "Enunciado:";
            // 
            // txtEnunciado
            // 
            txtEnunciado.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtEnunciado.Location = new Point(112, 118);
            txtEnunciado.MaxLength = 5000000;
            txtEnunciado.Multiline = true;
            txtEnunciado.Name = "txtEnunciado";
            txtEnunciado.ScrollBars = ScrollBars.Horizontal;
            txtEnunciado.Size = new Size(395, 171);
            txtEnunciado.TabIndex = 76;
            // 
            // panelItensTema
            // 
            panelItensTema.Location = new Point(112, 330);
            panelItensTema.Name = "panelItensTema";
            panelItensTema.Size = new Size(395, 153);
            panelItensTema.TabIndex = 78;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancelar.ImageAlign = ContentAlignment.BottomRight;
            btnCancelar.Location = new Point(413, 490);
            btnCancelar.Margin = new Padding(4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 41);
            btnCancelar.TabIndex = 80;
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
            btnGravar.Location = new Point(313, 490);
            btnGravar.Margin = new Padding(4);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(94, 41);
            btnGravar.TabIndex = 79;
            btnGravar.Text = "Gravar";
            btnGravar.TextImageRelation = TextImageRelation.TextAboveImage;
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(10, 295);
            label1.Name = "label1";
            label1.Size = new Size(96, 20);
            label1.TabIndex = 82;
            label1.Text = "Alternativas:";
            // 
            // btnAdicionar
            // 
            btnAdicionar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdicionar.Location = new Point(413, 295);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(94, 29);
            btnAdicionar.TabIndex = 81;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            // 
            // txtNumero
            // 
            txtNumero.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNumero.Location = new Point(112, 295);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(295, 29);
            txtNumero.TabIndex = 83;
            // 
            // cmbDisciplina
            // 
            cmbDisciplina.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDisciplina.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbDisciplina.FormattingEnabled = true;
            cmbDisciplina.Location = new Point(112, 50);
            cmbDisciplina.Name = "cmbDisciplina";
            cmbDisciplina.Size = new Size(395, 28);
            cmbDisciplina.TabIndex = 85;
            cmbDisciplina.SelectedIndexChanged += cmbDisciplina_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(26, 50);
            label2.Name = "label2";
            label2.Size = new Size(80, 21);
            label2.TabIndex = 84;
            label2.Text = "Disciplina:";
            // 
            // TelaQuestaoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(537, 559);
            Controls.Add(cmbDisciplina);
            Controls.Add(label2);
            Controls.Add(txtNumero);
            Controls.Add(label1);
            Controls.Add(btnAdicionar);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(panelItensTema);
            Controls.Add(label4);
            Controls.Add(txtEnunciado);
            Controls.Add(cmbMaterias);
            Controls.Add(txtId);
            Controls.Add(label8);
            Controls.Add(label7);
            Name = "TelaQuestaoForm";
            Text = "TelaQuestaoForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbMaterias;
        private TextBox txtId;
        private Label label8;
        private Label label7;
        private Label label4;
        private TextBox txtEnunciado;
        private Panel panelItensTema;
        private Button btnCancelar;
        private Button btnGravar;
        private Label label1;
        private Button btnAdicionar;
        private TextBox txtNumero;
        private ComboBox cmbDisciplina;
        private Label label2;
    }
}
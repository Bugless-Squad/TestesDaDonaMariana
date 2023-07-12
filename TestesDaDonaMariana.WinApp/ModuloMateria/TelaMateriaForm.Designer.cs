namespace TestesDaDonaMariana.WinApp.ModuloMateria
{
    partial class TelaMateriaForm
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
            txtTitulo = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtId = new TextBox();
            label5 = new Label();
            cmbDisciplina = new ComboBox();
            cmbSerie = new ComboBox();
            btnCancelar = new Button();
            btnGravar = new Button();
            SuspendLayout();
            // 
            // txtTitulo
            // 
            txtTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtTitulo.Location = new Point(107, 80);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(592, 29);
            txtTitulo.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(412, 127);
            label4.Name = "label4";
            label4.Size = new Size(48, 21);
            label4.TabIndex = 11;
            label4.Text = "Serie:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(21, 127);
            label3.Name = "label3";
            label3.Size = new Size(80, 21);
            label3.TabIndex = 10;
            label3.Text = "Disciplina:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(49, 80);
            label2.Name = "label2";
            label2.Size = new Size(52, 21);
            label2.TabIndex = 9;
            label2.Text = "Titulo:";
            // 
            // txtId
            // 
            txtId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtId.Location = new Point(107, 34);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(233, 29);
            txtId.TabIndex = 34;
            txtId.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(64, 34);
            label5.Name = "label5";
            label5.Size = new Size(26, 21);
            label5.TabIndex = 33;
            label5.Text = "Id:";
            // 
            // cmbDisciplina
            // 
            cmbDisciplina.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDisciplina.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbDisciplina.FormattingEnabled = true;
            cmbDisciplina.Location = new Point(107, 127);
            cmbDisciplina.Name = "cmbDisciplina";
            cmbDisciplina.Size = new Size(233, 28);
            cmbDisciplina.TabIndex = 73;
            // 
            // cmbSerie
            // 
            cmbSerie.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSerie.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbSerie.FormattingEnabled = true;
            cmbSerie.Location = new Point(466, 127);
            cmbSerie.Name = "cmbSerie";
            cmbSerie.Size = new Size(233, 28);
            cmbSerie.TabIndex = 74;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancelar.ImageAlign = ContentAlignment.BottomRight;
            btnCancelar.Location = new Point(591, 194);
            btnCancelar.Margin = new Padding(4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(108, 42);
            btnCancelar.TabIndex = 76;
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
            btnGravar.Location = new Point(466, 194);
            btnGravar.Margin = new Padding(4);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(105, 42);
            btnGravar.TabIndex = 75;
            btnGravar.Text = "Gravar";
            btnGravar.TextImageRelation = TextImageRelation.TextAboveImage;
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // TelaMateriaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(738, 269);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(cmbSerie);
            Controls.Add(cmbDisciplina);
            Controls.Add(txtId);
            Controls.Add(label5);
            Controls.Add(txtTitulo);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "TelaMateriaForm";
            ShowIcon = false;
            Text = "Cadastro Matéria";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitulo;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtId;
        private Label label5;
        private ComboBox cmbDisciplina;
        private ComboBox cmbSerie;
        private Button btnCancelar;
        private Button btnGravar;
    }
}
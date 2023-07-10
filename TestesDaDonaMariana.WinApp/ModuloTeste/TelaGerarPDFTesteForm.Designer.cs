namespace TestesDaDonaMariana.WinApp.ModuloTeste
{
    partial class TelaGerarPdfTesteForm
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
            label2 = new Label();
            cbxGabarito = new CheckBox();
            cbxTeste = new CheckBox();
            txtLocalizacao = new TextBox();
            label1 = new Label();
            btnCancelar = new Button();
            btnGerarPDF = new Button();
            btnLocalizar = new Button();
            SuspendLayout();
            // 
            // txtTitulo
            // 
            txtTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtTitulo.Location = new Point(184, 19);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.ReadOnly = true;
            txtTitulo.Size = new Size(344, 29);
            txtTitulo.TabIndex = 84;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(67, 19);
            label2.Name = "label2";
            label2.Size = new Size(111, 21);
            label2.TabIndex = 83;
            label2.Text = "Título do teste:";
            // 
            // cbxGabarito
            // 
            cbxGabarito.AutoSize = true;
            cbxGabarito.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbxGabarito.Location = new Point(184, 146);
            cbxGabarito.Name = "cbxGabarito";
            cbxGabarito.Size = new Size(89, 25);
            cbxGabarito.TabIndex = 82;
            cbxGabarito.Text = "Gabarito";
            cbxGabarito.UseVisualStyleBackColor = true;
            // 
            // cbxTeste
            // 
            cbxTeste.AutoSize = true;
            cbxTeste.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbxTeste.Location = new Point(184, 109);
            cbxTeste.Name = "cbxTeste";
            cbxTeste.Size = new Size(63, 25);
            cbxTeste.TabIndex = 81;
            cbxTeste.Text = "Teste";
            cbxTeste.UseVisualStyleBackColor = true;
            // 
            // txtLocalizacao
            // 
            txtLocalizacao.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtLocalizacao.Location = new Point(184, 65);
            txtLocalizacao.Name = "txtLocalizacao";
            txtLocalizacao.Size = new Size(228, 29);
            txtLocalizacao.TabIndex = 86;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(24, 65);
            label1.Name = "label1";
            label1.Size = new Size(154, 21);
            label1.TabIndex = 85;
            label1.Text = "Diretório do arquivo:";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancelar.ImageAlign = ContentAlignment.BottomRight;
            btnCancelar.Location = new Point(425, 196);
            btnCancelar.Margin = new Padding(4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(103, 34);
            btnCancelar.TabIndex = 94;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.TextAboveImage;
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGerarPDF
            // 
            btnGerarPDF.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGerarPDF.DialogResult = DialogResult.OK;
            btnGerarPDF.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnGerarPDF.ImageAlign = ContentAlignment.BottomRight;
            btnGerarPDF.Location = new Point(309, 196);
            btnGerarPDF.Margin = new Padding(4);
            btnGerarPDF.Name = "btnGerarPDF";
            btnGerarPDF.Size = new Size(103, 34);
            btnGerarPDF.TabIndex = 93;
            btnGerarPDF.Text = "Gerar PDF";
            btnGerarPDF.TextImageRelation = TextImageRelation.TextAboveImage;
            btnGerarPDF.UseVisualStyleBackColor = true;
            btnGerarPDF.Click += btnGerarPDF_Click;
            // 
            // btnLocalizar
            // 
            btnLocalizar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLocalizar.DialogResult = DialogResult.Cancel;
            btnLocalizar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnLocalizar.ImageAlign = ContentAlignment.BottomRight;
            btnLocalizar.Location = new Point(425, 65);
            btnLocalizar.Margin = new Padding(4);
            btnLocalizar.Name = "btnLocalizar";
            btnLocalizar.Size = new Size(103, 29);
            btnLocalizar.TabIndex = 95;
            btnLocalizar.Text = "Localizar";
            btnLocalizar.TextImageRelation = TextImageRelation.TextAboveImage;
            btnLocalizar.UseVisualStyleBackColor = true;
            btnLocalizar.Click += btnLocalizar_Click;
            // 
            // TelaGerarPdfTesteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(561, 263);
            Controls.Add(btnLocalizar);
            Controls.Add(btnCancelar);
            Controls.Add(btnGerarPDF);
            Controls.Add(txtLocalizacao);
            Controls.Add(label1);
            Controls.Add(txtTitulo);
            Controls.Add(label2);
            Controls.Add(cbxGabarito);
            Controls.Add(cbxTeste);
            Name = "TelaGerarPdfTesteForm";
            Text = "TelaGerarPdfTesteForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitulo;
        private Label label2;
        private CheckBox cbxGabarito;
        private CheckBox cbxTeste;
        private TextBox txtLocalizacao;
        private Label label1;
        private Button btnCancelar;
        private Button btnGerarPDF;
        private Button btnLocalizar;
    }
}
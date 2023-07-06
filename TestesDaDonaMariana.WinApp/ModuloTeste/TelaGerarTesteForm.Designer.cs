namespace TestesDaDonaMariana.WinApp.ModuloTeste
{
    partial class TelaGerarTesteForm
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
            groupBox1 = new GroupBox();
            btnGravar = new Button();
            btnCancelar = new Button();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBox2);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(btnGravar);
            groupBox1.Controls.Add(btnCancelar);
            groupBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(50, 39);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(417, 248);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Gerar PDF";
            // 
            // btnGravar
            // 
            btnGravar.Location = new Point(196, 188);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(101, 34);
            btnGravar.TabIndex = 12;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(303, 188);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(87, 34);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox1.Location = new Point(51, 42);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(59, 21);
            checkBox1.TabIndex = 13;
            checkBox1.Text = "Teste";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox2.Location = new Point(51, 79);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(80, 21);
            checkBox2.TabIndex = 14;
            checkBox2.Text = "Gabarito";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // TelaGerarTesteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 323);
            Controls.Add(groupBox1);
            Name = "TelaGerarTesteForm";
            ShowIcon = false;
            Text = "   Testes Dona Mariana";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Button btnGravar;
        private Button btnCancelar;
    }
}
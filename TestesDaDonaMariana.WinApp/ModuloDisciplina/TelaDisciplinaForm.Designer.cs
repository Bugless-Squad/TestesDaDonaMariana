namespace TestesDaDonaMariana.WinApp.ModuloDisciplina
{
    partial class TelaDisciplinaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaDisciplinaForm));
            menuStrip1 = new MenuStrip();
            DisciplinasMenuItem = new ToolStripMenuItem();
            materiasMenuItem = new ToolStripMenuItem();
            questoesMenuItem = new ToolStripMenuItem();
            testesMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            btnHome = new ToolStripButton();
            toolStripSeparator0 = new ToolStripSeparator();
            btnConfigDesconto = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnInserir = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnExcluir = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnAdicionarItens = new ToolStripButton();
            btnRemoverItens = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            btnFinalizarPgto = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            btnVisualizar = new ToolStripButton();
            btnFiltrar = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            labelTipoDoCadastro = new ToolStripLabel();
            rodape = new StatusStrip();
            lableRodape = new ToolStripStatusLabel();
            panel1 = new Panel();
            btnGravar = new Button();
            btnCancelar = new Button();
            txtTitulo = new TextBox();
            txtId = new TextBox();
            label2 = new Label();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            rodape.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { DisciplinasMenuItem, materiasMenuItem, questoesMenuItem, testesMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(8, 3, 0, 3);
            menuStrip1.Size = new Size(800, 25);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // DisciplinasMenuItem
            // 
            DisciplinasMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            DisciplinasMenuItem.Name = "DisciplinasMenuItem";
            DisciplinasMenuItem.Size = new Size(75, 19);
            DisciplinasMenuItem.Text = "Disciplinas";
            // 
            // materiasMenuItem
            // 
            materiasMenuItem.Name = "materiasMenuItem";
            materiasMenuItem.Size = new Size(64, 19);
            materiasMenuItem.Text = "Matérias";
            // 
            // questoesMenuItem
            // 
            questoesMenuItem.Name = "questoesMenuItem";
            questoesMenuItem.Size = new Size(68, 19);
            questoesMenuItem.Text = "Questões";
            // 
            // testesMenuItem
            // 
            testesMenuItem.Name = "testesMenuItem";
            testesMenuItem.Size = new Size(50, 19);
            testesMenuItem.Text = "Testes";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnHome, toolStripSeparator0, btnConfigDesconto, toolStripSeparator1, btnInserir, btnEditar, btnExcluir, toolStripSeparator2, btnAdicionarItens, btnRemoverItens, toolStripSeparator3, btnFinalizarPgto, toolStripSeparator4, btnVisualizar, btnFiltrar, toolStripSeparator5, labelTipoDoCadastro });
            toolStrip1.Location = new Point(0, 25);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 7;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnHome
            // 
            btnHome.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnHome.Enabled = false;
            btnHome.Image = (Image)resources.GetObject("btnHome.Image");
            btnHome.ImageTransparentColor = Color.Magenta;
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(6);
            btnHome.Size = new Size(32, 32);
            btnHome.Text = "Home";
            btnHome.ToolTipText = "Botão Home indisponível.";
            btnHome.Visible = false;
            // 
            // toolStripSeparator0
            // 
            toolStripSeparator0.Name = "toolStripSeparator0";
            toolStripSeparator0.Size = new Size(6, 35);
            toolStripSeparator0.Visible = false;
            // 
            // btnConfigDesconto
            // 
            btnConfigDesconto.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnConfigDesconto.Enabled = false;
            btnConfigDesconto.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnConfigDesconto.Image = (Image)resources.GetObject("btnConfigDesconto.Image");
            btnConfigDesconto.ImageTransparentColor = Color.Magenta;
            btnConfigDesconto.Name = "btnConfigDesconto";
            btnConfigDesconto.Padding = new Padding(6);
            btnConfigDesconto.Size = new Size(32, 32);
            btnConfigDesconto.Visible = false;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 35);
            toolStripSeparator1.Visible = false;
            // 
            // btnInserir
            // 
            btnInserir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnInserir.Enabled = false;
            btnInserir.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnInserir.Image = (Image)resources.GetObject("btnInserir.Image");
            btnInserir.ImageTransparentColor = Color.Magenta;
            btnInserir.Name = "btnInserir";
            btnInserir.Padding = new Padding(6);
            btnInserir.Size = new Size(32, 32);
            btnInserir.Text = "Inserir";
            btnInserir.Visible = false;
            // 
            // btnEditar
            // 
            btnEditar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEditar.Enabled = false;
            btnEditar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditar.Image = (Image)resources.GetObject("btnEditar.Image");
            btnEditar.ImageTransparentColor = Color.Magenta;
            btnEditar.Name = "btnEditar";
            btnEditar.Padding = new Padding(6);
            btnEditar.Size = new Size(32, 32);
            btnEditar.Text = "Editar";
            btnEditar.Visible = false;
            // 
            // btnExcluir
            // 
            btnExcluir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnExcluir.Enabled = false;
            btnExcluir.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnExcluir.Image = (Image)resources.GetObject("btnExcluir.Image");
            btnExcluir.ImageTransparentColor = Color.Magenta;
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Padding = new Padding(6);
            btnExcluir.Size = new Size(32, 32);
            btnExcluir.Text = "Excluir";
            btnExcluir.Visible = false;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 35);
            toolStripSeparator2.Visible = false;
            // 
            // btnAdicionarItens
            // 
            btnAdicionarItens.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnAdicionarItens.Enabled = false;
            btnAdicionarItens.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdicionarItens.Image = (Image)resources.GetObject("btnAdicionarItens.Image");
            btnAdicionarItens.ImageTransparentColor = Color.Magenta;
            btnAdicionarItens.Name = "btnAdicionarItens";
            btnAdicionarItens.Padding = new Padding(6);
            btnAdicionarItens.Size = new Size(32, 32);
            btnAdicionarItens.Visible = false;
            // 
            // btnRemoverItens
            // 
            btnRemoverItens.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnRemoverItens.Enabled = false;
            btnRemoverItens.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnRemoverItens.Image = (Image)resources.GetObject("btnRemoverItens.Image");
            btnRemoverItens.ImageTransparentColor = Color.Magenta;
            btnRemoverItens.Name = "btnRemoverItens";
            btnRemoverItens.Padding = new Padding(6);
            btnRemoverItens.Size = new Size(32, 32);
            btnRemoverItens.Visible = false;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 35);
            toolStripSeparator3.Visible = false;
            // 
            // btnFinalizarPgto
            // 
            btnFinalizarPgto.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnFinalizarPgto.Enabled = false;
            btnFinalizarPgto.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnFinalizarPgto.Image = (Image)resources.GetObject("btnFinalizarPgto.Image");
            btnFinalizarPgto.ImageTransparentColor = Color.Magenta;
            btnFinalizarPgto.Name = "btnFinalizarPgto";
            btnFinalizarPgto.Padding = new Padding(6);
            btnFinalizarPgto.Size = new Size(32, 32);
            btnFinalizarPgto.Visible = false;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 35);
            toolStripSeparator4.Visible = false;
            // 
            // btnVisualizar
            // 
            btnVisualizar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnVisualizar.Enabled = false;
            btnVisualizar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnVisualizar.Image = (Image)resources.GetObject("btnVisualizar.Image");
            btnVisualizar.ImageTransparentColor = Color.Magenta;
            btnVisualizar.Name = "btnVisualizar";
            btnVisualizar.Padding = new Padding(6);
            btnVisualizar.Size = new Size(32, 32);
            btnVisualizar.Text = "Visualizar";
            btnVisualizar.Visible = false;
            // 
            // btnFiltrar
            // 
            btnFiltrar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnFiltrar.Enabled = false;
            btnFiltrar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnFiltrar.Image = (Image)resources.GetObject("btnFiltrar.Image");
            btnFiltrar.ImageTransparentColor = Color.Magenta;
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Padding = new Padding(6);
            btnFiltrar.Size = new Size(32, 32);
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.Visible = false;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 25);
            toolStripSeparator5.Visible = false;
            // 
            // labelTipoDoCadastro
            // 
            labelTipoDoCadastro.Name = "labelTipoDoCadastro";
            labelTipoDoCadastro.Size = new Size(76, 22);
            labelTipoDoCadastro.Text = "                       ";
            // 
            // rodape
            // 
            rodape.Items.AddRange(new ToolStripItem[] { lableRodape });
            rodape.Location = new Point(0, 424);
            rodape.Name = "rodape";
            rodape.Padding = new Padding(1, 0, 18, 0);
            rodape.Size = new Size(800, 26);
            rodape.TabIndex = 10;
            rodape.Text = "statusStrip1";
            // 
            // lableRodape
            // 
            lableRodape.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lableRodape.Name = "lableRodape";
            lableRodape.Size = new Size(50, 21);
            lableRodape.Text = "          ";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnGravar);
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(txtTitulo);
            panel1.Controls.Add(txtId);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(97, 92);
            panel1.Name = "panel1";
            panel1.Size = new Size(607, 266);
            panel1.TabIndex = 19;
            // 
            // btnGravar
            // 
            btnGravar.Location = new Point(336, 190);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(101, 34);
            btnGravar.TabIndex = 10;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(447, 190);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(87, 34);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(123, 78);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(411, 23);
            txtTitulo.TabIndex = 5;
            // 
            // txtId
            // 
            txtId.Location = new Point(123, 39);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.Location = new Point(32, 81);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 1;
            label2.Text = "Disciplina:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(90, 42);
            label1.Name = "label1";
            label1.Size = new Size(27, 20);
            label1.TabIndex = 0;
            label1.Text = "Id:";
            // 
            // TelaTesteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(rodape);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            Name = "TelaTesteForm";
            ShowIcon = false;
            Text = "   Testes Dona Mariana";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            rodape.ResumeLayout(false);
            rodape.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem DisciplinasMenuItem;
        private ToolStripMenuItem materiasMenuItem;
        private ToolStripMenuItem questoesMenuItem;
        private ToolStripMenuItem testesMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripButton btnHome;
        private ToolStripSeparator toolStripSeparator0;
        private ToolStripButton btnConfigDesconto;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnInserir;
        private ToolStripButton btnEditar;
        private ToolStripButton btnExcluir;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnAdicionarItens;
        private ToolStripButton btnRemoverItens;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton btnFinalizarPgto;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton btnVisualizar;
        private ToolStripButton btnFiltrar;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripLabel labelTipoDoCadastro;
        private StatusStrip rodape;
        private ToolStripStatusLabel lableRodape;
        private Panel panel1;
        private Button btnGravar;
        private Button btnCancelar;
        private TextBox txtTitulo;
        private TextBox txtId;
        private Label label2;
        private Label label1;
    }
}
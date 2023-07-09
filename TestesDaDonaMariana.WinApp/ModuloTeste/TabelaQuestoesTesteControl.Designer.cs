namespace TestesDaDonaMariana.WinApp.ModuloTeste
{
    partial class TabelaQuestoesTesteControl
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
            gridQuestoesTeste = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridQuestoesTeste).BeginInit();
            SuspendLayout();
            // 
            // gridQuestoesTeste
            // 
            gridQuestoesTeste.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridQuestoesTeste.Dock = DockStyle.Fill;
            gridQuestoesTeste.Location = new Point(0, 0);
            gridQuestoesTeste.Name = "gridQuestoesTeste";
            gridQuestoesTeste.RowTemplate.Height = 25;
            gridQuestoesTeste.Size = new Size(467, 344);
            gridQuestoesTeste.TabIndex = 1;
            // 
            // TabelaQuestoesTesteControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridQuestoesTeste);
            Margin = new Padding(0);
            MaximumSize = new Size(467, 344);
            MinimumSize = new Size(467, 344);
            Name = "TabelaQuestoesTesteControl";
            Size = new Size(467, 344);
            ((System.ComponentModel.ISupportInitialize)gridQuestoesTeste).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridQuestoesTeste;
    }
}

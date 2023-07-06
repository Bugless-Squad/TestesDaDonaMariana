namespace TestesDaDonaMariana.WinApp.ModuloQuestao
{
    partial class TabelaAlternativasControl
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
            gridAlternativas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridAlternativas).BeginInit();
            SuspendLayout();
            // 
            // gridAlternativas
            // 
            gridAlternativas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridAlternativas.Dock = DockStyle.Fill;
            gridAlternativas.Location = new Point(0, 0);
            gridAlternativas.Name = "gridAlternativas";
            gridAlternativas.RowTemplate.Height = 25;
            gridAlternativas.Size = new Size(849, 596);
            gridAlternativas.TabIndex = 1;
            // 
            // TabelaAlternativasControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridAlternativas);
            Name = "TabelaAlternativasControl";
            Size = new Size(849, 596);
            ((System.ComponentModel.ISupportInitialize)gridAlternativas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridAlternativas;
    }
}

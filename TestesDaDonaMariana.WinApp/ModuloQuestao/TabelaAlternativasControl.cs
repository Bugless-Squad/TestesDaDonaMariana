using TestesDaDonaMariana.Dominio.ModuloQuestao;

namespace TestesDaDonaMariana.WinApp.ModuloQuestao
{
    public partial class TabelaAlternativasControl : UserControl
    {
        public TabelaAlternativasControl()
        {
            InitializeComponent();
            gridAlternativas.ConfigurarGridZebrado();
            gridAlternativas.ConfigurarGridSomenteLeitura();
            gridAlternativas.Columns.AddRange(ObterColunas());

            TelaPrincipalForm.Tela.AtualizarRodape("");
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Alternativa", HeaderText = "Alternativa"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Texto", HeaderText = "Texto"},

                new DataGridViewTextBoxColumn { DataPropertyName = "", HeaderText = ""}
            };

            return colunas;
        }

        public int ObterNumeroAlternativaSelecionada()
        {
            return gridAlternativas.SelecionarLetra<int>();
        }

        public void AtualizarRegistros(List<Alternativa> alternativas)
        {
            gridAlternativas.Rows.Clear();

            foreach (var alternativa in alternativas)
            {
                gridAlternativas.Rows.Add(alternativa.idLetra, alternativa.texto, alternativa.alternativaCorreta);
            }
        }
    }
}

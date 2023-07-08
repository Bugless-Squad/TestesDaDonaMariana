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
                new DataGridViewTextBoxColumn { DataPropertyName = "Número da Alternativa", HeaderText = "Número da Alternativa"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Texto", HeaderText = "Texto"},

                new DataGridViewTextBoxColumn { DataPropertyName = "", HeaderText = ""}
            };

            return colunas;
        }

        public int ObterNumeroItemSelecionado()
        {
            return gridAlternativas.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Alternativa> alternativas)
        {
            gridAlternativas.Rows.Clear();

            foreach (var alternativa in alternativas)
            {
                gridAlternativas.Rows.Add(alternativa.id, alternativa.texto, alternativa.alternativaCorreta);
            }
        }
    }
}

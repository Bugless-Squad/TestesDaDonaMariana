using TestesDaDonaMariana.Dominio.ModuloQuestao;

namespace TestesDaDonaMariana.WinApp.ModuloTeste
{
    public partial class TabelaQuestoesTesteControl : UserControl
    {
        public TabelaQuestoesTesteControl()
        {
            InitializeComponent();
            gridQuestoesTeste.ConfigurarGridZebrado();
            gridQuestoesTeste.ConfigurarGridSomenteLeitura();
            gridQuestoesTeste.Columns.AddRange(ObterColunas());

            TelaPrincipalForm.Tela.AtualizarRodape("");
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Enunciado", HeaderText = "Enunciado"}
            };

            return colunas;
        }

        public int ObterNumeroItemSelecionado()
        {
            return gridQuestoesTeste.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Questao> questoes)
        {
            gridQuestoesTeste.Rows.Clear();

            foreach (var questao in questoes)
            {
                gridQuestoesTeste.Rows.Add(questao.id, questao.enunciado);
            }
        }
    }
}

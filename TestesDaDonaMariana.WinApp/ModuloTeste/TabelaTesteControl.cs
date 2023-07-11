using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Dominio.ModuloTeste;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TestesDaDonaMariana.WinApp.ModuloTeste
{
    public partial class TabelaTesteControl : UserControl
    {
        public TabelaTesteControl()
        {
            InitializeComponent();

            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());

            TelaPrincipalForm.Tela.AtualizarRodape("");
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Título", HeaderText = "Título"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Disciplina", HeaderText = "Disciplina"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Matéria", HeaderText = "Matéria"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Quantidade de Questões", HeaderText = "Quantidade de Questões"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Data de Criação", HeaderText = "Data de Criação"}
            };

            return colunas;
        }

        public int ObterNumeroTesteSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Teste> testes)
        {
            grid.Rows.Clear();

            foreach (Teste teste in testes)
            {
                string materia = "";

                if (teste.materias.Count > 1)
                    materia = "Todas";
                else
                    materia = teste.materias.FirstOrDefault(x => x == teste.materias[0]).titulo;

                grid.Rows.Add(teste.id, teste.titulo, teste.disciplina, materia, teste.numQuestoes, teste.dataCriacao.ToString("dd/MM/yyyy"));
            }
        }
    }
}

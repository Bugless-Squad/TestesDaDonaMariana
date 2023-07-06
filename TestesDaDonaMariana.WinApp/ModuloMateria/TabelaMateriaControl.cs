using TestesDaDonaMariana.Dominio.ModuloMateria;

namespace TestesDaDonaMariana.WinApp.ModuloMateria
{
    public partial class TabelaMateriaControl : UserControl
    {
        public TabelaMateriaControl()
        {
            InitializeComponent();

            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Título", HeaderText = "Título"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Disciplina", HeaderText = "Disciplina"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Série", HeaderText = "Série"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Quantidade de Questões", HeaderText = "Quantidade de Questões"},

            };

            return colunas;
        }

        public int ObterNumeroItemSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Materia> materias)
        {
            grid.Rows.Clear();

            foreach (var materia in materias)
            {
                grid.Rows.Add(materia.id, materia.titulo, materia.disciplina, materia.serie, materia.qtdQuestoesMateria.HasValue ? materia.qtdQuestoesMateria : "0");
            }
        }
    }
}

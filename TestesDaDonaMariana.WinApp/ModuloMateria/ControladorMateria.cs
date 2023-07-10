using System.Drawing.Drawing2D;
using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Dominio.ModuloQuestao;

namespace TestesDaDonaMariana.WinApp.ModuloMateria
{
    public class ControladorMateria : ControladorBase
    {
        List<OpcoesSeriesEnum> seriesEnum { get { return new List<OpcoesSeriesEnum>(Enum.GetValues(typeof(OpcoesSeriesEnum)).Cast<OpcoesSeriesEnum>()); } }

        IRepositorioDisciplina repositorioDisciplina;
        IRepositorioMateria repositorioMateria;
        IRepositorioQuestao repositorioQuestao;
        TabelaMateriaControl tabelaMaterias;

        public ControladorMateria(IRepositorioMateria repositorioMateria, IRepositorioDisciplina repositorioDisciplina, IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioMateria = repositorioMateria;
            this.repositorioQuestao = repositorioQuestao;
        }
        public override string ToolTipInserir => "Cadastrar Matéria";
        public override string ToolTipEditar => "Editar Matéria Existente";
        public override string ToolTipExcluir => "Excluir Matéria Existente";
        public override string ToolTipHome => "Voltar a tela inicial";

        public override bool HomeHabilitado => true;
        public override bool InserirHabilitado => true;
        public override bool EditarHabilitado => true;
        public override bool EditarVisivel => true;
        public override bool ExcluirHabilitado => true;

        public override void Inserir()
        {
            TelaMateriaForm tela = new(repositorioMateria.SelecionarTodos(), repositorioDisciplina.SelecionarTodos(), seriesEnum);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                Materia materia = tela.ObterMateria();

                materia.disciplina.materias.Add(materia);

                repositorioMateria.Inserir(materia);

                CarregarMaterias();
            }
            else
            {
                TelaPrincipalForm.Tela.AtualizarRodape("");
            }
        }

        public override void Editar()
        {
            Materia materiaSelecionada = ObterMateriaSelecionado();

            if (materiaSelecionada == null)
            {
                MessageBox.Show($"Selecione a Materia primeiro!",
                    "Edição da Materia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }
            if (repositorioQuestao.SelecionarTodos().Any(x => x.materia == materiaSelecionada))
            {
                MessageBox.Show($"Não é possivel editar essa materias pois ela possuí vinculo com ao menos uma questão!",
                    "Edição de Materia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            TelaMateriaForm tela = new(repositorioMateria.SelecionarTodos(), repositorioDisciplina.SelecionarTodos(), seriesEnum);

            tela.ConfigurarTela(materiaSelecionada);

            DialogResult opcaoEscolhida = tela.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Materia materia = tela.ObterMateria();

                materia.disciplina.materias.Remove(materiaSelecionada);

                materia.disciplina.materias.Add(materia);

                repositorioMateria.Editar(materiaSelecionada, materia);

                CarregarMaterias();
            }
            else
            {
                TelaPrincipalForm.Tela.AtualizarRodape("");
            }
        }

        public override void Excluir()
        {
            Materia materia = ObterMateriaSelecionado();

            if (materia == null)
            {
                MessageBox.Show($"Selecione uma matéria primeiro!",
                    "Exclusão de Materia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }
            if (repositorioQuestao.SelecionarTodos().Any(x => x.materia == materia))
            {
                MessageBox.Show($"Não é possivel remover essa materias pois ela possuí vinculo com ao menos uma questão!",
                    "Exclusão de Materia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir o item {materia.titulo}?",
                "Exclusão de Materia",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioMateria.Excluir(materia);

                CarregarMaterias();
            }
        }

        public override UserControl ObterListagem()
        {
            if (tabelaMaterias == null)
                tabelaMaterias = new TabelaMateriaControl();

            CarregarMaterias();

            return tabelaMaterias;
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Materias";
        }    

        private void CarregarMaterias()
        {
            List<Materia> materias = repositorioMateria.SelecionarTodos();

            tabelaMaterias.AtualizarRegistros(materias);
        }

        private Materia ObterMateriaSelecionado()
        {
            int id = tabelaMaterias.ObterNumeroItemSelecionado();

            return repositorioMateria.SelecionarPorId(id);
        }
    }
}

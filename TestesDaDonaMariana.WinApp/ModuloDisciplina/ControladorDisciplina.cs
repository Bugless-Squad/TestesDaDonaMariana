using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.WinApp.ModuloDiciplina;
using TestesDaDonaMariana.WinApp.ModuloMateria;

namespace TestesDaDonaMariana.WinApp.ModuloDisciplina
{
    public class ControladorDisciplina : ControladorBase
    {
        IRepositorioDisciplina repositorioDisciplina;
        IRepositorioMateria repositorioMateria;
        TabelaDisciplinaControl tabelaDisciplina;

        public ControladorDisciplina(IRepositorioDisciplina repositorioDisciplina, IRepositorioMateria repositorioMateria)
        {
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioMateria = repositorioMateria;
        }

        public override string ToolTipInserir => "Cadastrar Disciplina";
        public override string ToolTipEditar => "Editar Disciplina Existente";
        public override string ToolTipExcluir => "Excluir Disciplina Existente";
        public override string ToolTipHome => "Voltar a tela inicial";

        public override bool HomeHabilitado => true;
        public override bool InserirHabilitado => true;
        public override bool EditarHabilitado => true;
        public override bool EditarVisivel => true;
        public override bool ExcluirHabilitado => true;

        public override void Inserir()
        {
            TelaDisciplinaForm tela = new(repositorioDisciplina.SelecionarTodos());

            if (tela.ShowDialog() == DialogResult.OK)
            {
                Disciplina disciplina = tela.ObterDisciplina();

                repositorioDisciplina.Inserir(disciplina);

                CarregarDisciplinas();
            }
            else
            {
                TelaPrincipalForm.Tela.AtualizarRodape("");
            }
        }

        public override void Editar()
        {
            Disciplina disciplinaSelecionada = ObterDisciplinaSelecionada();

            if (disciplinaSelecionada == null)
            {
                MessageBox.Show($"Selecione uma disciplina primeiro!",
                    "Edição de Disciplina",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            TelaDisciplinaForm tela = new(repositorioDisciplina.SelecionarTodos());

            tela.ConfigurarTela(disciplinaSelecionada);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                Disciplina disciplina = tela.ObterDisciplina();

                repositorioDisciplina.Editar(disciplinaSelecionada, disciplina);

                CarregarDisciplinas();
            }
            else
            {
                TelaPrincipalForm.Tela.AtualizarRodape("");
            }
        }

        public override void Excluir()
        {
            Disciplina disciplina = ObterDisciplinaSelecionada();

            if (disciplina == null)
            {
                MessageBox.Show($"Selecione uma disciplina primeiro!",
                    "Exclusão de disciplinas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }
            if (repositorioMateria.SelecionarTodos().Any(x => x.disciplina == disciplina))
            {
                MessageBox.Show($"Não é possivel remover essa disciplina pois ela possuí vinculo com ao menos uma matéria!",
                    "Exclusão de Itens",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir o item {disciplina.nome}?",
                "Exclusão de Disciplina",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioDisciplina.Excluir(disciplina);

                CarregarDisciplinas();
            }
        }

        public override UserControl ObterListagem()
        {
            if (tabelaDisciplina == null)
                tabelaDisciplina = new TabelaDisciplinaControl();

            CarregarDisciplinas();

            return tabelaDisciplina;
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Disciplinas";
        }

        private void CarregarDisciplinas()
        {
            List<Disciplina> disciplinas = repositorioDisciplina.SelecionarTodos();

            tabelaDisciplina.AtualizarRegistros(disciplinas);
        }

        private Disciplina ObterDisciplinaSelecionada()
        {
            int id = tabelaDisciplina.ObterNumeroDisciplinaSelecionado();

            return repositorioDisciplina.SelecionarPorId(id);
        }
    }
}

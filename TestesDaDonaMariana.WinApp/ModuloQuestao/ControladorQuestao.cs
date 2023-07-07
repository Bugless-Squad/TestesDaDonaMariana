using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloQuestao;

namespace TestesDaDonaMariana.WinApp.ModuloQuestao
{
    public class ControladorQuestao : ControladorBase
    {
        private IRepositorioQuestao repositorioQuestao;
        private IRepositorioDisciplina repositorioDisciplina;
        private TabelaQuestaoControl tabelaQuestao;

        public ControladorQuestao(IRepositorioQuestao repositorioQuestao, IRepositorioDisciplina repositorioDisciplina)
        {
            this.repositorioQuestao = repositorioQuestao;
            this.repositorioDisciplina = repositorioDisciplina;
        }

        public override string ToolTipInserir => "Cadastrar Questão";
        public override string ToolTipEditar => "Editar Questão Existente";
        public override string ToolTipExcluir => "Excluir Questão Existente";
        public override string ToolTipHome => "Voltar a tela inicial";

        public override bool HomeHabilitado => true;
        public override bool InserirHabilitado => true;
        public override bool EditarHabilitado => true;
        public override bool ExcluirHabilitado => true;

        public override void Inserir()
        {
            Questao questao = new();

            TelaQuestaoForm tela = new(questao, repositorioQuestao.SelecionarTodos(), repositorioDisciplina.SelecionarTodos());

            DialogResult opcaoEscolhida = tela.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                questao = tela.ObterQuestao();

                repositorioQuestao.Inserir(questao);

                CarregarQuestoes();
            }
        }

        public override void Editar()
        {
            Questao questaoSelecionada = ObterQuestãoSelecionada();

            if (questaoSelecionada == null)
            {
                MessageBox.Show($"Selecione um questao primeiro!",
                    "Edição de clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            TelaQuestaoForm tela = new(questaoSelecionada, repositorioQuestao.SelecionarTodos(), repositorioDisciplina.SelecionarTodos());

            tela.ConfigurarTela(questaoSelecionada);

            DialogResult opcaoEscolhida = tela.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Questao questao = tela.ObterQuestao();

                repositorioQuestao.Editar(questaoSelecionada, questao);

                CarregarQuestoes();
            }
        }

        public override void Excluir()
        {
            Questao questaoSelecionada = ObterQuestãoSelecionada();

            if (questaoSelecionada == null)
            {
                MessageBox.Show($"Selecione um questao primeiro!",
                    "Exclusão de Questões",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }
            //if (repositorioQuestao.SelecionarTodos().Any(x => x. == questoes))
            //{
            //    MessageBox.Show($"Não é possivel remover esse questao pois ele possuí vinculo com ao menos um Aluguel!",
            //        "Exclusão de clientes",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Exclamation);

            //    return;
            //}

            DialogResult opcaoEscolhida = MessageBox.Show(
                $"Deseja excluir o questao {questaoSelecionada.id}?", 
                "Exclusão de Questóes",
                MessageBoxButtons.OKCancel, 
                MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioQuestao.Excluir(questaoSelecionada);

                CarregarQuestoes();
            }
        }

        public override UserControl ObterListagem()
        {
            if (tabelaQuestao == null)
                tabelaQuestao = new TabelaQuestaoControl();

            CarregarQuestoes();

            return tabelaQuestao;
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Cliente";
        }

        private void CarregarQuestoes()
        {
            List<Questao> questoes = repositorioQuestao.SelecionarTodos();

            tabelaQuestao.AtualizarRegistros(questoes);
        }

        private Questao ObterQuestãoSelecionada()
        {
            int id = tabelaQuestao.ObterNumeroClienteSelecionado();

            return repositorioQuestao.SelecionarPorId(id);
        }
    }
}

using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Dominio.ModuloQuestao;
using TestesDaDonaMariana.Dominio.ModuloTeste;
using TestesDaDonaMariana.WinApp.ModuloMateria;
using TestesDaDonaMariana.WinApp.ModuloQuestao;

namespace TestesDaDonaMariana.WinApp.ModuloTeste
{
    public class ControladorTeste : ControladorBase
    {
        IRepositorioDisciplina repositorioDisciplina;
        IRepositorioTeste repositorioTeste;
        TabelaTesteControl tabelaTeste;

        public ControladorTeste(IRepositorioTeste repositorioTeste, IRepositorioDisciplina repositorioDisciplina)
        {
            this.repositorioTeste = repositorioTeste;
            this.repositorioDisciplina = repositorioDisciplina;
        }

        public override string ToolTipInserir => "Cadastrar Teste";
        public override string ToolTipEditar => "Duplicar Teste Existente";
        public override string ToolTipExcluir => "Excluir Teste Existente";
        public override string ToolTipHome => "Voltar a tela inicial";

        public override bool HomeHabilitado => true;
        public override bool InserirHabilitado => true;
        public override bool EditarHabilitado => true;
        public override bool ExcluirHabilitado => true;

        public override void Inserir()
        {
            TelaTesteForm tela = new(repositorioTeste.SelecionarTodos(), repositorioDisciplina.SelecionarTodos());

            if (tela.ShowDialog() == DialogResult.OK)
            {
                Teste teste = tela.ObterTeste();

                repositorioTeste.Inserir(teste);

                CarregarTeste();
            }
        }

        public override void Editar()
        {
            Teste testeSelecionado = ObterTesteSelecionado();

            if (testeSelecionado == null)
            {
                MessageBox.Show($"Selecione um questao primeiro!",
                    "Edição de clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            TelaTesteForm tela = new(repositorioTeste.SelecionarTodos(), repositorioDisciplina.SelecionarTodos());

            tela.ConfigurarTelaDuplicacao(testeSelecionado);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                Teste teste = tela.ObterTeste();

                repositorioTeste.Editar(testeSelecionado, teste);

                CarregarTeste();
            }
        }

        public override void Excluir()
        {
            Teste testeSelecionado = ObterTesteSelecionado();

            if (testeSelecionado == null)
            {
                MessageBox.Show($"Selecione um teste primeiro!",
                    "Exclusão de Testes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show(
                $"Deseja excluir o questao {testeSelecionado.id}?",
                "Exclusão de Questóes",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioTeste.Excluir(testeSelecionado);

                CarregarTeste();
            }
        }       

        private void CarregarTeste()
        {
            List<Teste> testes = repositorioTeste.SelecionarTodos();

            tabelaTeste.AtualizarRegistros(testes);
        }

        private Teste ObterTesteSelecionado()
        {
            int id = tabelaTeste.ObterNumeroTesteSelecionado();

            return repositorioTeste.SelecionarPorId(id);
        }

        public override UserControl ObterListagem()
        {
            if (tabelaTeste == null)
                tabelaTeste = new TabelaTesteControl();

            CarregarTeste();

            return tabelaTeste;
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Testes";
        }
    }
}

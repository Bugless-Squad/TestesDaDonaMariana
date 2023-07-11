using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Dominio.ModuloQuestao;
using TestesDaDonaMariana.Dominio.ModuloTeste;
using TestesDaDonaMariana.Infra.Dados.Json.Compartilhado;
using TestesDaDonaMariana.Infra.Dados.Sql.ModuloDisciplina;
using TestesDaDonaMariana.Infra.Dados.Sql.ModuloMateria;
using TestesDaDonaMariana.Infra.Dados.Sql.ModuloQuestao;
using TestesDaDonaMariana.Infra.Dados.Sql.ModuloTeste;
using TestesDaDonaMariana.WinApp.ModuloDisciplina;
using TestesDaDonaMariana.WinApp.ModuloMateria;
using TestesDaDonaMariana.WinApp.ModuloQuestao;
using TestesDaDonaMariana.WinApp.ModuloTeste;

namespace TestesDaDonaMariana.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase controlador;

        //static ContextoDeDados contextoDeDados = new(carregarDados: true);

        //private IRepositorioDisciplina repositorioDisciplina = new RepositorioDisciplinaJson(contextoDeDados);
        //private IRepositorioMateria repositorioMateria = new RepositorioMateriaJson(contextoDeDados);
        //private IRepositorioQuestao repositorioQuestao = new RepositorioQuestaoJson(contextoDeDados);
        //private IRepositorioTeste repositorioTeste = new RepositorioTesteJson(contextoDeDados);

        private IRepositorioDisciplina repositorioDisciplina = new RepositorioDisciplinaSql();
        private IRepositorioMateria repositorioMateria = new RepositorioMateriaSql();
        private IRepositorioQuestao repositorioQuestao = new RepositorioQuestaoSql();
        private IRepositorioTeste repositorioTeste = new RepositorioTesteSql();

        public TelaPrincipalForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();

            Tela = this;
        }

        public static TelaPrincipalForm Tela
        {
            get;
            private set;
        }

        public void AtualizarRodape(string status)
        {
            lableRodape.Text = status;
        }

        private void DisciplinasMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorDisciplina(repositorioDisciplina, repositorioMateria);

            ConfigurarTelaPrincipal(controlador);
        }

        private void materiasMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorMateria(repositorioMateria, repositorioDisciplina, repositorioQuestao);

            ConfigurarTelaPrincipal(controlador);
        }

        private void questoesMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorQuestao(repositorioQuestao, repositorioMateria, repositorioDisciplina, repositorioTeste);

            ConfigurarTelaPrincipal(controlador);
        }

        private void testesMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorTeste(repositorioTeste, repositorioDisciplina);

            ConfigurarTelaPrincipal(controlador);
        }


        private void ConfigurarTelaPrincipal(ControladorBase controladorBase)
        {
            labelTipoDoCadastro.Text = controladorBase.ObterTipoCadastro();

            ConfigurarToolTips(controlador);

            ConfigurarListagem(controlador);
        }

        private void ConfigurarListagem(ControladorBase controladorBase)
        {
            UserControl listagem = controladorBase.ObterListagem();

            listagem.Dock = DockStyle.Fill;

            panelRegistros.Controls.Clear();

            panelRegistros.Controls.Add(listagem);
        }

        private void ConfigurarToolTips(ControladorBase controlador)
        {
            btnInserir.ToolTipText = controlador.ToolTipInserir;
            btnEditar.ToolTipText = controlador.ToolTipEditar;
            btnDuplicar.ToolTipText = controlador.ToolTipDuplicar;
            btnExcluir.ToolTipText = controlador.ToolTipExcluir;
            btnFiltrar.ToolTipText = controlador.ToolTipFiltrar;
            btnAdicionarItens.ToolTipText = controlador.ToolTipAdicionarItens;
            btnRemoverItens.ToolTipText = controlador.ToolTipRemoverItens;
            btnFinalizarPgto.ToolTipText = controlador.ToolTipFinalizarPagamento;
            btnConfigDesconto.ToolTipText = controlador.ToolTipConfigDesconto;
            btnVisualizar.ToolTipText = controlador.ToolTipVisualizar;
            btnVisualizar.ToolTipText = controlador.ToolTipVisualizar;
            btnVisualizarGabarito.ToolTipText = controlador.ToolTipVisualizarGabarito;
            btnGerarPdf.ToolTipText = controlador.ToolTipGerarPdf;
            btnHome.ToolTipText = controlador.ToolTipHome;

            btnInserir.Enabled = controlador.InserirHabilitado;
            btnEditar.Enabled = controlador.EditarHabilitado;
            btnDuplicar.Enabled = controlador.DuplicarHabilitado;
            btnExcluir.Enabled = controlador.ExcluirHabilitado;
            btnHome.Enabled = controlador.HomeHabilitado;
            btnFiltrar.Enabled = controlador.FiltrarHabilitado;
            btnAdicionarItens.Enabled = controlador.AdicionarItensHabilitado;
            btnRemoverItens.Enabled = controlador.RemoverItensHabilitado;
            btnFinalizarPgto.Enabled = controlador.FinalizarPagamentoHabilitado;
            btnConfigDesconto.Enabled = controlador.ConfigDescontoHabilitado;
            btnVisualizar.Enabled = controlador.VisualizarHabilitado;
            btnVisualizarGabarito.Enabled = controlador.VisualizarGabaritoHabilitado;
            btnGerarPdf.Enabled = controlador.GerarPdfHabilitado;

            btnInserir.Visible = controlador.InserirVisivel;
            btnEditar.Visible = controlador.EditarVisivel;
            btnDuplicar.Visible = controlador.DuplicarVisivel;
            btnExcluir.Visible = controlador.ExcluirVisivel;
            btnHome.Visible = controlador.HomeVisivel;
            btnFiltrar.Visible = controlador.FiltrarVisivel;
            btnAdicionarItens.Visible = controlador.AdicionarItensVisivel;
            btnRemoverItens.Visible = controlador.RemoverItensVisivel;
            btnFinalizarPgto.Visible = controlador.FinalizarPagamentoVisivel;
            btnConfigDesconto.Visible = controlador.ConfigDescontoVisivel;
            btnVisualizar.Visible = controlador.VisualizarVisivel;
            btnVisualizarGabarito.Visible = controlador.VisualizarGabaritoVisivel;
            btnGerarPdf.Visible = controlador.GerarPdfVisivel;

            toolStripSeparator0.Visible = controlador.SeparadorVisivel0;
            toolStripSeparator1.Visible = controlador.SeparadorVisivel1;
            toolStripSeparator2.Visible = controlador.SeparadorVisivel2;
            toolStripSeparator3.Visible = controlador.SeparadorVisivel3;
            toolStripSeparator4.Visible = controlador.SeparadorVisivel4;
            toolStripSeparator5.Visible = controlador.SeparadorVisivel5;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btdDuplicar_Click(object sender, EventArgs e)
        {
            controlador.Duplicar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            controlador.Filtrar();
        }

        private void btnAdicionarItens_Click(object sender, EventArgs e)
        {
            controlador.AdicionarItens();
        }

        private void btnRemoverItens_Click(object sender, EventArgs e)
        {
            controlador.RemoverItens();
        }

        private void btnFinalizarPgto_Click(object sender, EventArgs e)
        {
            controlador.FinalizarPagamento();
        }

        private void btnConfigDesconto_Click(object sender, EventArgs e)
        {
            controlador.ConfigurarDesconto();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            controlador.VisualizarTeste();
        }

        private void btnVisualizarGabarito_Click(object sender, EventArgs e)
        {
            controlador.VisualizarGabarito();
        }

        private void btnGerarPdf_Click(object sender, EventArgs e)
        {
            controlador.GerarPdf();
        }
    }
}
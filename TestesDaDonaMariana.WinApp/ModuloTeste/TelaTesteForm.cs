using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Dominio.ModuloQuestao;
using TestesDaDonaMariana.Dominio.ModuloTeste;
using TestesDaDonaMariana.WinApp.ModuloQuestao;

namespace TestesDaDonaMariana.WinApp.ModuloTeste
{
    public partial class TelaTesteForm : Form
    {
        Teste teste { get; set; }
        List<Teste> testes { get; set; }
        List<Questao> questoes { get; set; }
        Teste testeSelecionado { get; set; }
        TabelaQuestoesTesteControl tabelaQuestoesTeste { get; set; }

        public TelaTesteForm(List<Teste> testes, List<Disciplina> disciplinas)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            CarregarDisciplinas(disciplinas);

            this.testes = testes;

            if (tabelaQuestoesTeste == null)
                tabelaQuestoesTeste = new();

            questoes = new();

            panelAlternativas.Controls.Clear();

            panelAlternativas.Controls.Add(tabelaQuestoesTeste);
        }

        public Teste ObterTeste()
        {
            int id = Convert.ToInt32(txtId.Text);

            string titulo = txtTitulo.Text.Trim();

            Disciplina disciplina = (Disciplina)cmbDisciplina.SelectedItem;

            List<Materia> materias = new();

            if (cmbMaterias.SelectedItem == "Todas")
                materias = disciplina.materias;
            else if (cmbMaterias.SelectedItem != null)
                materias.Add((Materia)cmbMaterias.SelectedItem);

            int numeroDeQuestoes = Convert.ToInt32(numQuestoes.Value);

            return new(id, titulo, disciplina, materias, this.questoes, numeroDeQuestoes);
        }

        public void ConfigurarTelaDuplicacao(Teste testeSelecionado)
        {
            this.testeSelecionado = testeSelecionado;

            txtId.Text = testeSelecionado.id.ToString().Trim();
            txtTitulo.Text = testeSelecionado.titulo.ToString().Trim() + " - Duplicado";
            cmbDisciplina.SelectedItem = testeSelecionado.disciplina;

            if (testeSelecionado.materias.Count > 1)
                cmbMaterias.SelectedItem = "Todas";
            else
                cmbMaterias.SelectedItem = testeSelecionado.materias.FirstOrDefault(x => x == testeSelecionado.materias[0]);

            numQuestoes.Value = Convert.ToDecimal(testeSelecionado.numQuestoes);
        }

        public void ConfigurarTelaVisualizarDetalhes(Teste testeSelecionado)
        {
            this.testeSelecionado = testeSelecionado;

            this.Text = $"Vizualizando {testeSelecionado.titulo}.";

            txtId.Text = testeSelecionado.id.ToString().Trim();
            txtTitulo.Text = testeSelecionado.titulo.ToString().Trim();
            txtTitulo.ReadOnly = true;
            cmbDisciplina.SelectedItem = testeSelecionado.disciplina;
            cmbDisciplina.Enabled = false;

            tabelaQuestoesTeste.AtualizarRegistros(testeSelecionado.questoes);

            if (testeSelecionado.materias.Count > 1)
                cmbMaterias.SelectedItem = "Todas";
            else
                cmbMaterias.SelectedItem = testeSelecionado.materias.FirstOrDefault(x => x == testeSelecionado.materias[0]);

            cmbMaterias.Enabled = false;

            lblQtdQuestoes.Visible = false;

            numQuestoes.Enabled = false;
            numQuestoes.Visible = false;

            btnGerarTeste.Enabled = false;
            btnGerarTeste.Visible = false;

            btnGravar.Enabled = false;
            btnGravar.Visible = false;

            btnCancelar.Text = "Fechar";
        }

        private void btnGerarTeste_Click(object sender, EventArgs e)
        {
            string status = ValidarTeste();

            teste.questoes.Clear();

            if (status != "")
                return;

            Random random = new();
            int randomIndex = 0;

            while (teste.questoes.Count != teste.numQuestoes)
            {
                foreach (Materia materia in teste.materias)
                {
                    randomIndex = random.Next(materia.questoes.Count);

                    if (teste.questoes.All(q => q.id != materia.questoes[randomIndex].id) && teste.questoes.Count != teste.numQuestoes && materia.questoes.Count != 0)
                    {
                        teste.questoes.Add(materia.questoes[randomIndex]);
                    }
                }

            }

            questoes = teste.questoes;

            tabelaQuestoesTeste.AtualizarRegistros(teste.questoes);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string status = ValidarTeste();

            teste.questoes = questoes;

            if (status != "")
            {
                DialogResult = DialogResult.None;
            }

            if (teste.questoes.Count == 0)
            {
                status = $"Você deve clicar em gerar um teste para poder gravar seu teste!";
                TelaPrincipalForm.Tela.AtualizarRodape(status);
                DialogResult = DialogResult.None;
            }

            return;
        }

        private string ValidarTeste()
        {
            teste = ObterTeste();

            string status = "";

            if (testes.Any(x => x.titulo == teste.titulo))
                status = $"Já existe um teste cadastrado com esse título!";
            else
                status = teste.Validar();

            TelaPrincipalForm.Tela.AtualizarRodape(status);

            if (teste == null)
                questoes = new();

            return status;
        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Disciplina)cmbDisciplina.SelectedItem != null)
            {
                cmbMaterias.Enabled = true;
            }

            CarregarMaterias(((Disciplina)cmbDisciplina.SelectedItem).materias);
        }

        private void CarregarDisciplinas(List<Disciplina> disciplinas)
        {
            cmbDisciplina.Items.Clear();

            foreach (Disciplina disciplina in disciplinas)
            {
                cmbDisciplina.Items.Add(disciplina);
            }
        }

        private void CarregarMaterias(List<Materia> materias)
        {
            cmbMaterias.Items.Clear();

            foreach (Materia materia in materias)
            {
                cmbMaterias.Items.Add(materia);
            }

            cmbMaterias.Items.Add("Todas");
        }

        private void numQuestoes_ValueChanged(object sender, EventArgs e)
        {
            btnGerarTeste.Enabled = true;
        }

        private void cmbMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teste != null)
            {
                teste.questoes.Clear();
                tabelaQuestoesTeste.AtualizarRegistros(teste.questoes);
            }
        }
    }
}

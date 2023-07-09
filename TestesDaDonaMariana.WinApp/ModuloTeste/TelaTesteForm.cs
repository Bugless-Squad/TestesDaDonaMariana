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
        Teste testeSelecionado { get; set; }
        List<Questao> questoesTeste { get; set; }
        TabelaQuestoesTesteControl tabelaQuestoesTeste { get; set; }

        public TelaTesteForm(List<Teste> testes, List<Disciplina> disciplinas)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            CarregarDisciplinas(disciplinas);

            this.testes = testes;

            if (tabelaQuestoesTeste == null)
                tabelaQuestoesTeste = new();

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

            if (cmbMaterias.SelectedItem != null)
                materias.Add((Materia)cmbMaterias.SelectedItem);

            int numeroDeQuestoes = Convert.ToInt32(numQuestoes.Value);

            return new(id, titulo, disciplina, materias, numeroDeQuestoes);
        }

        public void ConfigurarTelaDuplicacao(Teste testeSelecionado)
        {
            this.testeSelecionado = testeSelecionado;

            txtId.Text = testeSelecionado.id.ToString().Trim();
            txtTitulo.Text = testeSelecionado.titulo.ToString().Trim();
            cmbDisciplina.SelectedItem = testeSelecionado.disciplina;
            cmbMaterias.SelectedItem = testeSelecionado.materias;
            numQuestoes.Value = Convert.ToDecimal(testeSelecionado.numQuestoes);
        }

        private void btnGerarTeste_Click(object sender, EventArgs e)
        {
            teste = ObterTeste();

            string status = "";

            if (testes.Where(i => teste.id != testeSelecionado?.id).Any(x => x.titulo == teste.titulo))
                status = $"Já existe um teste cadastrado com esse título!";
            else
                status = teste.Validar();

            TelaPrincipalForm.Tela.AtualizarRodape(status);

            if (status != "")
                return;

            foreach (Materia materia in teste.materias)
            {
                
            }

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            teste = ObterTeste();

            string status = "";

            if (testes.Where(i => teste.id != testeSelecionado?.id).Any(x => x.titulo == teste.titulo))
                status = $"Já existe um teste cadastrado com esse título!";
            else
                status = teste.Validar();

            TelaPrincipalForm.Tela.AtualizarRodape(status);

            if (status != "")
            {
                DialogResult = DialogResult.None;
                return;
            }

            return;
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

        //private void CarregarQuestoes(List<Questao> questoes)
        //{
        //    foreach (Questao questao in materias)
        //    {
        //        cmbMaterias.Items.Add(materias);
        //    }
        //}

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Disciplina)cmbDisciplina.SelectedItem != null)
            {
                cmbMaterias.Enabled = true;
            }

            CarregarMaterias(((Disciplina)cmbDisciplina.SelectedItem).materias);
        }

        private void numQuestoes_ValueChanged(object sender, EventArgs e)
        {
            btnGerarTeste.Enabled = true;
        }
    }
}

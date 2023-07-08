using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Dominio.ModuloQuestao;

namespace TestesDaDonaMariana.WinApp.ModuloQuestao
{
    public partial class TelaQuestaoForm : Form
    {
        Questao questao { get; set; }
        List<Questao> questoes { get; set; }
        Questao questaoSelecionada { get; set; }
        List<Alternativa> alternativasParaRemover { get; set; }
        List<Alternativa> alternativasParaAdicionar { get; set; }
        TabelaAlternativasControl tabelaAlternativas { get; set; }
        List<Alternativa> alternativas { get { return alternativasParaAdicionar.Except(alternativasParaRemover).ToList(); } }

        public TelaQuestaoForm(List<Questao> questoes, List<Disciplina> disciplinas)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            CarregarDisciplinas(disciplinas);

            this.questao = new();
            this.questoes = questoes;

            if (tabelaAlternativas == null)
                tabelaAlternativas = new();

            alternativasParaAdicionar = new();
            alternativasParaRemover = new();

            panelAlternativas.Controls.Clear();

            panelAlternativas.Controls.Add(tabelaAlternativas);
        }

        public Questao ObterQuestao()
        {
            int id = Convert.ToInt32(txtId.Text);

            Disciplina disciplina = (Disciplina)cmbDisciplina.SelectedItem;

            Materia materia = (Materia)cmbMaterias.SelectedItem;

            string enunciado = txtEnunciado.Text.Trim();

            Alternativa alternativaCorreta = (Alternativa)cmbAlternativas.SelectedItem;

            List<Alternativa> alternativas = this.alternativas;

            return new(id, disciplina, materia, enunciado, alternativaCorreta, alternativas);
        }

        public void ConfigurarTelaEdicao(Questao questaoSelecionada)
        {
            this.questaoSelecionada = questaoSelecionada;

            this.alternativasParaAdicionar = questaoSelecionada.alternativas;

            CarregarAlternativas(alternativasParaAdicionar);

            btnRemover.Enabled = true;

            cmbAlternativas.Enabled = true;

            txtId.Text = questaoSelecionada.id.ToString().Trim();
            cmbDisciplina.SelectedItem = questaoSelecionada.disciplina;
            cmbMaterias.SelectedItem = questaoSelecionada.materia;
            txtEnunciado.Text = questaoSelecionada.enunciado.ToString().Trim();
            tabelaAlternativas.AtualizarRegistros(questaoSelecionada.alternativas);
            cmbAlternativas.SelectedItem = questaoSelecionada.alternativaCorreta;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (questao.alternativas == null && questaoSelecionada.alternativas == null)
                questao.alternativas = new();

            questao = ObterQuestao();

            alternativasParaAdicionar = questao.alternativas;

            string status = "";

            string texto = txtAlternativa.Text.Trim();

            Alternativa alternativa = new(texto);

            status = questao.ValidarParaAdicionar();

            TelaPrincipalForm.Tela.AtualizarRodape(status);

            if (status != "")
                return;

            status = alternativa.Validar();

            if (alternativasParaAdicionar.Any(x => x.texto == texto))
                status = $"Você não pode adicionar a mesma alternativa mais de uma vez!";

            if (alternativasParaAdicionar.Count >= 5)
                status = $"Você não pode adicionar mais de cinco alternativas por questão!";

            TelaPrincipalForm.Tela.AtualizarRodape(status);

            if (status != "")
                return;

            if (alternativasParaAdicionar.Count > 0)
                alternativa.idContador = alternativasParaAdicionar.Max(x => x.id);

            alternativa.idContador++;
            alternativa.id = alternativa.idContador;

            alternativasParaAdicionar.Add(alternativa);

            tabelaAlternativas.AtualizarRegistros(this.alternativas);

            txtAlternativa.Text = "";

            cmbAlternativas.Enabled = true;

            CarregarAlternativas(this.alternativas);

            questao.alternativas = alternativasParaAdicionar;
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            int id = tabelaAlternativas.ObterNumeroItemSelecionado();

            Alternativa alternativa = alternativasParaAdicionar.FirstOrDefault(x => x.id == id);

            string status = "";

            if (this.alternativas.Count() == 0)
                status = $"Você deve adicionar uma alternativa primeiro!";

            if (id == 0)
                status = $"Você deve selecionar uma alternativa primeiro!";

            TelaPrincipalForm.Tela.AtualizarRodape(status);

            alternativasParaRemover.Add(alternativa);

            tabelaAlternativas.AtualizarRegistros(this.alternativas);

            CarregarAlternativas(this.alternativas);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            questao = ObterQuestao();

            string status = "";

            if (questoes.Where(i => questao.id != questaoSelecionada?.id).Any(x => x.enunciado == questao.enunciado))
                status = $"Já existe uma questão cadastrada com esse enunciado!";
            else
                status = questao.Validar();

            if (questao.alternativas.All(x => x.alternativaCorreta == AlternativaCorretaEnum.Errada))
                status = $"Voce deve selecionar uma alternativa como correta!";

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

        private void CarregarAlternativas(List<Alternativa> alternativas)
        {
            cmbAlternativas.Items.Clear();

            foreach (Alternativa alternativa in alternativas)
            {
                cmbAlternativas.Items.Add(alternativa);
            }
        }

        private void CarregarMaterias(List<Materia> materias)
        {
            cmbMaterias.Items.Clear();

            foreach (Materia materia in materias)
            {
                cmbMaterias.Items.Add(materia);
            }
        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Disciplina)cmbDisciplina.SelectedItem != null)
            {
                cmbMaterias.Enabled = true;
            }

            CarregarMaterias(((Disciplina)cmbDisciplina.SelectedItem).materias);
        }

        private void cmbAlternativas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VerificarSeExisteAlternativaCorreta())
            {
                foreach (Alternativa a in this.alternativas)
                {
                    a.alternativaCorreta = AlternativaCorretaEnum.Errada;
                }
            }

            ((Alternativa)cmbAlternativas.SelectedItem).alternativaCorreta = AlternativaCorretaEnum.Correta;

            tabelaAlternativas.AtualizarRegistros(this.alternativas);
        }

        private bool VerificarSeExisteAlternativaCorreta()
        {
            return this.alternativas.Any(x => x.alternativaCorreta == AlternativaCorretaEnum.Correta);
        }

        private void txtAlternativa_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnAdicionar.Enabled = true;
            btnRemover.Enabled = true;
        }
    }
}

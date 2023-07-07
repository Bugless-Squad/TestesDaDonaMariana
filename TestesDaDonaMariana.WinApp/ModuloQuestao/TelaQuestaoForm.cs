using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Dominio.ModuloQuestao;

namespace TestesDaDonaMariana.WinApp.ModuloQuestao
{
    public partial class TelaQuestaoForm : Form
    {
        Questao questao { get; set; }
        Questao questaoSelecionada { get; set; }
        List<Questao> questoes { get; set; }
        List<Alternativa> alternativasParaAdicionar { get; set; }
        List<Alternativa> alternativasParaRemover { get; set; }
        TabelaAlternativasControl tabelaAlternativas { get; set; }

        public TelaQuestaoForm(Questao questao, List<Questao> questoes, List<Disciplina> disciplinas)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            CarregarDisciplinas(disciplinas);

            this.questao = questao;
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

            string gabarito = "";

            return new(id, disciplina, materia, enunciado, gabarito);
        }

        public void ConfigurarTela(Questao questaoSelecionada)
        {
            tabelaAlternativas.AtualizarRegistros(questaoSelecionada.alternativas);

            txtId.Text = questaoSelecionada.id.ToString().Trim();
            cmbDisciplina.SelectedItem = questaoSelecionada.disciplina;
            cmbMaterias.SelectedItem = questaoSelecionada.materia;
            txtEnunciado.Text = questaoSelecionada.enunciado.ToString().Trim();

            this.questaoSelecionada = questaoSelecionada;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string status = "";

            string texto = txtAlternativa.Text.Trim();

            Alternativa alternativa = new(texto);

            status = alternativa.Validar();

            if (questao.alternativas.Contains(alternativa))
                status = $"Você não pode adicionar a mesma alternativa mais de uma vez!";

            if (questao.alternativas.Count >= 5)
                status = $"Você não pode adicionar mais de cinco alternativas por questão!";

            TelaPrincipalForm.Tela.AtualizarRodape(status);

            if (status != "")
                return;

            txtAlternativa.Text = "";

            if (alternativasParaAdicionar.Count > 0)
                alternativa.idContador = alternativasParaAdicionar.Max(x => x.id);

            alternativa.idContador++;
            alternativa.id = alternativa.idContador;

            alternativasParaAdicionar.Add(alternativa);

            questao.AdicionarAlternativas(alternativasParaAdicionar);

            tabelaAlternativas.AtualizarRegistros(questao.alternativas);
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            int id = tabelaAlternativas.ObterNumeroItemSelecionado();

            Alternativa alternativa = questao.alternativas.FirstOrDefault(x => x.id == id);

            if (alternativa == null)
                return;

            alternativasParaRemover.Add(alternativa);

            questao.RemoverAlternativas(alternativasParaRemover);

            tabelaAlternativas.AtualizarRegistros(questao.alternativas.Except(alternativasParaRemover).ToList());

        }

        private void btnSelecionarAlternativaCorreta_Click(object sender, EventArgs e)
        {
            int id = tabelaAlternativas.ObterNumeroItemSelecionado();

            Alternativa alternativa = questao.alternativas.FirstOrDefault(x => x.id == id);

            questao.alternativas.Find(x => x.id == alternativa.id);

            alternativa.alternativaCorreta = AlternativaCorretaEnum.Correta;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string status = "";

            questao = ObterQuestao();

            if (questoes.Where(i => questao.id != questaoSelecionada?.id).Any(x => x.enunciado == questao.enunciado))
                status = $"Já existe uma questão cadastrada com esse enunciado!";
            else
                status = questao.Validar();

            if (questao.alternativas.Count < 2)
                status = $"Você deve adicionar no mínimo 2 alternativas por questão!";

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
        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Disciplina)cmbDisciplina.SelectedItem != null)
            {
                cmbMaterias.Enabled = true;
            }

            CarregarMaterias(((Disciplina)cmbDisciplina.SelectedItem).materias);
        }
    }
}

using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Dominio.ModuloQuestao;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

            string gabarito = "";

            return new(id, disciplina, materia, enunciado, gabarito);
        }

        public void ConfigurarTela(Questao questaoSelecionada)
        {
            this.questaoSelecionada = questaoSelecionada;

            txtId.Text = questaoSelecionada.id.ToString().Trim();
            cmbDisciplina.SelectedItem = questaoSelecionada.disciplina;
            cmbMaterias.SelectedItem = questaoSelecionada.materia;
            txtEnunciado.Text = questaoSelecionada.enunciado.ToString().Trim();

            tabelaAlternativas.AtualizarRegistros(questaoSelecionada.alternativas);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (questao.alternativas == null)
                questao.alternativas = new();

            string status = "";

            string texto = txtAlternativa.Text.Trim();

            Alternativa alternativa = new(texto);

            status = alternativa.Validar();

            if (alternativasParaAdicionar.Contains(alternativa))
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

            tabelaAlternativas.AtualizarRegistros(alternativasParaAdicionar);

            txtAlternativa.Text = "";

            CarregarAlternativas(alternativasParaAdicionar.Except(alternativasParaRemover).ToList());
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            int id = tabelaAlternativas.ObterNumeroItemSelecionado();

            Alternativa alternativa = alternativasParaAdicionar.FirstOrDefault(x => x.id == id);

            if (alternativasParaAdicionar.Except(alternativasParaRemover).Count() == 0)
            {
                TelaPrincipalForm.Tela.AtualizarRodape($"Você deve adicionar uma alternativa primeiro!");

                return;
            }

            alternativasParaRemover.Add(alternativa);

            tabelaAlternativas.AtualizarRegistros(alternativasParaAdicionar.Except(alternativasParaRemover).ToList());

            CarregarAlternativas(alternativasParaAdicionar.Except(alternativasParaRemover).ToList());
        }

        private void btnSelecionarAlternativaCorreta_Click(object sender, EventArgs e)
        {
            int id = tabelaAlternativas.ObterNumeroItemSelecionado();

            Alternativa alternativa = questao.alternativas.FirstOrDefault(x => x.id == id);

            alternativasParaAdicionar.Find(x => x.id == alternativa.id);

            if (id == 0)
            {
                TelaPrincipalForm.Tela.AtualizarRodape($"Você deve selecionar uma alternativa para torna-lá correta!");
                DialogResult = DialogResult.None;
                return;
            }

            alternativa.alternativaCorreta = AlternativaCorretaEnum.Correta;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            questao = ObterQuestao();

            questao.AdicionarAlternativas(alternativasParaAdicionar);

            questao.RemoverAlternativas(alternativasParaRemover);

            string status = "";

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
            ((Alternativa)cmbAlternativas.SelectedItem).alternativaCorreta = AlternativaCorretaEnum.Correta;

            CarregarAlternativas(alternativasParaAdicionar.Except(alternativasParaRemover).ToList());
        }

        private void txtAlternativa_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnAdicionar.Enabled = true;
            btnRemover.Enabled = true;
        }
    }
}

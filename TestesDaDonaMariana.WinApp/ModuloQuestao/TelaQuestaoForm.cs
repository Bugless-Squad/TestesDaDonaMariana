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

        public TelaQuestaoForm(List<Questao> questoes, List<Disciplina> disciplinas)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            CarregarDisciplinas(disciplinas);

            this.questoes = questoes;
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
            txtId.Text = questaoSelecionada.id.ToString().Trim();
            cmbDisciplina.SelectedItem = questaoSelecionada.disciplina;
            cmbMaterias.SelectedItem = questaoSelecionada.materia;
            txtEnunciado.Text = questaoSelecionada.enunciado.ToString().Trim();

            this.questaoSelecionada = questaoSelecionada;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string status = "";

            questao = ObterQuestao();

            if (questoes.Where(i => questao.id != questaoSelecionada?.id).Any(x => x.enunciado == questao.enunciado))
                status = $"Já existe uma questão cadastrada com esse enunciado!";
            else
                status = questao.Validar();

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
                cmbMaterias.Items.Add(disciplina);
            }
        }

        private void CarregarMaterias(List<Materia> materias)
        {
            foreach (Materia materia in materias)
            {
                cmbMaterias.Items.Add(materia);
            }
        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if((Disciplina)cmbDisciplina.SelectedItem != null)
            {
                cmbMaterias.Enabled = true;
            }
        }
    }
}

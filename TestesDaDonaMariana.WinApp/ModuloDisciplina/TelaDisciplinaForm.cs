using TestesDaDonaMariana.Dominio.ModuloDisciplina;

namespace TestesDaDonaMariana.WinApp.ModuloDisciplina
{
    public partial class TelaDisciplinaForm : Form
    {
        private Disciplina disciplina { get; set; }
        private Disciplina disciplinaSelecionada { get; set; }
        private List<Disciplina> disciplinas { get; set; }

        public TelaDisciplinaForm(List<Disciplina> disciplinas)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            this.disciplinas = disciplinas;
        }

        internal Disciplina ObterDisciplina()
        {
            int id = Convert.ToInt32(txtId.Text);

            string nome = txtDisciplina.Text;

            return new Disciplina(id, nome);
        }

        public void ConfigurarTela(Disciplina disciplinaSelecionada)
        {
            txtId.Text = disciplinaSelecionada.id.ToString();

            txtDisciplina.Text = disciplinaSelecionada.nome;

            this.disciplinaSelecionada = disciplinaSelecionada;
        }

        public Disciplina ObterCliente()
        {
            int id = Convert.ToInt32(txtId.Text);

            string nome = txtDisciplina.Text;

            return new(id, nome);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string status = "";

            disciplina = ObterCliente();

            if (disciplinas.Where(i => disciplina.id != disciplinaSelecionada?.id).Any(x => x.nome == disciplina.nome))
                status = $"Já existe uma disciplina cadastrada com esse nome!";
            else
                status = disciplina.Validar();

            TelaPrincipalForm.Tela.AtualizarRodape(status);

            if (status != "")
                DialogResult = DialogResult.None;
        }
    }
}

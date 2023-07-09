using System.Drawing.Drawing2D;
using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;

namespace TestesDaDonaMariana.WinApp.ModuloMateria
{
    public partial class TelaMateriaForm : Form
    {
        Materia materia { get; set; }
        Materia materiaSelecionada { get; set; }
        private List<Materia> materias { get; set; }

        public TelaMateriaForm(List<Materia> materias, List<Disciplina> disciplinas)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            CarregarDisciplinas(disciplinas);

            CarregarOpcaoSerie();

            this.materias = materias;
        }


        public Materia ObterMateria()
        {
            int id = Convert.ToInt32(txtId.Text);

            string titulo = txtTitulo.Text;

            Disciplina disciplina = (Disciplina)cmbDisciplina.SelectedItem;

            OpcoesSeriesEnum serie = (OpcoesSeriesEnum)cmbSerie.SelectedItem;

            return new Materia(id, titulo, disciplina, serie);
        }

        public void ConfigurarTela(Materia materiaSelecionada)
        {
            txtId.Text = materiaSelecionada.id.ToString();
            txtTitulo.Text = materiaSelecionada.titulo;
            cmbDisciplina.SelectedItem = materiaSelecionada.disciplina;
            cmbSerie.SelectedItem = materiaSelecionada.serie;

            this.materiaSelecionada = materiaSelecionada;
        }

        private void CarregarDisciplinas(List<Disciplina> disciplinas)
        {
            foreach (Disciplina disciplina in disciplinas)
            {
                cmbDisciplina.Items.Add(disciplina);
            }
        }

        private void CarregarOpcaoSerie()
        {
            OpcoesSeriesEnum[] serie = Enum.GetValues<OpcoesSeriesEnum>();

            foreach (OpcoesSeriesEnum opcaoSerie in serie)
            {
                cmbSerie.Items.Add(opcaoSerie);
            }

            cmbSerie.SelectedIndex = 0;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string status = "";

            materia = ObterMateria();

            if (materias.Where(i => materia.id != materiaSelecionada?.id).Any(x => x.titulo == materia.titulo))
                status = "Já existe uma materias cadastrada com esse nome!";
            else
                status = materia.Validar();

            TelaPrincipalForm.Tela.AtualizarRodape(status);

            if (status != "")
            {
                DialogResult = DialogResult.None;
                return;
            }

        }
    }
}

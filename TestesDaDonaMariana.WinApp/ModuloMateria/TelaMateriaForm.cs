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

        public TelaMateriaForm(List<Materia> materias, List<Disciplina> disciplinas, List<OpcoesSeriesEnum> series)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            CarregarDisciplinas(disciplinas);

            CarregarOpcaoSerie(series);

            this.materias = materias;
        }


        public Materia ObterMateria()
        {
            int id = Convert.ToInt32(txtId.Text);

            string titulo = txtTitulo.Text;

            Disciplina disciplina = (Disciplina)cmbDisciplina.SelectedItem;

            string serie = (string)cmbSerie.SelectedItem;

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

        private void CarregarOpcaoSerie(List<OpcoesSeriesEnum> series)
        {
            cmbSerie.Items.Clear();

            List<string> seriesFormatados = new();

            series.ForEach(s =>
            {
                int serie = (int)s;
                string serieFormatada = $"{serie}º ano";

                if (s >= OpcoesSeriesEnum.Primeira_Serie_EM && s <= OpcoesSeriesEnum.Terceira_Serie_EM)
                {
                    serie -= 10;
                    serieFormatada = $"{serie}º ano do Ensino Médio";
                }

                seriesFormatados.Add(serieFormatada);
            });

            seriesFormatados.ForEach(a => cmbSerie.Items.Add(a));
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesDaDonaMariana.Dominio.ModuloMateria;

namespace TestesDaDonaMariana.WinApp.ModuloMateria
{
    public partial class TelaMateriaForm : Form
    {
        private Materia materia { get; set; }

        public TelaMateriaForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();

            carregarOpcaoSerie();
        }


        public Materia ObterMateria()
        {
            int id = Convert.ToInt32(txtId.Text);
            string titulo = txtTitulo.Text;
            string disciplina = cmbDisciplina.Text;
            string serie = cmbSerie.Text;

            return new();
        }
        private void carregarOpcaoSerie()
        {
            OpcoesSerieEnum[] serie = Enum.GetValues<OpcoesSerieEnum>();

            foreach (OpcoesSerieEnum opcaoSerie in serie)
            {
                cmbSerie.Items.Add(opcaoSerie);
            }
            cmbSerie.SelectedIndex = 0;

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            materia = ObterMateria();
            string status = "";

            if (materia.Where(i => item.id != itemSelecionado?.id).Any(x => x.titulo == materia.titulo))
                status = "Já existe uma materia cadastrada com esse nome!";
            else
                status = materia.Validar();

            TelaPrincipalForm.Tela.AtualizarRodape(status);

            if (status != "")
                DialogResult = DialogResult.None;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            TelaPrincipalForm.Tela.AtualizarRodape("");
        }
    }
}
}

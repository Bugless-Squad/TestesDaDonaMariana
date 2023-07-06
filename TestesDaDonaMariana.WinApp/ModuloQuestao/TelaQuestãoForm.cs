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
using TestesDaDonaMariana.Dominio.ModuloQuestao;

namespace TestesDaDonaMariana.WinApp.ModuloQuestao
{
    public partial class TelaQuestaoForm : Form
    {
        Questao questao { get; set; }
        .+
        public TelaQuestaoForm(List<Materia> materias)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            CarregarMaterias(materias);
        }

        public Questao ObterQuestao()
        {
            int id = Convert.ToInt32(txtId.Text);

            Materia materia = (Materia)cmbMaterias.SelectedItem;

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            questao = ObterQuestao();

            string status = questao.Validar();

            TelaPrincipalForm.Tela.AtualizarRodape(status);

            if (status != "")
            {
                DialogResult = DialogResult.None;
                return;
            }

            TelaPrincipalForm.Tela.AtualizarRodape("");

            return;
        }

        private void CarregarMaterias(List<Materia> materias)
        {
            foreach (Materia materia in materias)
            {
                cmbMaterias.Items.Add(materia);
                cmbMaterias.Items.Add("Polinomios");
            }
        }
    }
}

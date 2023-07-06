using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesDaDonaMariana.Dominio.ModuloTeste;

namespace TestesDaDonaMariana.WinApp.ModuloTeste
{
    public partial class TelaCadastroTesteForm : Form
    {
        public TelaCadastroTesteForm()
        {
            InitializeComponent();
        }

        public Teste ObterTeste()
        {
            throw new NotImplementedException();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            TelaPrincipalForm.Tela.AtualizarRodape("");
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
        }
    }
}

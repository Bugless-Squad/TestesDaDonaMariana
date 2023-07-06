using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesDaDonaMariana.Dominio.ModuloDisciplina;

namespace TestesDaDonaMariana.WinApp.ModuloDisciplina
{
    public partial class TelaDisciplinaForm : Form
    {
        public TelaDisciplinaForm()
        {
            InitializeComponent();
        }

        internal Disciplina ObterDisciplina()
        {
            int id = Convert.ToInt32(txtId.Text);
            string nome = txtTitulo.Text;

            return new Disciplina(id, nome);
        }
    }
}

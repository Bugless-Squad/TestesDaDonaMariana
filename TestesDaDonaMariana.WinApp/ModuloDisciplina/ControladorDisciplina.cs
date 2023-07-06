using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.WinApp.ModuloDiciplina;
using TestesDaDonaMariana.WinApp.ModuloMateria;

namespace TestesDaDonaMariana.WinApp.ModuloDisciplina
{
    public class ControladorDisciplina : ControladorBase
    {
        IRepositorioDisciplina repositorioDisciplina;
        IRepositorioMateria repositorioMateria;
        TabelaDisciplinaControl tabelaDisciplina;

        public ControladorDisciplina(IRepositorioDisciplina repositorioDisciplina)
        {
            this.repositorioDisciplina = repositorioDisciplina;
            //   this.repositorioMateria = repositorioMateria;
        }

        public override string ToolTipInserir => "Realizar adição de Matéria";

        public override string ToolTipEditar => "Editar Matéria Existente";

        public override string ToolTipExcluir => "Excluir Matéria Existente";

        public override string ToolTipHome => "Voltar a tela inicial";

        public override bool HomeHabilitado => true;
        public override bool InserirHabilitado => true;
        public override bool EditarHabilitado => true;
        public override bool ExcluirHabilitado => true;

        public override void Inserir()
        {

            TelaDisciplinaForm telaDisciplina = new TelaDisciplinaForm();
            DialogResult opcaoEscolhida = telaDisciplina.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Disciplina disciplina = telaDisciplina.ObterDisciplina();
                repositorioDisciplina.Inserir(disciplina);

                CarregarDisciplinas();
            }
        }
        public override void Editar()
        {
            Disciplina disciplinaSelecionada = ObterDisciplinaSelecionado();

            if (disciplinaSelecionada == null)
            {
                MessageBox.Show($"Selecione a Disciplina primeiro!",
                    "Edição da Disciplina",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }
        }
        private Disciplina ObterDisciplinaSelecionado()
        {
            int id = tabelaDisciplina.ObterNumeroDisciplinaSelecionado();

            return repositorioDisciplina.SelecionarPorId(id);
        }
        public override void Excluir()
        {
            Disciplina disciplina = ObterDisciplinaSelecionado();

            if (disciplina == null)
            {
                MessageBox.Show($"Selecione uma disciplina primeiro!",
                    "Exclusão de disciplinas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }
            //if (repositorioTeste.SelecionarTodos().Any(x => x.materias.Any(i => i.id == materia.id)))
            //{
            //    MessageBox.Show($"Não é possivel remover essa materia possui vinculo com ao menos um teste!",
            //        "Exclusão de Itens",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Exclamation);

            //    return;
            //}

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir o item {disciplina.nome}?",
                "Exclusão de Disciplina",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioDisciplina.Excluir(disciplina);

                CarregarDisciplinas();
            }
        }
        public override UserControl ObterListagem()
        {
            if (tabelaDisciplina == null)
                tabelaDisciplina = new TabelaDisciplinaControl();

            CarregarDisciplinas();

            return tabelaDisciplina;
        }
        public override string ObterTipoCadastro()
        {
            return "Cadastro de Disciplinas";
        }
        private void CarregarDisciplinas()
        {
            List<Disciplina> disciplinas = repositorioDisciplina.SelecionarTodos();

            tabelaDisciplina.AtualizarRegistros(disciplinas);
        }
        private Disciplina ObterDisciplinaSelecionada()
        {
            int id = tabelaDisciplina.ObterNumeroDisciplinaSelecionado();

            return repositorioDisciplina.SelecionarPorId(id);
        }

    }
}

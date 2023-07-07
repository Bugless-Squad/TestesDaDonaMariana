using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Dominio.ModuloTeste;

namespace TestesDaDonaMariana.WinApp.ModuloMateria
{
    public class ControladorMateria : ControladorBase
    {
        IRepositorioDisciplina repositorioDisciplina;
        IRepositorioMateria repositorioMateria;
        IRepositorioTeste repositorioTeste;
        TabelaMateriaControl tabelaMaterias;

        public ControladorMateria(IRepositorioMateria repositorioMateria, IRepositorioDisciplina repositorioDisciplina)
        {
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioMateria = repositorioMateria;

        }
        public override string ToolTipInserir => "Cadastrar Matéria";
        public override string ToolTipEditar => "Editar Matéria Existente";
        public override string ToolTipExcluir => "Excluir Matéria Existente";
        public override string ToolTipHome => "Voltar a tela inicial";

        public override bool HomeHabilitado => true;
        public override bool InserirHabilitado => true;
        public override bool EditarHabilitado => true;
        public override bool ExcluirHabilitado => true;

        public override void Inserir()
        {
            TelaMateriaForm tela = new(repositorioMateria.SelecionarTodos(), repositorioDisciplina.SelecionarTodos());

            if (tela.ShowDialog() == DialogResult.OK)
            {
                Materia materia = tela.ObterMateria();

                materia.disciplina.materias.Add(materia);

                repositorioMateria.Inserir(materia);

                CarregarMaterias();
            }
        }

        public override void Editar()
        {
            Materia materiaSelecionada = ObterMateriaSelecionado();

            if (materiaSelecionada == null)
            {
                MessageBox.Show($"Selecione a Materia primeiro!",
                    "Edição da Materia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            TelaMateriaForm tela = new(repositorioMateria.SelecionarTodos(), repositorioDisciplina.SelecionarTodos());

            tela.ConfigurarTela(materiaSelecionada);

            DialogResult opcaoEscolhida = tela.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Materia materia = tela.ObterMateria();

                materia.disciplina.materias.Remove(materiaSelecionada);

                materia.disciplina.materias.Add(materia);

                repositorioMateria.Editar(materiaSelecionada, materia);

                CarregarMaterias();
            }
        }

        public override void Excluir()
        {
            Materia materia = ObterMateriaSelecionado();

            if (materia == null)
            {
                MessageBox.Show($"Selecione uma matéria primeiro!",
                    "Exclusão de Materias",
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

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir o item {materia.titulo}?",
                "Exclusão de Materia",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioMateria.Excluir(materia);

                CarregarMaterias();
            }
        }

        public override UserControl ObterListagem()
        {
            if (tabelaMaterias == null)
                tabelaMaterias = new TabelaMateriaControl();

            CarregarMaterias();

            return tabelaMaterias;
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Materias";
        }    

        private void CarregarMaterias()
        {
            List<Materia> materias = repositorioMateria.SelecionarTodos();

            tabelaMaterias.AtualizarRegistros(materias);
        }

        private Materia ObterMateriaSelecionado()
        {
            int id = tabelaMaterias.ObterNumeroItemSelecionado();

            return repositorioMateria.SelecionarPorId(id);
        }
    }
}

﻿using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Dominio.ModuloTeste;

namespace TestesDaDonaMariana.WinApp.ModuloMateria
{
    public class ControladorMateria : ControladorBase
    {
        //IRepositorioDisciplina repositorioDisciplina;
        IRepositorioMateria repositorioMateria;
        IRepositorioTeste repositorioTeste;
        TabelaMateriaControl tabelaMaterias;

        public ControladorMateria(  IRepositorioMateria repositorioMateria)
        {
          //this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioMateria = repositorioMateria;

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
            TelaMateriaForm telaMateria = new TelaMateriaForm();
            DialogResult opcaoEscolhida = telaMateria.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Materia materia = telaMateria.ObterMateria();
                repositorioMateria.Inserir(materia);

                CarregarMaterias();
            }
        }

        public override void Editar()
        {
            Materia materiaSelecionads = ObterMateriaSelecionado();

            if (materiaSelecionads == null)
            {
                MessageBox.Show($"Selecione a Materia primeiro!",
                    "Edição da Materia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
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

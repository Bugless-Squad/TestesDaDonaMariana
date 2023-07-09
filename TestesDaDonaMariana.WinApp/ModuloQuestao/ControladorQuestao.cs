﻿using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloQuestao;

namespace TestesDaDonaMariana.WinApp.ModuloQuestao
{
    public class ControladorQuestao : ControladorBase
    {
        private IRepositorioQuestao repositorioQuestao;
        private IRepositorioDisciplina repositorioDisciplina;
        private TabelaQuestaoControl tabelaQuestao;

        public ControladorQuestao(IRepositorioQuestao repositorioQuestao, IRepositorioDisciplina repositorioDisciplina)
        {
            this.repositorioQuestao = repositorioQuestao;
            this.repositorioDisciplina = repositorioDisciplina;
        }

        public override string ToolTipInserir => "Cadastrar Questão";
        public override string ToolTipEditar => "Editar Questão Existente";
        public override string ToolTipExcluir => "Excluir Questão Existente";
        public override string ToolTipHome => "Voltar a tela inicial";

        public override bool HomeHabilitado => true;
        public override bool InserirHabilitado => true;
        public override bool EditarHabilitado => true;
        public override bool ExcluirHabilitado => true;

        public override void Inserir()
        {
            TelaQuestaoForm tela = new(repositorioQuestao.SelecionarTodos(), repositorioDisciplina.SelecionarTodos());

            if (tela.ShowDialog() == DialogResult.OK)
            {
                Questao questao = tela.ObterQuestao();

                questao.materia.questoes.Add(questao);

                repositorioQuestao.Inserir(questao);

                CarregarQuestoes();
            }
        }

        public override void Editar()
        {
            Questao questaoSelecionada = ObterQuestãoSelecionada();

            if (questaoSelecionada == null)
            {
                MessageBox.Show($"Selecione um questao primeiro!",
                    "Edição de clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            TelaQuestaoForm tela = new(repositorioQuestao.SelecionarTodos(), repositorioDisciplina.SelecionarTodos());

            tela.ConfigurarTelaEdicao(questaoSelecionada);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                Questao questao = tela.ObterQuestao();

                questao.materia.questoes.Remove(questaoSelecionada);

                questao.materia.questoes.Add(questao);

                repositorioQuestao.Editar(questaoSelecionada, questao);

                CarregarQuestoes();
            }
        }

        public override void Excluir()
        {
            Questao questaoSelecionada = ObterQuestãoSelecionada();

            if (questaoSelecionada == null)
            {
                MessageBox.Show($"Selecione um questao primeiro!",
                    "Exclusão de Questões",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }
            //if (repositorioQuestao.SelecionarTodos().Any(x => x. == questoes))
            //{
            //    MessageBox.Show($"Não é possivel remover esse questao pois ele possuí vinculo com ao menos um Aluguel!",
            //        "Exclusão de clientes",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Exclamation);

            //    return;
            //}

            DialogResult opcaoEscolhida = MessageBox.Show(
                $"Deseja excluir o questao {questaoSelecionada.id}?", 
                "Exclusão de Questóes",
                MessageBoxButtons.OKCancel, 
                MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioQuestao.Excluir(questaoSelecionada);

                CarregarQuestoes();
            }
        }

        private void CarregarQuestoes()
        {
            List<Questao> questoes = repositorioQuestao.SelecionarTodos();

            tabelaQuestao.AtualizarRegistros(questoes);
        }

        private Questao ObterQuestãoSelecionada()
        {
            int id = tabelaQuestao.ObterNumeroClienteSelecionado();

            return repositorioQuestao.SelecionarPorId(id);
        }

        public override UserControl ObterListagem()
        {
            if (tabelaQuestao == null)
                tabelaQuestao = new TabelaQuestaoControl();

            CarregarQuestoes();

            return tabelaQuestao;
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Questões";
        }
    }
}

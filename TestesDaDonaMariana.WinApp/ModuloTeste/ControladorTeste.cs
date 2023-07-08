﻿using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Dominio.ModuloTeste;
using TestesDaDonaMariana.WinApp.ModuloMateria;

namespace TestesDaDonaMariana.WinApp.ModuloTeste
{
    public class ControladorTeste : ControladorBase
    {
        IRepositorioTeste repositorioTeste;

        public ControladorTeste(IRepositorioTeste repositorioTeste)
        {
            this.repositorioTeste = repositorioTeste;
        }

        public override string ToolTipInserir => "Cadastrar Teste";
        public override string ToolTipEditar => "Duplicar Teste Existente";
        public override string ToolTipExcluir => "Excluir Teste Existente";
        public override string ToolTipHome => "Voltar a tela inicial";

        public override bool HomeHabilitado => true;
        public override bool InserirHabilitado => true;
        public override bool EditarHabilitado => true;
        public override bool ExcluirHabilitado => true;

        public override void Inserir()
        {
            TelaTesteForm telaTeste = new();

            if (telaTeste.ShowDialog() == DialogResult.OK)
            {
                //Teste teste = telaTeste.ObterTeste();
                //repositorioTeste.Inserir(teste);

                CarregarTeste();
            }
        }

        private void CarregarTeste()
        {
            throw new NotImplementedException();
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }       

        public override UserControl ObterListagem()
        {
            throw new NotImplementedException();
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Testes";
        }
    }
}

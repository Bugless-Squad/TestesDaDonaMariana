using TestesDaDonaMariana.Dominio.ModuloMateria;
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

        public override string ToolTipInserir => "Realizar adição de Teste";

       // public override string ToolTipEditar => "Editar Matéria Existente";
       // public override string ToolTipDuplicar => "Duplicar Teste Existente";

        public override string ToolTipExcluir => "Excluir Matéria Existente";

        public override string ToolTipHome => "Voltar a tela inicial";

        public override bool HomeHabilitado => true;
        public override bool InserirHabilitado => true;
     //   public override bool EditarHabilitado => true;
        public override bool ExcluirHabilitado => true;

        public override void Inserir()
        {
            TelaCadastroTesteForm telaTeste = new TelaCadastroTesteForm();
            DialogResult opcaoEscolhida = telaTeste.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Teste teste = telaTeste.ObterTeste();
                repositorioTeste.Inserir(teste);

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
            throw new NotImplementedException();
        }
    }
}

namespace TestesDaDonaMariana.WinApp.ModuloMateria
{
    public class ControladorMateria : ControladorBase
    {
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

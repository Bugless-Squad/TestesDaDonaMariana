namespace TestesDaDonaMariana.WinApp.Compartilhado
{
    public abstract class ControladorBase
    {
        public abstract string ToolTipInserir { get; }

        public abstract string ToolTipEditar { get; }

        public abstract string ToolTipExcluir { get; }

        public abstract string ToolTipHome { get; }

        public virtual string? ToolTipFiltrar { get { return "Filtro indisponível"; } }

        public virtual string? ToolTipAdicionarItens { get { return "Adição indisponível"; } }

        public virtual string? ToolTipRemoverItens { get { return "Conclusão indisponível"; } }

        public virtual string? ToolTipFinalizarPagamento { get { return "Finalizar pagamento indisponível"; } }

        public virtual string? ToolTipConfigDesconto { get { return "Configurar desconto indisponível"; } }

        public virtual string? ToolTipVisualizar { get { return "Visualizar indisponível"; } }

        public virtual bool InserirHabilitado { get { return false; } }
        public virtual bool EditarHabilitado { get { return false; } }
        public virtual bool ExcluirHabilitado { get { return false; } }
        public virtual bool HomeHabilitado { get { return false; } }
        public virtual bool FiltrarHabilitado { get { return false; } }
        public virtual bool AdicionarItensHabilitado { get { return false; } }
        public virtual bool RemoverItensHabilitado { get { return false; } }
        public virtual bool FinalizarPagamentoHabilitado { get { return false; } }
        public virtual bool ConfigDescontoHabilitado { get { return false; } }
        public virtual bool VisualizarHabilitado { get { return false; } }

        public virtual bool InserirVisivel { get { return true; } }
        public virtual bool EditarVisivel { get { return true; } }
        public virtual bool ExcluirVisivel { get { return true; } }
        public virtual bool HomeVisivel {get {return true;} }
        public virtual bool FiltrarVisivel { get { return false; } }
        public virtual bool AdicionarItensVisivel { get { return false; } }
        public virtual bool RemoverItensVisivel { get { return false; } }
        public virtual bool FinalizarPagamentoVisivel { get { return false; } }
        public virtual bool ConfigDescontoVisivel { get { return false; } }
        public virtual bool VisualizarVisivel { get { return false; } }

        public virtual bool SeparadorVisivel0 { get { return true; } }
        public virtual bool SeparadorVisivel1 { get { return false; } }
        public virtual bool SeparadorVisivel2 { get { return false; } }
        public virtual bool SeparadorVisivel3 { get { return false; } }
        public virtual bool SeparadorVisivel4 { get { return false; } }
        public virtual bool SeparadorVisivel5 { get { return true; } }

        public abstract void Inserir();

        public abstract void Editar();

        public abstract void Excluir();

        public virtual void Filtrar() { }

        public virtual void AdicionarItens() { }

        public virtual void RemoverItens() { }

        public virtual void FinalizarPagamento() { }

        public virtual void ConfigurarDesconto() { }

        public virtual void Visualizar() { }

        public virtual void Home() { }

        public abstract UserControl ObterListagem();

        public abstract string ObterTipoCadastro();

    }
}

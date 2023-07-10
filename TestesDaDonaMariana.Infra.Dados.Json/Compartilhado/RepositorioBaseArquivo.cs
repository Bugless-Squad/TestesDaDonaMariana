
namespace TestesDaDonaMariana.Infra.Dados.Json.Compartilhado
{
    public abstract class RepositorioBaseArquivo<T> where T : EntidadeBase<T>
    {
        protected ContextoDeDados contextoDeDados { get; set; }
        int idContador = 0;

        public RepositorioBaseArquivo(ContextoDeDados contexto)
        {
            contextoDeDados = contexto;
        }

        protected abstract List<T> ObterRegistros();

        public void Inserir(T novoRegistro)
        {
            List<T> registros = ObterRegistros();

            AtualizarContador();
            idContador++;
            novoRegistro.id = idContador;
            registros.Add(novoRegistro);

            contextoDeDados.GravarEmArquivoJson();
        }

        public void Editar(int id, T registroAtualizado)
        {
            T registroSelecionado = SelecionarPorId(id);

            registroSelecionado.AtualizarInformacoes(registroAtualizado);

            contextoDeDados.GravarEmArquivoJson();
        }

        public virtual void Editar(T registroSelecionado, T registroAtualizado)
        {
            registroSelecionado.AtualizarInformacoes(registroAtualizado);

            contextoDeDados.GravarEmArquivoJson();
        }

        public void Excluir(T registroSelecionado)
        {
            List<T> registros = ObterRegistros();

            registros.Remove(registroSelecionado);

            contextoDeDados.GravarEmArquivoJson();
        }

        public T SelecionarPorId(int id)
        {
            List<T> registros = ObterRegistros();

            return registros.FirstOrDefault(x => x.id == id);
        }

        public List<T> SelecionarTodos()
        {
            return ObterRegistros();
        }

        private void AtualizarContador()
        {
            if (ObterRegistros().Count > 0)
                idContador = ObterRegistros().Max(x => x.id);
        }
    }
}

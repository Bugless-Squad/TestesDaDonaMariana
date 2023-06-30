
namespace TestesDaDonaMariana.Dominio.Compartilhado
{
    public interface IRepositorio<T> where T : EntidadeBase<T>
    {
        void Inserir(T novoRegistro);

        void Editar(T registroSelecionado, T registroAtualizado);

        void Editar(int id, T registro);

        void Excluir(T registro);

        List<T> SelecionarTodos();

        T SelecionarPorId(int id);
    }
}

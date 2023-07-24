using TestesDaDonaMariana.Dominio.ModuloQuestao;

namespace TestesDaDonaMariana.Dominio.ModuloMateria
{
    public interface IRepositorioMateria : IRepositorio<Materia>
    {
        Materia SelecionarPorNome(string nome);
    }
}

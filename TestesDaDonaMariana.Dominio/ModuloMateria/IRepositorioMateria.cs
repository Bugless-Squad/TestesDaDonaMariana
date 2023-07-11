namespace TestesDaDonaMariana.Dominio.ModuloMateria
{
    public interface IRepositorioMateria : IRepositorio<Materia>
    {
        List<Materia> SelecionarMateriasPorDisciplina(int idDisciplina);
    }
}

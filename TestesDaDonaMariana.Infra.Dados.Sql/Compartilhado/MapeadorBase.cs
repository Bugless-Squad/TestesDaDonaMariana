using System.Data.SqlClient;

namespace TestesDaDonaMariana.Infra.Dados.Sql.Compartilhado
{
    public abstract class MapeadorBase<T>
    {
        public abstract void ConfigurarParametros(SqlCommand comando, T registro);
        public abstract T ConverterRegistro(SqlDataReader leitor);
    }
}

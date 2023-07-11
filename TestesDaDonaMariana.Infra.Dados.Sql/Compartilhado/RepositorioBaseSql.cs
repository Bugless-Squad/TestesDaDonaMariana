using System.Data.SqlClient;
using TestesDaDonaMariana.Dominio.Compartilhado;

namespace TestesDaDonaMariana.Infra.Dados.Sql.Compartilhado
{
    public abstract class RepositorioBaseSql<T, TMapeador> 
        where T : EntidadeBase<T>
        where TMapeador : MapeadorBase<T>, new()
    {
        protected string enderecoBanco =
             @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=TestesDonaMarianaBD;Integrated Security=True;Pooling=False";

        protected abstract string sqlInserir { get; }
        protected abstract string sqlEditar { get; }
        protected abstract string sqlExcluir { get; }
        protected abstract string sqlSelecionarPorId { get; }
        protected abstract string sqlSelecionarTodos { get; }

        public virtual void Inserir(T novoRegistro)
        {
            SqlConnection conexaoComBanco = new(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoInserir = conexaoComBanco.CreateCommand();
            comandoInserir.CommandText = sqlInserir;

            TMapeador mapeador = new();

            mapeador.ConfigurarParametros(comandoInserir, novoRegistro);
            
            object id = comandoInserir.ExecuteScalar();
            novoRegistro.id = Convert.ToInt32(id);

            conexaoComBanco.Close();
        }

        public virtual void Editar(int id, T registroSelecionado)
        {
            SqlConnection conexaoComBanco = new(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoEditar = conexaoComBanco.CreateCommand();
            comandoEditar.CommandText = sqlEditar;

            TMapeador mapeador = new();

            mapeador.ConfigurarParametros(comandoEditar, registroSelecionado);

            comandoEditar.ExecuteNonQuery();

            conexaoComBanco.Close();
        }

        public virtual void Excluir(T registroSelecionado)
        {
            SqlConnection conexaoComBanco = new(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoExcluir = conexaoComBanco.CreateCommand();
            comandoExcluir.CommandText = sqlExcluir;

            comandoExcluir.Parameters.AddWithValue("ID", registroSelecionado.id);

            comandoExcluir.ExecuteNonQuery();

            conexaoComBanco.Close();
        }

        public virtual T SelecionarPorId(int id)
        {
            SqlConnection conexaoComBanco = new(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoSelecionarPorId = conexaoComBanco.CreateCommand();
            comandoSelecionarPorId.CommandText = sqlSelecionarPorId;

            comandoSelecionarPorId.Parameters.AddWithValue("ID", id);

            SqlDataReader leitor = comandoSelecionarPorId.ExecuteReader();

            T registro = null;

            TMapeador mapeador = new();

            if (leitor.Read())
                registro = mapeador.ConverterRegistro(leitor);

            conexaoComBanco.Close();

            return registro;
        }

        public virtual List<T> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoSelecionarTodos = conexaoComBanco.CreateCommand();
            comandoSelecionarTodos.CommandText = sqlSelecionarTodos;

            SqlDataReader leitorItens = comandoSelecionarTodos.ExecuteReader();

            List<T> registros = new();

            TMapeador mapeador = new();

            while (leitorItens.Read())
            {
                T registro = mapeador.ConverterRegistro(leitorItens);

                registros.Add(registro);
            }

            conexaoComBanco.Close();

            return registros;
        }
    }
}

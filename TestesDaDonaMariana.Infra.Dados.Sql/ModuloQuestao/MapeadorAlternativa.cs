using System.Data.SqlClient;
using TestesDaDonaMariana.Dominio.ModuloQuestao;

namespace TestesDaDonaMariana.Infra.Dados.Sql.ModuloQuestao
{
    public class MapeadorAlternativa : MapeadorBase<Alternativa>
    {
        public override void ConfigurarParametros(SqlCommand comando, Alternativa registro)
        {
            comando.Parameters.AddWithValue("@ID", registro.id);
            comando.Parameters.AddWithValue("@IDLETRA", registro.idLetra);
            comando.Parameters.AddWithValue("@TEXTO", registro.texto);
            comando.Parameters.AddWithValue("@ALTERNATIVACORRETA", (string)registro.alternativaCorreta);
        }

        public override Alternativa ConverterRegistro(SqlDataReader leitor)
        {
            int id = Convert.ToInt32(leitor["ALTERNATIVA_ID"]);
            string idLetra = Convert.ToString(leitor["ALTERNATIVA_IDLETRA"]);
            string texto = Convert.ToString(leitor["ALTERNATIVA_TEXTO"]);
            string alternativaCorreta = Convert.ToString(leitor["ALTERNATIVA_ALTERNATIVACORRETA"]);

            Alternativa alternativa = new();
            alternativa.id = id;
            alternativa.idLetra = idLetra;
            alternativa.texto = texto;
            alternativa.alternativaCorreta = alternativaCorreta;

            return alternativa;
        }
    }
}

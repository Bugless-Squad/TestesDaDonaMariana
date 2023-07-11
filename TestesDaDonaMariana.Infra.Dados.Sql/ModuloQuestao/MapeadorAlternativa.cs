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
            comando.Parameters.AddWithValue("@ALTERNATIVACORRETA", registro.alternativaCorreta.ToString());
        }

        public override Alternativa ConverterRegistro(SqlDataReader leitor)
        {
            int id = Convert.ToInt32(leitor["ID"]);
            string idLetra = Convert.ToString(leitor["IDLETRA"]);
            string texto = Convert.ToString(leitor["TEXTO"]);
            AlternativaCorretaEnum alternativaCorreta = (AlternativaCorretaEnum)Enum.Parse(typeof(AlternativaCorretaEnum), Convert.ToString(leitor["ALTERNATIVACORRETA"]));

            return new Alternativa(id, idLetra, texto, alternativaCorreta);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Dominio.ModuloQuestao;
using TestesDaDonaMariana.Infra.Dados.Sql.ModuloMateria;

namespace TestesDaDonaMariana.Infra.Dados.Sql.ModuloQuestao
{
    public class MapeadorQuestao : MapeadorBase<Questao>
    {
        public override void ConfigurarParametros(SqlCommand comando, Questao registro)
        {
            comando.Parameters.AddWithValue("@ID", registro.id);
            comando.Parameters.AddWithValue("@MATERIA_ID", registro.materia.id);
            comando.Parameters.AddWithValue("@ENUNCIADO", registro.enunciado);
            comando.Parameters.AddWithValue("@RESPOSTACERTA", registro.alternativaCorreta);
        }
        public override Questao ConverterRegistro(SqlDataReader leitor)
        {
            int id = Convert.ToInt32(leitor["QUESTAO_ID"]);
            string enunciado = Convert.ToString(leitor["QUESTAO_ENUNCIADO"])!;
            string alternativaCorreta = Convert.ToString(leitor["QUESTAO_RESPOSTA"])!;

            Materia materia = new MapeadorMateria().ConverterRegistro(leitor);

            return new Questao(id, materia, enunciado, alternativaCorreta);
        }
        public Alternativa ConverterParaAlternativa(SqlDataReader leitorAlternativa)
        {
            int id = Convert.ToInt32(leitorAlternativa["ALTERNATIVA_ID"]);
            string resposta = Convert.ToString(leitorAlternativa["ALTERNATIVA_RESPOSTA"]);
            bool correta = Convert.ToBoolean(leitorAlternativa["ALTERNATIVA_VERDADEIRO"]);

            Questao questao = ConverterRegistro(leitorAlternativa);

            return new Alternativa();
        }
    }
}

using System.Data.SqlClient;
using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Dominio.ModuloQuestao;
using TestesDaDonaMariana.Infra.Dados.Sql.ModuloDisciplina;
using TestesDaDonaMariana.Infra.Dados.Sql.ModuloMateria;

namespace TestesDaDonaMariana.Infra.Dados.Sql.ModuloQuestao
{
    public class MapeadorQuestao : MapeadorBase<Questao>
    {
        public override void ConfigurarParametros(SqlCommand comando, Questao questao)
        {
            comando.Parameters.AddWithValue("@ID", questao.id);
            comando.Parameters.AddWithValue("@ENUNCIADO", questao.enunciado);
            comando.Parameters.AddWithValue("@DISCIPLINA_ID", questao.disciplina.id);
            comando.Parameters.AddWithValue("@MATERIA_ID", questao.materia.id);
            comando.Parameters.AddWithValue("@ALTERNATIVACORRETA_ID", questao.alternativaCorreta?.id);
        }

        public override Questao ConverterRegistro(SqlDataReader leitor)
        {
            int id = Convert.ToInt32(leitor["QUESTAO_ID"]);
            string enunciado = Convert.ToString(leitor["QUESTAO_ENUNCIADO"]);
            int? alternativaCorretaId = leitor["ALTERNATIVACORRETA_ID"] as int?;

            Disciplina disciplina = new MapeadorDisciplina().ConverterRegistroId(leitor);
            Materia materia = new MapeadorMateria().ConverterRegistroId(leitor);
            Alternativa alternativaCorreta = alternativaCorretaId.HasValue ? new RepositorioAlternativaSql().SelecionarPorId(alternativaCorretaId.Value) : null;

            return new Questao(id, enunciado, disciplina, materia, alternativaCorreta);
        }

        public Questao ConverterRegistroComMateria(SqlDataReader leitor)
        {
            int id = Convert.ToInt32(leitor["QUESTAO_ID"]);
            string enunciado = Convert.ToString(leitor["QUESTAO_ENUNCIADO"]);
            int? alternativaCorretaId = leitor["ALTERNATIVACORRETA_ID"] as int?;

            Disciplina disciplina = new MapeadorDisciplina().ConverterRegistroId(leitor);
            Materia materia = new MapeadorMateria().ConverterRegistroId(leitor);
            Alternativa alternativaCorreta = alternativaCorretaId.HasValue ? new RepositorioAlternativaSql().SelecionarPorId(alternativaCorretaId.Value) : null;

            return new Questao(id, enunciado, disciplina, materia, alternativaCorreta);
        }
    }
}

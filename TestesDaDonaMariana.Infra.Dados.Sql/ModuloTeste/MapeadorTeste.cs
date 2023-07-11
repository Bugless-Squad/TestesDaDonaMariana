using System.Data.SqlClient;
using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Dominio.ModuloQuestao;
using TestesDaDonaMariana.Dominio.ModuloTeste;
using TestesDaDonaMariana.Infra.Dados.Sql.ModuloDisciplina;
using TestesDaDonaMariana.Infra.Dados.Sql.ModuloMateria;
using TestesDaDonaMariana.Infra.Dados.Sql.ModuloQuestao;

namespace TestesDaDonaMariana.Infra.Dados.Sql.ModuloTeste
{
    public class MapeadorTeste : MapeadorBase<Teste>
    {
        public override void ConfigurarParametros(SqlCommand comando, Teste registro)
        {
            comando.Parameters.AddWithValue("@ID", registro.id);
            comando.Parameters.AddWithValue("@TITULO", registro.titulo);
            comando.Parameters.AddWithValue("@NUMQUESTOES", registro.numQuestoes);
            comando.Parameters.AddWithValue("@DATACRIACAO", registro.dataCriacao);
            comando.Parameters.AddWithValue("@DISCIPLINA_ID", registro.disciplina.id);
        }

        public override Teste ConverterRegistro(SqlDataReader leitor)
        {
            int id = Convert.ToInt32(leitor["TESTE_ID"]);
            string titulo = Convert.ToString(leitor["TESTE_TITULO"]);
            int numQuestoes = Convert.ToInt32(leitor["TESTE_NUMQUESTOES"]);
            DateTime dataCriacao = Convert.ToDateTime(leitor["TESTE_DATACRIACAO"]);

            Disciplina disciplina = new MapeadorDisciplina().ConverterRegistro(leitor);
            List<Materia> materias = new MapeadorMateria().SelecionarMateriasPorTeste(id);
            List<Questao> questoes = new MapeadorQuestao().SelecionarQuestoesPorTeste(id);

            Teste teste = new Teste();
            teste.id = id;
            teste.titulo = titulo;
            teste.numQuestoes = numQuestoes;
            teste.dataCriacao = dataCriacao;
            teste.disciplina = disciplina;
            teste.materias = materias;
            teste.questoes = questoes;

            return teste;
        }
    }
}

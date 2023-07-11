using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDaDonaMariana.Dominio.ModuloDisciplina;
using TestesDaDonaMariana.Dominio.ModuloMateria;
using TestesDaDonaMariana.Dominio.ModuloTeste;
using TestesDaDonaMariana.Infra.Dados.Sql.ModuloDisciplina;
using TestesDaDonaMariana.Infra.Dados.Sql.ModuloMateria;

namespace TestesDaDonaMariana.Infra.Dados.Sql.ModuloTeste
{
    public class MapeadorTeste : MapeadorBase<Teste>
    {
        public override void ConfigurarParametros(SqlCommand comando, Teste registro)
        {
            Materia materia = new();

            if (registro.materias.Count > 1)
            {
                materia.titulo = "Todas";
                materia.id = registro.materias.Max(x=>x.id+1);
            }    
            else 
                materia = registro.materias.FirstOrDefault(x => x == registro.materias[0]);
               

            comando.Parameters.AddWithValue("@ID", registro.id);
            comando.Parameters.AddWithValue("@TITULO", registro.titulo);
            comando.Parameters.AddWithValue("@DISCIPLINA_ID", registro.disciplina.id);
            comando.Parameters.AddWithValue("@MATERIA_ID", materia.id);
            comando.Parameters.AddWithValue("@QUANTIDADEQUESTOES", registro.numQuestoes);
        }

        public override Teste ConverterRegistro(SqlDataReader leitor)
        {
            int id = Convert.ToInt32(leitor["TESTE_ID"]);
            string titulo = Convert.ToString(leitor["TESTE_TITULO"]);
            int numQuestoes = Convert.ToInt32(leitor["TESTE_QUANTIDADEQUESTOES"]);

            Disciplina disciplina = new MapeadorDisciplina().ConverterRegistro(leitor);

            Materia materias = new MapeadorMateria().ConverterRegistro(leitor);

            return new Teste(id, titulo, disciplina, materias, numQuestoes);

        }
    }
}

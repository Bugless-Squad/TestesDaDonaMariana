using TestesDaDonaMariana.Dominio.ModuloTeste;

namespace TestesDaDonaMariana.Infra.Dados.Sql.ModuloTeste
{
    public class RepositorioTesteSql : RepositorioBaseSql<Teste, MapeadorTeste>, IRepositorioTeste
    {
        protected override string sqlInserir => @"INSERT INTO [TBTESTE] 
                                                ([titulo], [quantidadeQuestoes], [dataCriacao], [disciplina_id],[matricula_id])
                                              VALUES 
                                                (@TITULO, @NUMQUESTOES, @DATACRIACAO, @DISCIPLINA_ID, @MATRICULA_ID);                  
                                              SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar => @"UPDATE [TBTESTE] 
                                             SET
                                                [titulo] = @TITULO,
                                                [QuantidadeQuestoes] = @NUMQUESTOES,
                                                [dataCriacao] = @DATACRIACAO,
                                                [disciplina_id] = @DISCIPLINA_ID,
                                                [matricula_id] = @MATRICULA_ID
                                             WHERE
                                                [id] = @ID";

        protected override string sqlExcluir => @"DELETE FROM [TBTESTE]
                                              WHERE 
                                                [id] = @ID";

        protected override string sqlSelecionarTodos => @"SELECT 
                                                        [id] AS TESTE_ID,
                                                        [titulo] AS TESTE_TITULO,
                                                        [QuantidadeQuestoes] AS TESTE_NUMQUESTOES,
                                                        [dataCriacao] AS TESTE_DATACRIACAO,
                                                        [disciplina_id] AS DISCIPLINA_ID,
                                                        [matricula_id] AS MATRICULA_ID
                                                      FROM 
                                                        [TBTESTE]";

        protected override string sqlSelecionarPorId => @"SELECT 
                                                        [id] AS TESTE_ID,
                                                        [titulo] AS TESTE_TITULO,
                                                        [QuantidadeQuestoes] AS TESTE_NUMQUESTOES,
                                                        [dataCriacao] AS TESTE_DATACRIACAO,
                                                        [disciplina_id] AS DISCIPLINA_ID
                                                        [matricula_id] AS MATRICULA_ID
                                                      FROM 
                                                        [TBTESTE]
                                                      WHERE 
                                                        [id] = @ID";

        public override List<Teste> SelecionarTodos()
        {
            List<Teste> testes = base.SelecionarTodos();

            return testes;
        }

        public override Teste SelecionarPorId(int id)
        {
            Teste teste = base.SelecionarPorId(id);

            return teste;
        }
    }
}

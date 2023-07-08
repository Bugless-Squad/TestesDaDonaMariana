
using TestesDaDonaMariana.Dominio.ModuloMateria;

namespace TestesDaDonaMariana.Dominio.ModuloDisciplina
{
    [Serializable]
    public class Disciplina : EntidadeBase<Disciplina>
    {
        public string nome { get; set; }

        public List<Materia> materias { get; set; }
        public Disciplina()
        {
            
        }

        public Disciplina(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }

        public override void AtualizarInformacoes(Disciplina registroAtualizado)
        {
            nome = registroAtualizado.nome;
        }

        public override string Validar()
        {
            Validador valida = new();

            if (valida.ValidaString(nome))
                return $"Você deve escrever uma disciplina!";

            if (nome.Length <= 4)
                return $"O titulo deve conter no mínimo 5 caracteres!";

            return "";
        }

        public override string ToString()
        {
            return nome;
        }
    }
}

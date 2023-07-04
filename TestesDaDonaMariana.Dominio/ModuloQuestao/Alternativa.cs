using System.Web;

namespace TestesDaDonaMariana.Dominio.ModuloQuestao
{
    public class Alternativa
    {
        public string texto { get; set; }

        public Alternativa()
        {
            
        }

        public Alternativa(string texto)
        {
            this.texto = texto; 
        }
    }
}

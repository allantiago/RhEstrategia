using RE.Core.DomainObjects;

namespace RE.Pessoas.API.Models
{
    public class Endereco : Entity
    {
        public Endereco(string cep, string estado, string cidade, string numero, string logradouro)
        {
            CEP = cep;
            Estado = estado;
            Cidade = cidade;
            Logradouro = logradouro;
            Numero = numero;
        }

        public Endereco() { }

        public string CEP { get; private set; }

        public string Estado { get; private set; }

        public string Numero { get; private set; }
        public string Cidade { get; private set; }

        public string Logradouro { get; private set; }

        public Guid PessoaId { get; private set; }

        public Pessoa Pessoa { get; set; }
        
    }
}

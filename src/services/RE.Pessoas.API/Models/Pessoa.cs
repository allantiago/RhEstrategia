using RE.Core.DomainObjects;

namespace RE.Pessoas.API.Models
{
    public class Pessoa : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }

        public string Sobrenome { get; private set; }

        public Cpf Cpf { get; private set; }

        public string Nacionalidade { get; private set; }

        public Email Email { get; private set; }

        public string Telefone { get; private set; }

        public bool Ativo { get; private set; }

        public Endereco Endereco { get; private set; }

        //EF relation
        protected Pessoa()
        {

        }

        public Pessoa(Guid id, string nome, string sobrenome,string cpf, string nacionalidade, string email, string telefone)
        {
            Id = id;
            Nome = nome;
            Cpf = new Cpf(cpf);
            Sobrenome = sobrenome;
            Nacionalidade = nacionalidade;
            Email = new Email(email);           
            Telefone = telefone;
            Ativo = true;

        }

        public void UpdateEmail (string email)
        {
            Email = new Email(email);
        }

        public void AddEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }
    }
}

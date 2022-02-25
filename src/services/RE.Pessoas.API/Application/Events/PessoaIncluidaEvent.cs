using RE.Core.Messages;

namespace RE.Pessoas.API.Application.Events
{
    public class PessoaIncluidaEvent : Event
    {
        public Guid Id { get; set; }
        public string Nome { get; private set; }

        public string Sobrenome { get; private set; }

        public string Cpf { get; private set; }

        public string Nacionalidade { get; private set; }

        public string Email { get; private set; }

        public string Telefone { get; private set; }

        public bool Ativo { get; private set; }

        public PessoaIncluidaEvent(Guid id, string nome, string sobrenome, string cpf, string nacionalidade, string email, string telefone, bool ativo)
        {
            AggregateId = id;
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            Nacionalidade = nacionalidade;
            Email = email;
            Telefone = telefone;
            Ativo = ativo;
        }
    }
}

using FluentValidation;
using RE.Core.Messages;

namespace RE.Pessoas.API.Application.Commands
{
    public class IncluirPessoaCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; private set; }

        public string Sobrenome { get; private set; }

        public string Cpf { get; private set; }

        public string Nacionalidade { get; private set; }

        public string Email { get; private set; }

        public string Telefone { get; private set; }

        public bool Ativo { get; private set;}

        public IncluirPessoaCommand(Guid id, string nome, string sobrenome, string cpf, string nacionalidade, string email, string telefone)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            Nacionalidade = nacionalidade;
            Email = email;
            Telefone = telefone;
            Ativo = true;
        }
        public override bool Valido()
        {
            ValidationResult = new IncluirPessoaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }    

    public class IncluirPessoaValidation : AbstractValidator<IncluirPessoaCommand>
    {
        public IncluirPessoaValidation()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id não pode ser inválido");

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("Nome inválido");

            RuleFor(c => c.Cpf)
                .Must(CpfValido)
                .WithMessage("CPF inválido");

            RuleFor(c => c.Email)
                .Must(EmailValido)
                .WithMessage("E-mail inválido");
        }

        protected static bool CpfValido(string cpf)
        {
            return Core.DomainObjects.Cpf.ValidaCPF(cpf);
        }

        protected static bool EmailValido(string email)
        {
            return Core.DomainObjects.Email.Validar(email);
        }

    }
}

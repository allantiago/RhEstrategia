using FluentValidation.Results;
using MediatR;
using RE.Core.Messages;
using RE.Pessoas.API.Application.Events;
using RE.Pessoas.API.Models;

namespace RE.Pessoas.API.Application.Commands
{
    public class PessoaCommandHandler : CommandHandler,
        IRequestHandler<IncluirPessoaCommand, ValidationResult>
    {
        private readonly IPessoaRepository _pessoasRepository;

        public PessoaCommandHandler(IPessoaRepository pessoasRepository)
        {
            _pessoasRepository = pessoasRepository;
        }

        public async Task<ValidationResult> Handle(IncluirPessoaCommand message, CancellationToken cancellationToken)
        {
            if (!message.Valido()) return message.ValidationResult;

            var pessoa = new Pessoa(message.Id, message.Nome, message.Sobrenome, message.Cpf, message.Nacionalidade, message.Email,  message.Telefone);

            // Validacoes de negocio
            var pessoaExiste = await _pessoasRepository.ObterPorCpf(pessoa.Cpf.Numero);

            if (pessoaExiste != null)
            {
                AddError("Este CPF já esta cadastrado!");
                return ValidationResult;
            }

            _pessoasRepository.Adicionar(pessoa);

            pessoa.AdicionarEvento(new PessoaIncluidaEvent(message.Id, message.Nome, message.Sobrenome, message.Cpf, message.Nacionalidade, message.Email, message.Telefone, message.Ativo));

            return await PersistData(_pessoasRepository.UnitOfWork);
        }

    }
}

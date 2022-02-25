using MediatR;

namespace RE.Pessoas.API.Application.Events
{
    public class PessoaEventHandler : INotificationHandler<PessoaIncluidaEvent>
    {
        public Task Handle(PessoaIncluidaEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

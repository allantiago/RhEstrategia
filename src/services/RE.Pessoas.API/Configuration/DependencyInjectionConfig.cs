using FluentValidation.Results;
using MediatR;
using RE.Core.Mediator;
using RE.Pessoas.API.Application.Commands;
using RE.Pessoas.API.Application.Events;
using RE.Pessoas.API.Data;
using RE.Pessoas.API.Data.Repository;
using RE.Pessoas.API.Models;

namespace RE.Pessoas.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegistrarService(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<IncluirPessoaCommand, ValidationResult>, PessoaCommandHandler>();

            services.AddScoped<INotificationHandler<PessoaIncluidaEvent>, PessoaEventHandler>();
            
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<PessoaContext>();
            
        }
    }
}

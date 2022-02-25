using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using RE.Core.Mediator;
using RE.Pessoas.API.Application.Commands;

namespace RE.Pessoas.API.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IMediatorHandler _mediatorHandler;

        protected ICollection<string> Erros = new List<string>();

        public PessoaController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("pessoas")]
        public async Task<IActionResult> Index()
        {
            var result = await _mediatorHandler.EnviarComando(
                new IncluirPessoaCommand(Guid.NewGuid(), "Allan", "Tiago", "34901383841", "Brasileiro", "teste@hotmail.com.br", "123498768787"));

            return CustomResponse(result);
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Mensagens", Erros.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                AdicionarErroProcessamento(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected bool OperacaoValida()
        {
            return !Erros.Any();
        }

        protected void AdicionarErroProcessamento(string erro)
        {
            Erros.Add(erro);
        }
    }
}

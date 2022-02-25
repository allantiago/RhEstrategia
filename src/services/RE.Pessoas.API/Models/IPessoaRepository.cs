using RE.Core.DomainObjects;

namespace RE.Pessoas.API.Models
{
    public interface IPessoaRepository : IRepository<Pessoa>
    { 
        void Adicionar(Pessoa pessoa);

        Task<IEnumerable<Pessoa>> ObterTodos();

        Task<Pessoa> ObterPorCpf(string cpf);
    }
}

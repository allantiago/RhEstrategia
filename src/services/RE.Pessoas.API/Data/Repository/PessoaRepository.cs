using Microsoft.EntityFrameworkCore;
using RE.Core.Data;
using RE.Pessoas.API.Models;

namespace RE.Pessoas.API.Data.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly PessoaContext _context;

        public PessoaRepository(PessoaContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Adicionar(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<Pessoa> ObterPorCpf(string cpf)
        {
            return _context.Pessoas.FirstOrDefaultAsync(c => c.Cpf.Numero == cpf);
        }

        public async Task<IEnumerable<Pessoa>> ObterTodos()
        {
            return await _context.Pessoas.AsNoTracking().ToListAsync();
        }
    }
}

using webapi.Context;
using webapi.Models;

namespace webapi.Repository
{
    public class PessoaRepository : IPessoaRepository
    {

        private readonly ApiDbContext _context;

        public PessoaRepository()
        {
            _context = new();        

        }


        public void Add(Pessoa pessoa)
        {
            _context.Pessoa.Add(pessoa);
            _context.SaveChanges();
        }


        public List<Pessoa> Get()
        {
            return _context.Pessoa.ToList();
        }

        public IQueryable<Pessoa> GetById(int id)
        {
            return _context.Pessoa.Where(p => p.PessoaId == id);
        }
       

        public void Delete(int id)
        {
            var pessoa = _context.Pessoa.Find(id);
            _context.Pessoa.Remove(pessoa);
            _context.SaveChanges();
        }

        public void Update(Pessoa pessoa)
        {
            _context.Pessoa.Update(pessoa);
            _context.SaveChanges();
        }
    }
}

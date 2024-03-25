using webapi.Models;

namespace webapi.Interfaces
{
    public interface IPessoaRepository
    {
        void Add(Pessoa pessoa);
               
        void Delete(int id);

        void Update(Pessoa pessoa);

        public IQueryable<Pessoa> GetById(int id);

        public IQueryable<Pessoa> GetPessoasWithTelefone();

    }
}

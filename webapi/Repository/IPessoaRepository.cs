using webapi.Models;

namespace webapi.Repository
{
    public interface IPessoaRepository
    {
        void Add (Pessoa pessoa);

        List<Pessoa> Get ();

        void Delete (int id);

        void Update (Pessoa pessoa);

        public IQueryable<Pessoa> GetById(int id);
    }
}

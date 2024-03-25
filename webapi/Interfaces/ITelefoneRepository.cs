using webapi.Models;

namespace webapi.Interfaces
{
    public interface ITelefoneRepository
    {
        void Add(Telefone telefone);

        void Update(Telefone telefone);

        void Delete(int id);

        List<Telefone> Get();

        public IQueryable<Telefone> GetById(int id);

    }
}

using webapi.Context;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Repository
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private readonly ApiDbContext _context;

        public TelefoneRepository()
        {
            _context = new();
        }

        public void Add(Telefone telefone)
        {
            _context.Telefone.Add(telefone);
            _context.SaveChanges();
        }

        public List<Telefone> Get()
        {
            return _context.Telefone.ToList();
        }

        public IQueryable<Telefone> GetById(int id)
        {
            return _context.Telefone.Where(t => t.TelefoneId == id);
        }

        public void Delete(int id)
        {
            var telefone = _context.Telefone.Find(id);
            if (telefone != null)
            {
                _context.Telefone.Remove(telefone);
                _context.SaveChanges();
            }
            
        }

        public void Update(Telefone telefone)
        {
            _context.Telefone.Update(telefone);
            _context.SaveChanges(); 
        }
    }
}

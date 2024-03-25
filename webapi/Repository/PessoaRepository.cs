using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using webapi.Context;
using webapi.Interfaces;
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

       
        public IQueryable<Pessoa> GetById(int id)
        {
            return _context.Pessoa.Where(p => p.PessoaId == id).Include(p => p.Telefones);
        }

        public IQueryable<Pessoa> GetPessoasWithTelefone()
        {
            return _context.Pessoa.Include(p => p.Telefones);
        }
       

        public void Delete(int id)
        {
            var pessoa = _context.Pessoa.Find(id);
            if (pessoa != null)
            {
                _context.Pessoa.Remove(pessoa);
                _context.SaveChanges();
            }
            
        }

        public void Update(Pessoa pessoa)
        {
            _context.Pessoa.Update(pessoa);
            _context.SaveChanges();
        }


    }
}

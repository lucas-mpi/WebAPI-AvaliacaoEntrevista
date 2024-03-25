using webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace webapi.Context

{
    public class ApiDbContext : DbContext
    {

        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Telefone> Telefone { get; set; }

        
        
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
           
        }

        public ApiDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite(connectionString: "DataSource=app.db");
        
    }

}

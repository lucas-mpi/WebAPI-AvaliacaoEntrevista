using Microsoft.EntityFrameworkCore;
using System.Configuration;
using webapi.Context;
using webapi.Interfaces;
using webapi.Repository;

namespace webapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
           
            

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddTransient<IPessoaRepository, PessoaRepository>();
            builder.Services.AddTransient<ITelefoneRepository, TelefoneRepository>();
            
            builder.Services.AddSqlite<ApiDbContext>(builder.Configuration.GetConnectionString("MinhaConexao"));
            SQLitePCL.Batteries.Init();
         

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

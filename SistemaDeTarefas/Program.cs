using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Repositorios;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // builder.Services.AddEntityFrameworkSqlServer()
            //    .AddDbContext<SistemaTarefasDBContext>(
            //        options => options.UseSqlServer("Server=DESKTOP-I91URTC\\SQLEXPRESS;Database=DB_SistemaTarefas;Trusted_Connection=True;Encrypt=False;")
            //    );

            builder.Services.AddDbContext<SistemaTarefasDBContext> //Conectando da forma nova
                (options => options.UseSqlServer("Server=DESKTOP-I91URTC\\SQLEXPRESS;Database=DB_SistemaTarefas;Trusted_Connection=True;Encrypt=False;"));

            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();


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
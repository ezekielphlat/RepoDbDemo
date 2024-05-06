
using Microsoft.Extensions.Configuration;
using RepoDb;

namespace RepodbDemo
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
            GlobalConfiguration
                .Setup()
                .UseSqlServer();
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddSingleton(new WarehouseRepository(connectionString!));
            builder.Services.AddSingleton<IWarehouseObjectRepo>(new WarehouseObjectRepo(connectionString!));
            builder.Services.AddSingleton<IWarehouseInlineRepo>(new WarehouseInlineRepo(connectionString!));
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


using APIcatalogo.Context;
using APIcatalogo.Extensions;
using APIcatalogo.Filters;
using APIcatalogo.Logging;
using APIcatalogo.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace APIcatalogo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers(options =>
            {

                //FILTRO P TRATAR CONTROLLERS EXEPECTION
                options.Filters.Add(typeof(ApiExceptionFilter));
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<AppDbContext>(options =>
                                options.UseMySql(mySqlConnection,
                                ServerVersion.AutoDetect(mySqlConnection)));
            builder.Services.AddScoped<ApiLoggingFilter>();
            builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            builder.Services.AddScoped<IprodutoRepository, ProdutoRepository>();

            builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
            {
                LogLevel = LogLevel.Information
            }));
          
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.ConfigureExceptionHandler();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

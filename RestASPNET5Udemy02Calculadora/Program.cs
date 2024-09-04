using Microsoft.EntityFrameworkCore;
using RestASPNETErudio.Model.Context;
using RestASPNETErudio.Services.Implementations;

namespace RestASPNETErudio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //var connection = builder.Configuration["MySQLConnectionString"];
            //builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(
            //    connection, new MySqlServerVersion(new Version(8, 0, 29))));

            DataBaseConfig.ConfigureDB(builder);

            //builder.Services.AddDbContext<MySQLContext>(options =>
            //{
            //    var connectionString = builder.Configuration.GetConnectionString("MySQLConnection");
            //    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 29)));
            //});

            builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

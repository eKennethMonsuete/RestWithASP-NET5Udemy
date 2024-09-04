using Microsoft.EntityFrameworkCore;
using RestASPNETErudio.Model.Context;

namespace RestASPNETErudio
{
    public static class DataBaseConfig
    {

        public static void ConfigureDB(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<MySQLContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("MySQLConnection");
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 29)));
            });
        }
    }
}

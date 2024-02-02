using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Repository.Tool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                    {
                        services.AddDbContext<Database.DatabaseContext>(options =>
                        {
                            var connectionString = "server=127.0.0.1;database=webcore;user id=root;password=Qaz830914@;maxpoolsize=100";

                            options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 36)), o => o.MigrationsAssembly("Repository.Tool"));
                        });

                    }).Build();

            host.Run();
        }
    }
}
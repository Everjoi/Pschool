using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pschool.Infrastructure.Data.Contexts;
using Pschool.Infrastructure.ModuleContainer;


namespace Pschool.Infrastructure.Extention
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration, IHostBuilder host)
        {
            services.AddDbContext(configuration);
            host.AddRepositories();
        }



        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            // TODO: get connection from safe place (fe: Azure Key Vault)
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<PschoolPersonContext>(options =>
               options.UseSqlServer(connectionString,
                   builder => builder.MigrationsAssembly(typeof(PschoolPersonContext).Assembly.FullName)));

        }


        private static void AddRepositories(this IHostBuilder builder)
        {
            builder.UseServiceProviderFactory(new AutofacServiceProviderFactory()).
                ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new PschoolModule());
                });

        }
    }
}

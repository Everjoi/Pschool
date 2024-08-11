using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pschool.Infrastructure.Data.Contexts;


namespace Pschool.Infrastructure.Extention
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialization(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetService<PschoolPersonContext>()?.Database.Migrate();
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Pschool.Domain.Common;
using Pschool.Domain.Entities;
using System.Reflection;


namespace Pschool.Infrastructure.Data.Contexts
{
    public class PschoolPersonContext : DbContext
    {
        public PschoolPersonContext(){  }
        public PschoolPersonContext(DbContextOptions<PschoolPersonContext> options, IConfiguration configuration, IHostEnvironment environment)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Parent> Parents => Set<Parent>();
        public DbSet<Student> Stundets => Set<Student>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Parent>().HasKey(x => x.Id);
            modelBuilder.Entity<Student>().HasKey(x => x.Id);

            modelBuilder.Entity<Parent>()
                .HasMany<Student>()
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);  

            modelBuilder.Entity<Student>()
                .HasOne<Parent>()
                .WithMany()
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Restrict);  

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {

            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToArray();

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}

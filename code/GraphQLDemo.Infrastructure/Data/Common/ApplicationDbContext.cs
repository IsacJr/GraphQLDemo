using GraphQLDemo.Domain;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public virtual DbSet<User>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("graphql_demo");

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
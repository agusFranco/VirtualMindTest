using System.Data.Entity;
using Domain;

namespace Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            MapUsers(modelBuilder);
        }

        private void MapUsers(DbModelBuilder builder)
        {
            builder.Entity<User>().HasKey(_ => _.Id);
            builder.Entity<User>().Property(_ => _.Name).HasMaxLength(50);
            builder.Entity<User>().Property(_ => _.LastName).HasMaxLength(50);
            builder.Entity<User>().Property(_ => _.Email).HasMaxLength(50);
            builder.Entity<User>().Property(_ => _.Password).HasMaxLength(8);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using OderApp.DataSource.Entities;

namespace OderApp.DataSource
{
	public class OrderDbContext:DbContext
	{
		public OrderDbContext(DbContextOptions<OrderDbContext> options):base(options){}
        public DbSet<AccountEntity> Account { get; set; }
        
        public DbSet<ItemEntity> Item { get; set; }
        public DbSet<ConfigurationEntity> Configuration { get; set; }
        public DbSet<UserEntity> User { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
	        optionsBuilder.UseMySQL("server=localhost;database=orderapp;user=root;password=Quyenvu249;port=3306");
	        optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
	        base.OnModelCreating(modelBuilder);

	        modelBuilder.Entity<UserEntity>(entity =>
	        {
		        entity.Property(e => e.Id).HasColumnName("id");
		        entity.Property(e => e.Name).IsRequired().HasColumnName("name");
		        entity.Property(e => e.Email).IsRequired().HasColumnName("email");
		        entity.Property(e => e.Role).IsRequired().HasColumnName("role");
	        });
        }
    }

}


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
    }

}


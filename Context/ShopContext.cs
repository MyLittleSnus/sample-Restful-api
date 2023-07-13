using GoodsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodsApi.Context
{
	public class ShopContext : DbContext
	{
        public DbSet<Order> Orders { get; set; }
        public DbSet<Good> Goods { get; set; }

        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;

        public ShopContext(
            IConfiguration config,
            IWebHostEnvironment env)
        {
            Database.EnsureCreated();
            _config = config;
            _env = env;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseMySql(configuration.GetConnectionString("MySqlDB"),
                new MySqlServerVersion(new Version(8, 0, 30)));

            optionsBuilder.LogTo((string logMsg) =>
            {
                var rootDir = _env.ContentRootPath;
                var path = Path.Combine(rootDir, "logs/query.log");
                File.AppendAllText(path, logMsg);
            });
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseEntity>().UseTpcMappingStrategy();

            modelBuilder.ApplyConfiguration(new GoodsShopContextConfiguration());
        }
    }
}
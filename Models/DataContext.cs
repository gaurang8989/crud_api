using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace People.Models
{
    public class DataContext : DbContext
    {
         public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var builder = new ConfigurationBuilder()
        //                            .SetBasePath(Directory.GetCurrentDirectory())
        //                            .AddJsonFile("appsettings.json");
        //    var configuration = builder.Build();

        //        Console.WriteLine("Gaurang : " + configuration["ConnectionStrings:Default"]);
        //    optionsBuilder.UseSqlServer(configuration["ConnectionStrings:Default"]);

        //}
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=194.59.164.1;database=u159536146_gaurang;user=u159536146_gaurang;password=Gaurang143@@@;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Fname).IsRequired();
            });
        }
    }
}

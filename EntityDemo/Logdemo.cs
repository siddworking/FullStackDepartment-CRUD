using BOL;
using Microsoft.EntityFrameworkCore;
namespace DAL;

 public class Logdemo:DbContext{
     public DbSet<Login> Logins {get;set;}

  
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string conString=@"server=localhost;port=3306;user=root; password=123456789;database=transflower";       
        optionsBuilder.UseMySQL(conString);

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Login>(entity => 
            {
            entity.HasKey(e => e.Email);
            entity.Property(e => e.Password).IsRequired();
            // entity.Property(e => e.Location).IsRequired();
            });
            modelBuilder.Entity<Login>().ToTable("login");

        }
 }
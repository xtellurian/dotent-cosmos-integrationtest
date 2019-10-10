
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace src
{
    public class MyContext : IdentityDbContext<IdentityUser>
    {
        public MyContext(DbContextOptions<MyContext> options)
           : base(options)
        { }

        public DbSet<Model> Models { get; set; }
        public DbSet<Related> Related { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Model>(b =>{
                b.Property(c => c.Id).ValueGeneratedOnAdd();
                b.HasMany(c => c.RelatedModels).WithOne(c => c.Model).HasForeignKey(c => c.ModelId);
            });
            modelBuilder.Entity<Related>(b => {
                b.Property(c => c.Id).ValueGeneratedOnAdd();
                b.HasOne(c => c.Model).WithMany(c => c.RelatedModels).HasForeignKey(c => c.ModelId);
            });
        }
    }
}
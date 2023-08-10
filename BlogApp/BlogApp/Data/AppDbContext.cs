using Microsoft.EntityFrameworkCore;
namespace BlogApp.Data;
using BlogApp.Models;
public class AppDbContext : DbContext
{
    public virtual DbSet<Comment> Comments { get; set; }
    public virtual DbSet<Post> Posts { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasMany(c => c.Comments)
            .WithOne(c => c.Post);
        });
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasOne(p => p.Post)
            .WithMany(c => c.Comments).HasForeignKey(x => x.PostId);
        });
    }*/
}

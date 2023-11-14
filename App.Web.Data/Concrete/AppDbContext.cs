using App.Web.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Web.Data.Concrete
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryPost> CategoryPosts { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Slider> SliderItems { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }

        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(p => p.RoleId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(pc => pc.Post)
                .HasForeignKey(pc => pc.PostId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<CategoryPost>()
                .HasOne(cp => cp.Category)
                .WithMany(x => x.CategoryPosts)
                .HasForeignKey(cp => cp.CategoryId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<CategoryPost>()
                .HasOne(cp => cp.Post)
                .WithMany(x => x.CategoryPosts)
                .HasForeignKey(cp => cp.PostId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<PostImage>()
                .HasOne(pi => pi.Post)
                .WithMany(p => p.Images)
                .HasForeignKey(pi => pi.PostId)
                .OnDelete(DeleteBehavior.ClientCascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}

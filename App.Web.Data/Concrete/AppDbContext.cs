using App.Web.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Web.Data.Concrete
{
    //public class AppDbContext : DbContext
    //{
    //    public DbSet<User> Users { get; set; }
    //    public DbSet<Role> Roles { get; set; }
    //    public DbSet<Category> Categories { get; set; }
    //    public DbSet<CategoryPost> CategoryPosts { get; set; }
    //    public DbSet<Post> Posts { get; set; }
    //    public DbSet<PostComment> PostComments { get; set; }
    //    public DbSet<PostImage> PostImages { get; set; }
    //    public DbSet<Page> Pages { get; set; }
    //    public DbSet<Settings> Settings { get; set; }
    //    public AppDbContext()
    //    {

    //    }
    //    public AppDbContext(DbContextOptions options) : base(options)
    //    {

    //    }      
    //}

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
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(pc => pc.Post)
                .HasForeignKey(pc => pc.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CategoryPost>()
                .HasOne(cp => cp.Category)
                .WithMany()
                .HasForeignKey(cp => cp.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CategoryPost>()
                .HasOne(cp => cp.Post)
                .WithMany()
                .HasForeignKey(cp => cp.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PostImage>()
                .HasOne(pi => pi.Post)
                .WithMany(p => p.Images)
                .HasForeignKey(pi => pi.PostId);

            modelBuilder.Entity<CategoryPost>()
                .HasKey(cp => new { cp.CategoryId, cp.PostId });

            base.OnModelCreating(modelBuilder);
        }
    }
}

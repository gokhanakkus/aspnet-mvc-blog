using App.Web.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Web.Data.Concrete
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            SeedCategories(context);
            SeedRoles(context);
            SeedUsers(context);
            SeedPosts(context);
            SeedPostImages(context);
            SeedCategoryPosts(context);
            SeedPages(context);
            SeedPostComments(context);
            SeedSliderItems(context);
        }
        private static void SeedCategories(AppDbContext context)
        {
            if (!context.Categories.Any())
            {
                var categories = new[]
                {
                    new Category { Name = "Travel" },
                    new Category { Name = "Weekends" },
                    new Category { Name = "LifeStyle" },
                    new Category { Name = "Health" },
                    new Category { Name = "Explore" },
                    new Category { Name = "Experience" },

                };

                context.Categories.AddRange(categories);
                context.SaveChanges();
            }
        }
        private static void SeedRoles(AppDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roles = new List<Role>
                {
                    new Role { Name = "Admin" },
                    new Role { Name = "Moderator" },
                    new Role { Name = "User" }
                };

                context.Roles.AddRange(roles);
                context.SaveChanges();
            }
        }
        private static void SeedUsers(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                var users = new List<User>
                {
                    new User
                    {
                        Name = "admin",
                        Email = "admin@blog.com",
                        Password = "1234",
                        CreatedAt = DateTime.UtcNow,
                        RoleId = context.Roles.Single(r => r.Name == "Admin").Id
                    },
                    new User
                    {
                        Name = "moderator",
                        Email = "moderator@blog.com",
                        Password = "1234",
                        CreatedAt = DateTime.UtcNow,
                        RoleId = context.Roles.Single(r => r.Name == "Moderator").Id
                    },
                    new User
                    {
                        Name = "user",
                        Email = "user@blog.com",
                        Password = "1234",
                        CreatedAt = DateTime.UtcNow,
                        RoleId = context.Roles.Single(r => r.Name == "User").Id
                        
                    }
                };

                context.Users.AddRange(users);
                context.SaveChanges();
            }
        }
        private static void SeedPostImages(AppDbContext context)
        {
            if (!context.PostImages.Any())
            {
                var postImages = new[]
                {
                    new PostImage { PostId = 1, ImagePath = "https://localhost:7239//Img/news/f1.jpg" },
                    new PostImage { PostId = 2, ImagePath = "https://localhost:7239//Img/news/f2.jpg" },
                    new PostImage { PostId = 3, ImagePath = "https://localhost:7239//Img/news/f3.jpg" },
                    new PostImage { PostId = 4, ImagePath = "https://localhost:7239//Img/news/f4.jpg" },
                    new PostImage { PostId = 5, ImagePath = "https://localhost:7239//Img/news/f5.jpg" },
                    new PostImage { PostId = 6, ImagePath = "https://localhost:7239//Img/news/f6.jpg" },

                };

                context.PostImages.AddRange(postImages);
                context.SaveChanges();
            }
        }

        private static void SeedCategoryPosts(AppDbContext context)
        {
            if (!context.CategoryPosts.Any())
            {
                var categoryPosts = new[]
                {
                    new CategoryPost { CategoryId = 1, PostId = 1 },
                    new CategoryPost { CategoryId = 2, PostId = 2 },
                    new CategoryPost { CategoryId = 3, PostId = 3 },
                    new CategoryPost { CategoryId = 4, PostId = 4 },
                    new CategoryPost { CategoryId = 5, PostId = 5 },
                    new CategoryPost { CategoryId = 6, PostId = 6 },

                };

                context.CategoryPosts.AddRange(categoryPosts);
                context.SaveChanges();
            }
        }

        private static void SeedPages(AppDbContext context)
        {
            if (!context.Pages.Any())
            {
                var pages = new[]
                {
                    new Page { Title = "Sayfa 1", Content = "İçerik 1", IsActive = true },
                    new Page { Title = "Sayfa 2", Content = "İçerik 2", IsActive = true },
                    new Page { Title = "Sayfa 3", Content = "İçerik 3", IsActive = true },
                    new Page { Title = "Sayfa 4", Content = "İçerik 4", IsActive = true },
                    new Page { Title = "Sayfa 5", Content = "İçerik 5", IsActive = true },

                };

                context.Pages.AddRange(pages);
                context.SaveChanges();
            }
        }

        private static void SeedPostComments(AppDbContext context)
        {
            if (!context.PostComments.Any())
            {

                var postComments = new[]
                {
                    new PostComment { PostId = 1, UserId = 1, Comment = "Yorum 1", IsActive = true },
                    new PostComment { PostId = 2, UserId = 2, Comment = "Yorum 2", IsActive = true },
                    new PostComment { PostId = 3, UserId = 3, Comment = "Yorum 3", IsActive = true },

                };

                context.PostComments.AddRange(postComments);
                context.SaveChanges();

            }
        }
        private static void SeedSliderItems(AppDbContext context)
        {
            if (!context.SliderItems.Any())
            {
                var sliderItems = new List<Slider>
                {
                    new Slider
                    {
                        Name = "Trip to California",
                        Title = "Travel",
                        ImageUrl = "/Img/slider/slider1.jpg",
                        Date = new DateTime(2023, 1, 2)
                    },
                    new Slider
                    {
                        Name = "Our Favorite Weekend Getaways",
                        Title = "Weekends",
                        ImageUrl = "/Img/slider/slider2.jpg",
                        Date = new DateTime(2019, 9, 15)
                    },
                    new Slider
                    {
                        Name = "What Type of Traveler Are You?",
                        Title = "LifeStyle",
                        ImageUrl = "/Img/slider/slider3.jpg",
                        Date = new DateTime(2023, 9, 23)
                    }
                };

                context.SliderItems.AddRange(sliderItems);
                context.SaveChanges();
            }
        }
        private static void SeedPosts(AppDbContext context)
        {
            if (!context.Posts.Any())
            {
                var posts = new List<Post>
                {
                    new Post { UserId = 1, Title = "Travel", Content = "How to Make a List for Traveling Alone", IsSlider = true },
                    new Post { UserId = 2, Title = "Weekends", Content = "A Simple Way to Feel Like Home When You Travel", IsSlider = true },
                    new Post { UserId = 3, Title = "LifeStyle", Content = "What Type of Traveler Are You?", IsSlider = true },
                    new Post { UserId = 1, Title = "Health", Content = "How to Plan Your Trip the Right Way", IsSlider = false },
                    new Post { UserId = 2, Title = "Explore", Content = "8 Powerful Ways to Add Vibrant Color to Your Life", IsSlider = false },
                    new Post { UserId = 3, Title ="Experience" ,Content="A Road Trip Review of the 2023", IsSlider = false },  
                };

                context.Posts.AddRange(posts);
                context.SaveChanges();
            }
        }
    }
}

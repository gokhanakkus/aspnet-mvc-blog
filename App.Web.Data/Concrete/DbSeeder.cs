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
            SeedPosts(context);
            SeedUsersAndRoles(context);
            SeedPostImages(context);
            SeedCategoryPosts(context);
            SeedPages(context);
            SeedPostComments(context);
            SeedSlider(context);
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

                };

                context.Categories.AddRange(categories);
                context.SaveChanges();
            }
        }

        private static void SeedPosts(AppDbContext context)
        {
            if (!context.Posts.Any())
            {
                var posts = new[]
                {
                    new Post { UserId = 1, Title = "Travel", Content = "How to Make list for travelling alone" },
                    new Post { UserId = 2, Title = "Weekends", Content = "A Simple Way to Feel Like Home When You Travel" },
                    new Post { UserId = 3, Title = "LifeStyle", Content = "What Type of Traveller Are You?" },
                    new Post { UserId = 1, Title = "Health", Content = "How to Plan your Trip the Right Way" },
                    new Post { UserId = 2, Title = "Explore", Content = "8 Powerful Ways to Add Vibrant Colour to Your Life" },
                    //new Post {Title="Explore" ,Content="The best place to explore to enjoy",Date="June 15, 2019" ,Images="Img/news/f1.jpg" },
                    //new Post{Title="Lifestyle" ,Content="How to Make list for travelling alone",Date="September 15, 2019" ,Images="Img/news/f2.jpg" },
                    //new Post{Title="Food" ,Content="5 ingredient cilantro vinaigrette",Date="September 15, 2019"  ,Images="Img/news/f3.jpg"},
                    //new Post{Title="Explore" ,Content="A Simple Way to Feel Like Home When You Travel",Date="March 20, 2019"  ,Images="Img/news/ f4.jpg"},
                    //new Post{Title="March 20, 2019" ,Content="What Type of Traveller Are You?",Date="September 15, 2019" ,Images="Img/news/f5.jpg"},
                    //new Post{Title="Experience" ,Content="A Road Trip Review of the 2018",Date="July 10, 2019" ,ImageUrl="Img/news/f6.jpg" },
                    //new Post{Title="music" ,Content="Portugal’s Sunset summer vission",Date="September 15, 2019" ,ImageUrl="Img/news/f7.jpg" },
                    //new Post{Title="beauty" ,Content="The best soft Tropical Getaway",Date="March 12, 2019"  ,ImageUrl="Img/news/f8.jpg"},
                    //new Post{Title="Travel" ,Content="Memoriable Paris Girls Trip",Date="April 19, 2019"  ,ImageUrl="Img/news/f9.jpg"},
                    //new Post{Title="Experience" ,Content="How to Plan your Trip the Right Way" ,Date="February 15, 2019",ImageUrl="Img/news/f10.jpg"},
                    //new Post{Title="Travel" ,Content="8 Powerful Ways to Add Vibrant Colour to Your Life" ,Date="April 19, 2019"  ,ImageUrl="Img/news/ f11.jpg"},
                    //new Post{Title="Lifestyle" ,Content="The best to-do list to help boost your productivity" ,Date="October 2, 2019",ImageUrl="Img/news/  f2.jpg"}
                };

                context.Posts.AddRange(posts);
                context.SaveChanges();
            }
        }

        private static void SeedUsersAndRoles(AppDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleAdmin = new Role
                {
                    Name = "Admin"
                };

                context.Roles.Add(roleAdmin);

                var roleAuthor = new Role
                {
                    Name = "Author"
                };

                context.Roles.Add(roleAuthor);

                var roleUser = new Role
                {
                    Name = "User"
                };

                context.Roles.Add(roleUser);
            }

            if (!context.Users.Any())
            {
                var adminUser = new User
                {
                    Name = "admin",
                    Email = "admin@blog.com",
                    Password = "1234",
                    CreatedAt = DateTime.UtcNow,
                    RoleId = context.Roles.Single(r => r.Name == "Admin").Id
                };

                var userUser = new User
                {
                    Name = "user",
                    Email = "user@blog.com",
                    Password = "1234",
                    CreatedAt = DateTime.UtcNow,
                    RoleId = context.Roles.Single(r => r.Name == "User").Id
                };

                var authorUser = new User
                {
                    Name = "author",
                    Email = "author@blog.com",
                    Password = "1234",
                    CreatedAt = DateTime.UtcNow,
                    RoleId = context.Roles.Single(r => r.Name == "Author").Id
                };

                context.Users.AddRange(adminUser, userUser, authorUser);
            }

            context.SaveChanges();
        }

        private static void SeedPostImages(AppDbContext context)
        {
            if (!context.PostImages.Any())
            {
                var postImages = new[]
                {
                    new PostImage { PostId = 1, ImagePath = "Img/news/f1.jpg" },
                    new PostImage { PostId = 2, ImagePath = "Img/news/f2.jpg" },
                    new PostImage { PostId = 3, ImagePath = "Img/news/f3.jpg" },
                    new PostImage { PostId = 4, ImagePath = "Img/news/f4.jpg" },
                    new PostImage { PostId = 5, ImagePath = "Img/news/f5.jpg" },

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

        private static void SeedSlider(AppDbContext context)
        {
            var SliderItems = new[]              
            {
                new Slider()
                {
                    Name = "Trip to California",
                    Title= "Travel",
                    ImageUrl= "/Img/slider/slider1.jpg",
                    Date = "January 2, 2023"
                },

                new Slider()
                {
                    Name = "Our Favorite Weekend Getaways",
                    Title= "Weekends",
                    ImageUrl= "/Img/slider/slider2.jpg",
                    Date = "September 15, 2019"
                },

                new Slider()
                {
                    Name = "Tips for Taking a Long-term Trip",
                    Title= "LifeStyle",
                    ImageUrl= "/Img/slider/slider3.jpg",
                    Date = "June 12, 2019"
                },

                new Slider()
                {
                    Name = "Tips for Taking a Long-term Trip",
                    Title= "LifeStyle",
                    ImageUrl= "/Img/slider/slider1.jpg",
                    Date = "September 18, 2022"
                },

                new Slider()
                {
                    Name = "Tips for Taking a Long-term Trip",
                    Title= "LifeStyle",
                    ImageUrl= "/Img/slider/slider2.jpg",
                    Date = "September 21, 2023"
                },

            };
            context.SliderItems.AddRange(SliderItems);
            context.SaveChanges();

        }    
    }
}

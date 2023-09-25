using App.Web.Mvc.Models;
using static System.Net.Mime.MediaTypeNames;
namespace App.Web.Mvc.Data
{
    public class DataBase
    {
        public List<SliderViewModel> SliderItems { get; set; }

        public List<PostItemViewModel> PostItem { get; set; }

        public DataBase()
        {
            SliderItems = new List<SliderViewModel>()
            {
                new SliderViewModel()
                {
                    Name = "Trip to California",
                    Title= "Travel",
                    ImageUrl= "/Img/slider/slider1.jpg",
                    Date = "January 2, 2023"
                },

                new SliderViewModel()
                {
                    Name = "Our Favorite Weekend Getaways",
                    Title= "Weekends",
                    ImageUrl= "/Img/slider/slider2.jpg",
                    Date = "September 15, 2019"
                },
                new SliderViewModel()
                {
                    Name = "Tips for Taking a Long-term Trip",
                    Title= "LifeStyle",
                    ImageUrl= "/Img/slider/slider3.jpg",
                    Date = "June 12, 2019"
                },

                new SliderViewModel()
                {
                    Name = "Tips for Taking a Long-term Trip",
                    Title= "LifeStyle",
                    ImageUrl= "/Img/slider/slider1.jpg",
                    Date = "September 18, 2022"
                },
                new SliderViewModel()
                {
                    Name = "Tips for Taking a Long-term Trip",
                    Title= "LifeStyle",
                    ImageUrl= "/Img/slider/slider2.jpg",
                    Date = "September 21, 2023"
                },
            };
            PostItem = new List<PostItemViewModel>()
            {
                new PostItemViewModel(){Title="Explore" ,Name="The best place to explore to enjoy",Date="June 15, 2019" ,ImageUrl="Img/news/f1.jpg" },
                new PostItemViewModel(){Title="Lifestyle" ,Name="How to Make list for travelling alone",Date="September 15, 2019" ,ImageUrl="Img/news/f2.jpg" },
                new PostItemViewModel(){Title="Food" ,Name="5 ingredient cilantro vinaigrette",Date="September 15, 2019"  ,ImageUrl="Img/news/f3.jpg"},
                new PostItemViewModel(){Title="Explore" ,Name="A Simple Way to Feel Like Home When You Travel",Date="March 20, 2019"  ,ImageUrl="Img/news/f4.jpg"},
                new PostItemViewModel(){Title="March 20, 2019" ,Name="What Type of Traveller Are You?",Date="September 15, 2019" ,ImageUrl="Img/news/f5.jpg"},
                new PostItemViewModel(){Title="Experience" ,Name="A Road Trip Review of the 2018",Date="July 10, 2019" ,ImageUrl="Img/news/f6.jpg" },
                new PostItemViewModel(){Title="music" ,Name="Portugal’s Sunset summer vission",Date="September 15, 2019" ,ImageUrl="Img/news/f7.jpg" },
                new PostItemViewModel(){Title="beauty" ,Name="The best soft Tropical Getaway",Date="March 12, 2019"  ,ImageUrl="Img/news/f8.jpg"},
                new PostItemViewModel(){Title="Travel" ,Name="Memoriable Paris Girls Trip",Date="April 19, 2019"  ,ImageUrl="Img/news/f9.jpg"},
                new PostItemViewModel(){Title="Experience" ,Name="How to Plan your Trip the Right Way" ,Date="February 15, 2019",ImageUrl="Img/news/f10.jpg"},
                new PostItemViewModel(){Title="Travel" ,Name="8 Powerful Ways to Add Vibrant Colour to Your Life" ,Date="April 19, 2019"  ,ImageUrl="Img/news/f11.jpg"},
                new PostItemViewModel(){Title="Lifestyle" ,Name="The best to-do list to help boost your productivity" ,Date="October 2, 2019",ImageUrl="Img/news/f2.jpg"}
            };

        }
    }

}
using DinasDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinasDemo.Data
{
    public class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Products.Any())
            {
                context.AddRange
                (
                    new Product
                    {
                        Name = "Masala Bhindi",
                        Price = 7.95M,
                        Ingredient = "mustard oil, cumin seeds, fennel seeds, finely-chopped onions, ginger and a pinch of amchoor",
                        Description = "A delicious dish made with freshly bought okra. Grab some mustard oil, cumin seeds, fennel seeds, finely-chopped onions, ginger and a pinch of amchoor. We promise you'll make this recipe a regular affair in your weekly menu.",
                        Category = Categories["Lunch"],
                        ImageUrl = "https://i.ndtvimg.com/i/2015-04/bhindi_625x350_51429706972.jpg",
                        InStock = 1,
                        IsPreferredFood = true,
                        ImageThumbnailUrl = "https://i.ndtvimg.com/i/2015-04/bhindi_625x350_51429706972.jpg"
                    },
                    new Product
                    {
                        Name = "Chana Kulcha",
                        Price = 17.95M,
                        Ingredient = "Cumin powder, ginger, coriander powder, carom powder and some mango powder.",
                        Description = "A classic dish that never goes out of style. The quintessential chana kulcha  needs only a few ingredients - cumin powder, ginger, coriander powder, carom powder and some mango powder, which is what gives the chana it's sour and tangy taste.",
                        Category = Categories["Lunch"],
                        ImageUrl = "https://i.ndtvimg.com/i/2015-04/chana-kulcha_625x350_41429707001.jpg",
                        InStock = 1,
                        IsPreferredFood = false,
                        ImageThumbnailUrl = "https://i.ndtvimg.com/i/2015-04/chana-kulcha_625x350_41429707001.jpg"
                    },
                    new Product
                    {
                        Name = "Shahi Egg Curry",
                        Price = 12.95M,
                        Ingredient = "Garlic, onions, a whole lot of kasuri methi, fresh cream, yogurt and fresh coriander.",
                        Description = "Eggs are a versatile food that can be cooked for any meal of the day. From breakfast to dinner, it can be a go-to food. Here is a mildly-spiced egg curry made with garlic, onions, a whole lot of kasuri methi, fresh cream, yogurt and fresh coriander. It can be paired with plain chapati, paratha, rice, biryani or pulao depending upon your choice. You can also serve pickle along with it.",
                        Category = Categories["Lunch"],
                        ImageUrl = "https://i.ndtvimg.com/i/2017-11/goan-egg-curry_620x350_41511515276.jpg",
                        InStock = 1,
                        IsPreferredFood = false,
                        ImageThumbnailUrl = "https://i.ndtvimg.com/i/2017-11/goan-egg-curry_620x350_41511515276.jpg"
                    },
                    new Product
                    {
                        Name = "Lemon Chicken",
                        Price = 15.95M,
                        Ingredient = "Lemon, chicken, dried chilli, garlic and some seriously delectable sugarcane juice",
                        Description = "Lemon, chicken, dried chilli, garlic and some seriously delectable sugarcane juice is all you need for this fantastic recipe.  Try this different yet delicious version of a chicken at your next dinner party and you wouldn't be able to resist coming back to this chicken recipe!",
                        Category = Categories["Dinner"],
                        ImageUrl = "https://i.ndtvimg.com/i/2015-06/indian-dinner_625x350_71434359756.jpg",
                        InStock = 5,
                        IsPreferredFood = true,
                        ImageThumbnailUrl = "https://i.ndtvimg.com/i/2015-06/indian-dinner_625x350_71434359756.jpg"
                    },
                    new Product
                    {
                        Name = "Chettinad Fish Fry",
                        Price = 12.95M,
                        Ingredient = "Pieces of surmai fish marinated in garlic, cumin, fennel, curry leaves and tomatoes",
                        Description = "Get your daily dose of perfect protein. Pieces of surmai fish marinated in garlic, cumin, fennel, curry leaves and tomatoes are pan-fried in refined oil and served hot. This fish fry recipe has a host of delectable spices used for marination giving it a unique touch.",
                        Category = Categories["Dinner"],
                        ImageUrl = "https://i.ndtvimg.com/i/2015-06/indian-dinner_625x350_41434360207.jpg",
                        InStock = 4,
                        IsPreferredFood = true,
                        ImageThumbnailUrl = "https://i.ndtvimg.com/i/2015-06/indian-dinner_625x350_41434360207.jpg"
                    },
                    new Product
                    {
                        Name = "Guilt-Free Galouti Kebab",
                        Price = 17.95M,
                        Ingredient = "Soft and succulent galouti kebabs made with olive oil and pure ghee",
                        Description = "If you want good food but kind that doesn't go straight to your hip, then here's the perfect recipe. Soft and succulent galouti kebabs made with olive oil and pure ghee. Just the right mutton appetizer you have been searching for, made absolutely in a healthy way!",
                        Category = Categories["Dinner"],
                        ImageUrl = "https://i.ndtvimg.com/i/2017-09/galouti-kebab_625x350_51506417223.jpg",
                        InStock = 3,
                        IsPreferredFood = false,
                        ImageThumbnailUrl = "https://i.ndtvimg.com/i/2017-09/galouti-kebab_625x350_51506417223.jpg"
                    }
                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Lunch", Description = "Lunch, the abbreviation for luncheon, is a meal typically eaten at midday" },
                    new Category { CategoryName = "Dinner", Description = "Dinner usually refers to the most significant meal of the day, which can be at noon or in the evening." }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }
    }
}

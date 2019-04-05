using DinasDemo.Interfaces;
using DinasDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinasDemo.Data.Mocks
{
    public class MockProductRepository : IProductRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Product> Products {
            get
            {
                return new List<Product>
                {
                    new Product {
                        Name = "Masala Bhindi",
                        Price = 7.95M, Ingredient = "mustard oil, cumin seeds, fennel seeds, finely-chopped onions, ginger and a pinch of amchoor",
                        Description = "A delicious dish made with freshly bought okra. Grab some mustard oil, cumin seeds, fennel seeds, finely-chopped onions, ginger and a pinch of amchoor. We promise you'll make this recipe a regular affair in your weekly menu.",
                        Category = _categoryRepository.Categories.First(),
                        ImageUrl = "https://i.ndtvimg.com/i/2015-04/bhindi_625x350_51429706972.jpg",
                        InStock = 1,
                        IsPreferredFood = true,
                        ImageThumbnailUrl = "https://i.ndtvimg.com/i/2015-04/bhindi_625x350_51429706972.jpg"
                    },
                    new Product {
                        Name = "Chana Kulcha",
                        Price = 17.95M, Ingredient = "Cumin powder, ginger, coriander powder, carom powder and some mango powder.",
                        Description = "A classic dish that never goes out of style. The quintessential chana kulcha  needs only a few ingredients - cumin powder, ginger, coriander powder, carom powder and some mango powder, which is what gives the chana it's sour and tangy taste.",
                        Category = _categoryRepository.Categories.First(),
                        ImageUrl = "https://i.ndtvimg.com/i/2015-04/chana-kulcha_625x350_41429707001.jpg",
                        InStock = 1,
                        IsPreferredFood = true,
                        ImageThumbnailUrl = "https://i.ndtvimg.com/i/2015-04/chana-kulcha_625x350_41429707001.jpg"
                    },
                    new Product {
                        Name = "Masala Bhindi",
                        Price = 7.95M, Ingredient = "mustard oil, cumin seeds, fennel seeds, finely-chopped onions, ginger and a pinch of amchoor",
                        Description = "A delicious dish made with freshly bought okra. Grab some mustard oil, cumin seeds, fennel seeds, finely-chopped onions, ginger and a pinch of amchoor. We promise you'll make this recipe a regular affair in your weekly menu.",
                        Category = _categoryRepository.Categories.First(),
                        ImageUrl = "https://i.ndtvimg.com/i/2015-04/bhindi_625x350_51429706972.jpg",
                        InStock = 1,
                        IsPreferredFood = true,
                        ImageThumbnailUrl = "https://i.ndtvimg.com/i/2015-04/bhindi_625x350_51429706972.jpg"
                    },
                    new Product {
                        Name = "Chana Kulcha",
                        Price = 17.95M, Ingredient = "Cumin powder, ginger, coriander powder, carom powder and some mango powder.",
                        Description = "A classic dish that never goes out of style. The quintessential chana kulcha  needs only a few ingredients - cumin powder, ginger, coriander powder, carom powder and some mango powder, which is what gives the chana it's sour and tangy taste.",
                        Category = _categoryRepository.Categories.First(),
                        ImageUrl = "https://i.ndtvimg.com/i/2015-04/chana-kulcha_625x350_41429707001.jpg",
                        InStock = 1,
                        IsPreferredFood = true,
                        ImageThumbnailUrl = "https://i.ndtvimg.com/i/2015-04/chana-kulcha_625x350_41429707001.jpg"
                    }
                };
            }

            set => throw new NotImplementedException();
        }
        public IEnumerable<Product> PreferredProducts {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }
    }
}


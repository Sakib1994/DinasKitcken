using DinasDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinasDemo.Models;

namespace DinasDemo.Data.Mocks
{
    public class MockCategoryRepository : ICategoryRepository
    {
        
        IEnumerable<Category> ICategoryRepository.Categories {
            get
            {
                return new List<Category>
                {
                    new Category { CategoryName = "Lunch", Description = "Lunch, the abbreviation for luncheon, is a meal typically eaten at midday" },
                    new Category { CategoryName = "Dinner", Description = "Dinner usually refers to the most significant meal of the day, which can be at noon or in the evening." }
                };
            }
        }
    }
}

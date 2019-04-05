using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DinasDemo.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Ingredient { get; set; }
        [Required]
        [Display(Name = "Long Description")]
        public string Description { get; set; }
        public decimal Price { get; set; }
        [Url]
        public string ImageUrl { get; set; }
        [Required]
        [Display(Name = "Image Thumbnail Url")]
        public string ImageThumbnailUrl { get; set; }
        public bool IsPreferredFood { get; set; }
        public int InStock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DinasDemo.ViewModels
{
    public class ProductInputVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Type the Product Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Type the Ingredients used")]
        public string Ingredient { get; set; }
        [Required(ErrorMessage = "Please Type the Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please Type the Price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please Type the ImageUrl")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Please Type the Image Thumbnail Url")]
        [Display(Name = "Image Thumbnail Url")]
        public string ImageThumbnailUrl { get; set; }
        [Required(ErrorMessage = "Please Click if product Is Preferred Food")]
        public bool IsPreferredFood { get; set; }
        [Required(ErrorMessage = "Please Type the number of Product ")]
        public int InStock { get; set; }
        public int CategoryId { get; set; }
    }
}

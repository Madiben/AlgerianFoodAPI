using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlgerianFoodAPI.Models
{
    public class Dish
    {
        [Key] 
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100, ErrorMessage = "Dish name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(100, ErrorMessage = "Origin cannot exceed 50 characters.")] 
        public string Origin { get; set; } = string.Empty;

        [Required]
        [StringLength(10000, ErrorMessage = "Recipe cannot exceed 1000 characters.")] 
        public string Recipe { get; set; } = string.Empty;

        [Required]
        [Url(ErrorMessage = "Invalid image URL format.")] 
        public string ImageUrl { get; set; } = string.Empty;

        public List<Ingredient> Ingredients { get; set; } = new();
    }
}

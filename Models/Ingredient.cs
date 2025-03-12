using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlgerianFoodAPI.Models
{
    public class Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Ingredient name cannot exceed 100 characters.")] 
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0.1, 10000, ErrorMessage = "Quantity must be between 0.1 and 10,000.")] 
        public double Quantity { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Unit cannot exceed 20 characters.")] 
        public string Unit { get; set; } = string.Empty;

        [Required]
        public Guid DishId { get; set; }

        public Dish? Dish { get; set; }
    }
}

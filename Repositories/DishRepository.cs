using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlgerianFoodAPI.Data;
using AlgerianFoodAPI.Models;

namespace AlgerianFoodAPI.Repositories
{
    public class DishRepository : IDishRepository
    {
        private readonly AlgerianFoodDbContext _context;

        public DishRepository(AlgerianFoodDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dish>> GetAllAsync()
        {
            return await _context.Dishes.Include(d => d.Ingredients).ToListAsync();
        }

        public async Task<Dish?> GetByIdAsync(Guid id)
        {
            return await _context.Dishes.Include(d => d.Ingredients)
                                        .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Dish?> GetRandomDishAsync()
        {
            return await _context.Dishes.Include(d => d.Ingredients)
                                        .OrderBy(d => EF.Functions.Random())
                                        .FirstOrDefaultAsync();
        }

        public async Task<Dish> AddAsync(Dish dish)
        {
            dish.Id = Guid.NewGuid(); 

            foreach (var ingredient in dish.Ingredients)
            {
                ingredient.Id = 0; 
            }

            _context.Dishes.Add(dish);
            await _context.SaveChangesAsync();
            return dish;
        }


        public async Task<Dish> UpdateAsync(Dish dish)
        {
            var existingDish = await _context.Dishes
                                             .Include(d => d.Ingredients)
                                             .FirstOrDefaultAsync(d => d.Id == dish.Id);
        
            if (existingDish == null)
                throw new KeyNotFoundException("Dish not found");
        
            _context.Entry(existingDish).CurrentValues.SetValues(dish);
        
            // ✅ Fix: Handle Ingredients separately
            foreach (var ingredient in dish.Ingredients)
            {
                var existingIngredient = existingDish.Ingredients.FirstOrDefault(i => i.Id == ingredient.Id);
        
                if (existingIngredient != null)
                {
                    _context.Entry(existingIngredient).CurrentValues.SetValues(ingredient);
                }
                else
                {
                    existingDish.Ingredients.Add(ingredient);
                }
            }
        
            await _context.SaveChangesAsync();
            return dish;
        }


        public async Task<bool> DeleteAsync(Guid id)
        {
            var dish = await _context.Dishes.FindAsync(id);
            if (dish == null) return false;

            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

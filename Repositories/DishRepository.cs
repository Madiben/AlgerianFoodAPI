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

        public async Task<IEnumerable<Dish>> GetAllAsync() =>
            await _context.Dishes.AsNoTracking().ToListAsync();

        public async Task<IEnumerable<Dish>> GetAllWithDetailsAsync() =>
            await _context.Dishes.Include(d => d.Ingredients).AsNoTracking().ToListAsync();

        public async Task<Dish?> GetByIdAsync(Guid id) =>
            await _context.Dishes.Include(d => d.Ingredients)
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(d => d.Id == id);

        public async Task<Dish?> GetRandomDishAsync() =>
            await _context.Dishes.Include(d => d.Ingredients)
                                 .OrderBy(d => EF.Functions.Random())
                                 .FirstOrDefaultAsync();

        public async Task<Dish> AddAsync(Dish dish)
        {
            dish.Id = Guid.NewGuid(); // Ensure unique ID
            _context.Dishes.Add(dish);
            await _context.SaveChangesAsync();
            return dish;
        }

        public async Task<bool> UpdateDishAsync(Guid id, string name, string origin, string recipe)
        {
            var dish = await _context.Dishes.FindAsync(id);
            if (dish == null) return false;

            dish.Name = name;
            dish.Origin = origin;
            dish.Recipe = recipe;

            _context.Entry(dish).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateDishImageAsync(Guid id, string imageUrl)
        {
            var dish = await _context.Dishes.FindAsync(id);
            if (dish == null) return false;

            dish.ImageUrl = imageUrl;

            _context.Entry(dish).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
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

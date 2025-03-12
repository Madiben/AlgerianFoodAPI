using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlgerianFoodAPI.Models;

namespace AlgerianFoodAPI.Repositories
{
    public interface IDishRepository
    {
        Task<IEnumerable<Dish>> GetAllAsync();
        Task<IEnumerable<Dish>> GetAllWithDetailsAsync();
        Task<Dish?> GetByIdAsync(Guid id);
        Task<Dish?> GetRandomDishAsync();
        Task<Dish> AddAsync(Dish dish);
        Task<bool> UpdateDishAsync(Guid id, string name, string origin, string recipe);
        Task<bool> UpdateDishImageAsync(Guid id, string imageUrl);
        Task<bool> DeleteAsync(Guid id);
    }
}

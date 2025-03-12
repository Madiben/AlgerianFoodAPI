using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlgerianFoodAPI.Models;

namespace AlgerianFoodAPI.Repositories
{
    public interface IDishRepository
    {
        Task<IEnumerable<Dish>> GetAllAsync();
        Task<Dish?> GetByIdAsync(Guid id);
        Task<Dish?> GetRandomDishAsync();
        Task<Dish> AddAsync(Dish dish);
        Task<Dish> UpdateAsync(Dish dish);
        Task<bool> DeleteAsync(Guid id);
    }
}

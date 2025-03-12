using Microsoft.AspNetCore.Mvc;
using AlgerianFoodAPI.Repositories;
using AlgerianFoodAPI.Models;

namespace AlgerianFoodAPI.Controllers
{
    [Route("api/dishes")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly IDishRepository _dishRepository;

        public DishesController(IDishRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dish>>> GetAll()
        {
            var dishes = await _dishRepository.GetAllAsync();
            return Ok(dishes);
        }

        [HttpGet("details")]
        public async Task<ActionResult<IEnumerable<Dish>>> GetAllWithDetails()
        {
            var dishes = await _dishRepository.GetAllWithDetailsAsync();
            return Ok(dishes);
        }

        [HttpGet("random")]
        public async Task<ActionResult<Dish>> GetRandomDish()
        {
            var dish = await _dishRepository.GetRandomDishAsync();
            return dish != null ? Ok(dish) : NotFound("No dish found.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dish>> GetById(Guid id)
        {
            var dish = await _dishRepository.GetByIdAsync(id);
            if (dish == null) return NotFound($"Dish with ID {id} not found.");
            return Ok(dish);
        }

        [HttpPost]
        public async Task<ActionResult<Dish>> Create([FromBody] Dish dish)
        {
            if (dish == null) return BadRequest("Invalid dish data");

            var newDish = await _dishRepository.AddAsync(dish);
            return CreatedAtAction(nameof(GetById), new { id = newDish.Id }, newDish);
        }

        [HttpPost("{id}/update")]
        public async Task<IActionResult> UpdateDish(Guid id, [FromBody] Dish dish)
        {
            if (id != dish.Id) return BadRequest("ID mismatch");

            var updated = await _dishRepository.UpdateDishAsync(id, dish.Name, dish.Origin, dish.Recipe);
            return updated ? Ok("Dish updated") : NotFound($"Dish with ID {id} not found.");
        }

        [HttpPost("{id}/image")]
        public async Task<IActionResult> UpdateImage(Guid id, [FromBody] string imageUrl)
        {
            var updated = await _dishRepository.UpdateDishImageAsync(id, imageUrl);
            return updated ? Ok("Image updated") : NotFound("Dish not found.");
        }

        [HttpPost("{id}/delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _dishRepository.DeleteAsync(id);
            return deleted ? Ok("Dish deleted") : NotFound($"Dish with ID {id} not found.");
        }
    }
}

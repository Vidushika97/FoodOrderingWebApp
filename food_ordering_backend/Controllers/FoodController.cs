using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos;
using Mappers;
using Microsoft.AspNetCore.Authorization;
using Service;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FoodController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        private readonly IFoodService _foodService;
        private readonly IRestaurantService _restaurantService;


        public FoodController(ApplicationDBContext context, IFoodService foodService, IRestaurantService restaurantService)
        {
            _context = context;
            _foodService = foodService;
            _restaurantService = restaurantService;
        }

        [HttpPost("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromRoute] int id, [FromBody] CreateFoodRequestDto createFoodDto)
        {
            if (!await _restaurantService.RestaurantExists(id))
            {
                return BadRequest("Restaurant does not exist");
            }

            var foodModel = createFoodDto.ToFoodFromCreateDTO(id);
            await _foodService.CreateAsync(foodModel);
            return Ok("Food Created Successfully!");
        }


        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateFoodRequestDto updateFoodDto)
        {
            var foodModel = await _foodService.UpdateAsync(id, updateFoodDto);

            if (foodModel == null)
            {
                return NotFound();
            }

            return Ok(updateFoodDto);
        }


        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var foodModel = await _foodService.DeleteAsync(id);

            if (foodModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
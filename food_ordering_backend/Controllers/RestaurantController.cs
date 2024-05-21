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

    public class RestaurantController : ControllerBase
    {

        private readonly ApplicationDBContext _context;
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(ApplicationDBContext context, IRestaurantService restaurantService)
        {
            // _context = context;
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await _restaurantService.GetAllAsync();

            var data = restaurants.Select(r => r.ToRestaurantDto());

            return Ok(data);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var restaurant = await _restaurantService.GetByIdAsync(id);


            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateRestaurantRequestDto createRestaurantDto)
        {
            var restaurantModel = createRestaurantDto.ToRestaurantFromCreateDTO();
            await _restaurantService.CreateAsync(restaurantModel);
            return Ok("Restaurant Created Successfully!");
        }


        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRestaurantRequestDto updateRestaurantDto)
        {
            var restaurantModel = await _restaurantService.UpdateAsync(id, updateRestaurantDto);

            if (restaurantModel == null)
            {
                return NotFound();
            }

            return Ok(updateRestaurantDto);
        }


        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var restaurantModel = await _restaurantService.DeleteAsync(id);

            if (restaurantModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}
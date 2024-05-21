using System;
using System.Collections.Generic;
using System.Linq;
using Dtos;
using Models;

namespace Mappers
{
    public static class FoodMappers
    {
        public static Food ToFoodFromCreateDTO(this CreateFoodRequestDto createFoodDto, int id)
        {
            return new Food
            {
                Title = createFoodDto.Title,
                Description = createFoodDto.Description,
                Price = createFoodDto.Price,
                Image = createFoodDto.Image,
                RestaurantId = id
            };
        }

        public static Food ToFoodFromUpdateDTO(this UpdateFoodRequestDto updateFoodDto, int id)
        {
            return new Food
            {
                Title = updateFoodDto.Title,
                Description = updateFoodDto.Description,
                Price = updateFoodDto.Price,
                Image = updateFoodDto.Image,
                RestaurantId = id
            };
        }
    }
}
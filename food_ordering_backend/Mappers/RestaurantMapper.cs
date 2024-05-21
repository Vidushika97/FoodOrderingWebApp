using System;
using System.Collections.Generic;
using System.Linq;
using Dtos;
using Models;

namespace Mappers
{
    public static class RestaurantMappers
    {
        public static RestaurantDto ToRestaurantDto(this Restaurant restaurantModel)
        {
            return new RestaurantDto
            {
                Id = restaurantModel.Id,
                Name = restaurantModel.Name,
                Description = restaurantModel.Description,
                Contact = restaurantModel.Contact,
                Image = restaurantModel.Image,
                Address = restaurantModel.Address
            };
        }

        public static Restaurant ToRestaurantFromCreateDTO(this CreateRestaurantRequestDto createRestaurantDto)
        {
            return new Restaurant
            {
                Name = createRestaurantDto.Name,
                Description = createRestaurantDto.Description,
                Contact = createRestaurantDto.Contact,
                Image = createRestaurantDto.Image,
                Address = createRestaurantDto.Address
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Dtos;

namespace Service
{
    public interface IRestaurantService
    {
        Task<List<Restaurant>> GetAllAsync();

        Task<Restaurant?> GetByIdAsync(int id);

        Task<Restaurant> CreateAsync(Restaurant restaurantModel);

        Task<Restaurant?> UpdateAsync(int id, UpdateRestaurantRequestDto updateRestaurantDto);

        Task<Restaurant?> DeleteAsync(int id);

        Task<bool> RestaurantExists(int id);
    }
}
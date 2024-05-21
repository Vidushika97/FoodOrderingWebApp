using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Models;
using Microsoft.EntityFrameworkCore;
using Dtos;


namespace Service
{
    public class RestaurantService : IRestaurantService
    {
        private readonly ApplicationDBContext _context;

        public RestaurantService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Restaurant>> GetAllAsync()
        {
            return await _context.Restaurants.ToListAsync();
        }

        public async Task<Restaurant?> GetByIdAsync(int id)
        {
            return await _context.Restaurants.Include(c => c.Foods).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Restaurant> CreateAsync(Restaurant restaurantModel)
        {
            await _context.Restaurants.AddAsync(restaurantModel);
            await _context.SaveChangesAsync();
            return restaurantModel;

        }

        public async Task<Restaurant?> UpdateAsync(int id, UpdateRestaurantRequestDto updateRestaurantDto)
        {
            var existingRestaurant = await _context.Restaurants.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRestaurant == null)
            {
                return null;
            }

            existingRestaurant.Name = updateRestaurantDto.Name;
            existingRestaurant.Description = updateRestaurantDto.Description;
            existingRestaurant.Contact = updateRestaurantDto.Contact;
            existingRestaurant.Image = updateRestaurantDto.Image;
            existingRestaurant.Address = updateRestaurantDto.Address;

            await _context.SaveChangesAsync();

            return existingRestaurant;
        }


        public async Task<Restaurant?> DeleteAsync(int id)
        {
            var restaurantModel = await _context.Restaurants.FirstOrDefaultAsync(x => x.Id == id);

            if (restaurantModel == null)
            {
                return null;
            }

            _context.Restaurants.Remove(restaurantModel);

            await _context.SaveChangesAsync();

            return restaurantModel;
        }

        public Task<bool> RestaurantExists(int id)
        {
            return _context.Restaurants.AnyAsync(s => s.Id == id);
        }

    }
}
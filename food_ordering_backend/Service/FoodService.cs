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
    public class FoodService : IFoodService
    {
        private readonly ApplicationDBContext _context;

        public FoodService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Food> CreateAsync(Food foodModel)
        {
            await _context.Foods.AddAsync(foodModel);
            await _context.SaveChangesAsync();
            return foodModel;
        }

        public async Task<Food?> UpdateAsync(int id, UpdateFoodRequestDto updateFoodDto)
        {
            var existingFood = await _context.Foods.FirstOrDefaultAsync(x => x.Id == id);

            if (existingFood == null)
            {
                return null;
            }

            existingFood.Title = updateFoodDto.Title;
            existingFood.Description = updateFoodDto.Description;
            existingFood.Price = updateFoodDto.Price;
            existingFood.Image = updateFoodDto.Image;
            existingFood.RestaurantId = id;

            await _context.SaveChangesAsync();

            return existingFood;
        }

        public async Task<Food?> DeleteAsync(int id)
        {
            var foodModel = await _context.Foods.FirstOrDefaultAsync(x => x.Id == id);

            if (foodModel == null)
            {
                return null;
            }

            _context.Foods.Remove(foodModel);

            await _context.SaveChangesAsync();

            return foodModel;
        }
    }
}
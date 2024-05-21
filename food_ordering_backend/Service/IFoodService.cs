using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Dtos;

namespace Service
{
    public interface IFoodService
    {
        Task<Food> CreateAsync(Food foodModel);

        Task<Food> UpdateAsync(int id, UpdateFoodRequestDto updateFoodDto);

        Task<Food?> DeleteAsync(int id);

    }
}
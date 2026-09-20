using System.Threading.Tasks;
using KitchenCatalogBackend.Database.Repositories.Interfaces;
using KitchenCatalogBackend.DTOs.IngredientDTOs;
using KitchenCatalogBackend.Extensions.DTOs.IngredientDTOs;
using KitchenCatalogBackend.Models;
using KitchenCatalogBackend.Services.Interfaces;

namespace KitchenCatalogBackend.Services;

public class IngredientService(IIngredientRepository repository) : IIngredientService
{
   public async Task<Result<Ingredient>> CreateIngredientAsync(CreateIngredientDto ingredientDto)
   {
      return await repository.InsertIngredientAsync(ingredientDto.FromCreateIngredientDto());
   }
}
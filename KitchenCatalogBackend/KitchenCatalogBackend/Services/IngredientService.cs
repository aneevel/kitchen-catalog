using System.Threading.Tasks;
using KitchenCatalogBackend.DTOs.IngredientDTOs;
using KitchenCatalogBackend.Services.Interfaces;

namespace KitchenCatalogBackend.Services;

public class IngredientService(IIngredientRepository repository) : IIngredientService
{
   public async Task<int> CreateIngredientAsync(CreateIngredientDto ingredientDto)
   {
      return await repository.InsertIngredientAsync(ingredientDto.FromCreateIngredientDto());
   }
}
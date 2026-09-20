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
      Result validationResult = Validate(ingredientDto);
      if (validationResult.IsFailure)
         return validationResult.Error;

      return await repository.InsertIngredientAsync(ingredientDto.FromCreateIngredientDto());
   }

   private static Result Validate(CreateIngredientDto ingredientDto)
   {
      if (string.IsNullOrWhiteSpace(ingredientDto.Name))
         return Error.IngredientNameEmpty;

      if (ingredientDto.Amount < 0)
         return Error.IngredientAmountNegative;

      if (ingredientDto.CostPerUnit < 0)
         return Error.IngredientCostPerUnitNegative;

      return Result.Success();
   }
}
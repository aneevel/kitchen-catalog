using System.Threading.Tasks;
using KitchenCatalogBackend.DTOs.IngredientDTOs;
using KitchenCatalogBackend.Models;

namespace KitchenCatalogBackend.Services.Interfaces;

public interface IIngredientService
{
   Task<Result<Ingredient>> CreateIngredientAsync(CreateIngredientDto ingredientDto);
}
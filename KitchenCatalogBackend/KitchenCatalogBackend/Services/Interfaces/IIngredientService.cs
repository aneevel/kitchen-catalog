using System.Threading.Tasks;
using KitchenCatalogBackend.DTOs.IngredientDTOs;

namespace KitchenCatalogBackend.Services.Interfaces;

public interface IIngredientService
{
   Task<int> CreateIngredientAsync(CreateIngredientDto ingredientDto);
}
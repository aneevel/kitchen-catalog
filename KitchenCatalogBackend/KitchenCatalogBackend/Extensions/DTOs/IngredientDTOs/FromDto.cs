using KitchenCatalogBackend.DTOs.IngredientDTOs;
using KitchenCatalogBackend.Models;

namespace KitchenCatalogBackend.Extensions.DTOs.IngredientDTOs;

public static class FromDto
{
    public static Ingredient FromCreateIngredientDto(this CreateIngredientDto dto)
    {
        return new Ingredient()
        {
            Name = dto!.Name, 
            Amount = dto.Amount, 
            CostPerUnit = dto.CostPerUnit
        };
    }
}
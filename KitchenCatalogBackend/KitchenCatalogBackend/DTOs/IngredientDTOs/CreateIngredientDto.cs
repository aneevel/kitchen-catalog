using System.ComponentModel.DataAnnotations;

namespace KitchenCatalogBackend.DTOs.IngredientDTOs;

public sealed class CreateIngredientDto(string name, int amount, float costPerUnit)
{
   [Required]
   public string Name { get; init; } = name;
   public int Amount { get; init; } = amount;
   public float CostPerUnit { get; init; } = costPerUnit;
}
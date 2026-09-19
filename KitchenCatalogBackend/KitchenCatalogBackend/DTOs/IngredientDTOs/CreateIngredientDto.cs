namespace KitchenCatalogBackend.DTOs.IngredientDTOs;

public sealed class CreateIngredientDto
{
   public string? Name { get; init; }
   public int Amount { get; init; }
   public float CostPerUnit { get; init; }
}
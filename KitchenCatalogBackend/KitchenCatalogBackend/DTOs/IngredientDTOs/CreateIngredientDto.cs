namespace KitchenCatalogBackend.DTOs.IngredientDTOs;

public class CreateIngredientDto()
{

   public CreateIngredientDto(string name, int amount, float costPerUnit) : this()
   {
      Name = name;
      Amount = amount;
      CostPerUnit = costPerUnit;
   }
   public string? Name { get; }
   public int Amount { get; }
   public float CostPerUnit { get; }
   
}
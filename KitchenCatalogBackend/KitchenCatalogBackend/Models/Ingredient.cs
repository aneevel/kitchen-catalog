using System.ComponentModel.DataAnnotations;

namespace KitchenCatalogBackend.Models;

public sealed class Ingredient
{
   [Required]
   public string Name { get; init; }
   public int? Amount { get; init; }
   public float? CostPerUnit  { get; init; }
}
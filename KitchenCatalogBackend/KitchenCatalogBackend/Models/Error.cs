namespace KitchenCatalogBackend.Models;

public sealed record Error(string Code, string Description)
{
   public static readonly Error None = new(string.Empty, string.Empty);

    public static Error InvalidCreationFormat(string code, string description) => new(code, description);

    public static readonly Error IngredientNameEmpty =
        InvalidCreationFormat("Ingredient.Name.Empty", "Name must not be empty");

    public static readonly Error IngredientAmountNegative =
        InvalidCreationFormat("Ingredient.Amount.Negative", "Amount must not be negative");

    public static readonly Error IngredientCostPerUnitNegative =
        InvalidCreationFormat("Ingredient.CostPerUnit.Negative", "Cost per unit must not be negative");
}

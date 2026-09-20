namespace KitchenCatalogBackend.Models;

public sealed record Error(string Code, string Description)
{
   public static readonly Error None = new(string.Empty, string.Empty);

   public static Error InvalidCreationFormat(string code, string description) =>
       new Error(code, description);
}

using System.Threading.Tasks;
using System.Net;
using KitchenCatalogBackend.DTOs.IngredientDTOs;
using Xunit;

namespace KitchenCatalogBackendTests;

public class CatalogServiceTest
{
    [Theory]
    [InlineData("Cucumber", 1, 1.99)]
    [InlineData("Eggs", 12, 0.99)]
    [InlineData("Yellow Onions", 3, 0.99)]
    public async Task AddIngredient_AddsIngredient(string ingredientName, int amount, float costPerUnit)
    {
        CreateIngredientDto ingredient = new(ingredientName, amount, costPerUnit);

        var response = _ingredientService.PostIngredientAsync(ingredient);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var created = await response.Content.ReadFromJsonAsync<IngredientResponse>();

        Assert.NotNull(created);
        Assert.True(created!.Id > 0);
        Assert.Equal(ingredient.Name, created.Name);
        Assert.Equal(ingredient.Amount, created.Amount);
        Assert.Equal(ingredient.CostPerUnit, created.CostPerUnit);

        Assert.NotNull(response.Headers.Location);

        Assert.EndsWith($"/ingredients/{created.Id}", response.Headers.Location!);

    }
}
using System.Threading.Tasks;
using System.Net;
using Xunit;

namespace KitchenCatalogBackendTests;

public class CatalogServiceTest
{
    [Fact]
    public async Task AddIngredient_AddsIngredient()
    {
        var ingredient =
        {
            Name = "cucumber",
            Amount = 1,
            CostPerUnit = 1.99f
        };
        
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
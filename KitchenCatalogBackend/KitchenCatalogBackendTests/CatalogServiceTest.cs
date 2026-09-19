using KitchenCatalogBackend.DTOs.IngredientDTOs;
using KitchenCatalogBackend.Models;
using Moq;

namespace KitchenCatalogBackendTests;

public class CatalogServiceTest
{
    private readonly IIngredientService _ingredientService;
    private readonly Mock<IIngredientRepository> _mockIngredientRepository;

    public CatalogServiceTest()
    {
        _mockIngredientRepository = new Mock<IIngredientRepository>();
        _ingredientService = new IngredientService(_mockIngredientRepository.Object);
    }
    
    [Fact]
    public async Task AddIngredient_ShouldReturnZero_WhenSuccessful()
    {
        const int expected = 0;

        _mockIngredientRepository
            .Setup(repo => repo.InsertIngredientAsync(It.IsAny<Ingredient>()))
            .ReturnsAsync(expected);

        int result = await _ingredientService.CreateIngredientAsync(new CreateIngredientDto());
        
        Assert.Equal(expected, result);
    }
}
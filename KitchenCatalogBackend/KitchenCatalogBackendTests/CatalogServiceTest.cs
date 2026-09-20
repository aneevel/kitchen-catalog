using KitchenCatalogBackend.Database.Repositories.Interfaces;
using KitchenCatalogBackend.DTOs.IngredientDTOs;
using KitchenCatalogBackend.Models;
using KitchenCatalogBackend.Services;
using KitchenCatalogBackend.Services.Interfaces;
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
    
    [Theory]
    [InlineData("Cucumber", 1, 0.99f)]
    [InlineData("Eggs", 12, 0.49f)]
    [InlineData("Pepperoni", 1, 0.99f)]
    public async Task AddIngredient_ShouldReturnAValidIngredientResult_WhenSuccessful(string name, int amount, float costPerUnit)
    {
        var dto = new CreateIngredientDto(name, amount, costPerUnit);
        Ingredient persisted = new() { Name = name, Amount = amount, CostPerUnit = costPerUnit };

        _mockIngredientRepository
            .Setup(repo => repo.InsertIngredientAsync(It.Is<Ingredient>(ingredient =>
                ingredient.Name == name &&
                ingredient.Amount == amount &&
                ingredient.CostPerUnit == costPerUnit)))
            .ReturnsAsync(persisted);

        Result<Ingredient> result = await _ingredientService.CreateIngredientAsync(dto);

        _mockIngredientRepository.Verify(repo => repo.InsertIngredientAsync(It.Is<Ingredient>(ingredient =>
            ingredient.Name == name &&
            ingredient.Amount == amount &&
            ingredient.CostPerUnit == costPerUnit)), Times.Once);

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
        Assert.Equal(name, result.Value.Name);
        Assert.Equal(amount, result.Value.Amount);
        Assert.Equal(costPerUnit, result.Value.CostPerUnit);
    }

    [Fact]
    public async Task AddIngredient_ShouldReturnAFailureResult_AndNotCallTheRepository_WhenNameIsEmpty()
    {
        await AssertValidationFailureAsync(
            new CreateIngredientDto("", 1, 0.99f),
            Error.IngredientNameEmpty);
    }

    [Fact]
    public async Task AddIngredient_ShouldReturnAFailureResult_AndNotCallTheRepository_WhenAmountIsNegative()
    {
        await AssertValidationFailureAsync(
            new CreateIngredientDto("Cucumber", -1, 0.99f),
            Error.IngredientAmountNegative);
    }

    [Fact]
    public async Task AddIngredient_ShouldReturnAFailureResult_AndNotCallTheRepository_WhenCostPerUnitIsNegative()
    {
        await AssertValidationFailureAsync(
            new CreateIngredientDto("Cucumber", 1, -0.01f),
            Error.IngredientCostPerUnitNegative);
    }

    private async Task AssertValidationFailureAsync(CreateIngredientDto dto, Error expectedError)
    {
        Result<Ingredient> result = await _ingredientService.CreateIngredientAsync(dto);

        Assert.True(result.IsFailure);
        Assert.Equal(expectedError, result.Error);
        _mockIngredientRepository.Verify(
            repo => repo.InsertIngredientAsync(It.IsAny<Ingredient>()),
            Times.Never);
    }
}
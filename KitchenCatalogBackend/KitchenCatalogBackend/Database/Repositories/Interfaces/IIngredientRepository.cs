using System.Threading.Tasks;
using KitchenCatalogBackend.Models;

namespace KitchenCatalogBackend.Database.Repositories.Interfaces;

public interface IIngredientRepository
{
   Task<Result<Ingredient>> InsertIngredientAsync(Ingredient ingredient); 
}
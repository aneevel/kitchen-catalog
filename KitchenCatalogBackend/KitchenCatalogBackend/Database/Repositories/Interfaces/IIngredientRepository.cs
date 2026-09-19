using System.Threading.Tasks;
using KitchenCatalogBackend.Models;

namespace KitchenCatalogBackend.Database.Repositories.Interfaces;

public interface IIngredientRepository
{
   Task<int> InsertIngredientAsync(Ingredient ingredient); 
}
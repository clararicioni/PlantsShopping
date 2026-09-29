using PlantsShopping.Web.Models;

namespace PlantsShopping.Web.Services.IServices
{
    public interface IPlantService
    {
        Task<IEnumerable<PlantModel>> FindAllPlants();
        Task<PlantModel> FindPlantById(long id);
        Task<PlantModel> CreatePlant(PlantModel plant);
        Task<PlantModel> UpdatePlant(PlantModel plant);
        Task<bool> DeletePlantById(long id);
    }
}

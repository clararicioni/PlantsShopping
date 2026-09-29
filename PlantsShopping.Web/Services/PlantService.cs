using PlantsShopping.Web.Models;
using PlantsShopping.Web.Services.IServices;
using PlantsShopping.Web.Utils;

namespace PlantsShopping.Web.Services
{
    public class PlantService : IPlantService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/plant";
        public PlantService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<PlantModel>> FindAllPlants()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<PlantModel>>();
        }
        public async Task<PlantModel> FindPlantById(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<PlantModel>();
        }
        public async Task<PlantModel> CreatePlant(PlantModel plant)
        {
            var response = await _client.PostAsJson(BasePath, plant);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<PlantModel>();
            else throw new Exception("Something went wrong.");
        }
        public async Task<PlantModel> UpdatePlant(PlantModel plant)
        {
            var response = await _client.PutAsJson($"{BasePath}/{plant.Id}", plant);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<PlantModel>();
            else throw new Exception("Something went wrong.");
        }

        public async Task<bool> DeletePlantById(long id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else throw new Exception("Something went wrong.");
        }
    }
}

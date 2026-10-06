using Microsoft.AspNetCore.Mvc;
using PlantsShopping.Web.Services.IServices;

namespace PlantsShopping.Web.Controllers
{
    public class PlantController : Controller
    {
        private readonly IPlantService _plantService;
        public PlantController(IPlantService plantService)
        {
            _plantService = plantService ?? throw new ArgumentNullException(nameof(plantService));
        }
        public async Task<IActionResult> PlantIndex()
        {
            var plants = _plantService.FindAllPlants();
            return View(plants);
        }
    }
}

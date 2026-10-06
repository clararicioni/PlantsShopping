using Microsoft.AspNetCore.Mvc;
using PlantsShopping.Web.Models;
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
        public async Task<IActionResult> PlantCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PlantCreate(PlantModel model)
        {
            if(ModelState.IsValid)
            {
                var responde = await _plantService.CreatePlant(model);
                if (responde != null) return RedirectToAction(
                                                nameof(PlantIndex));
            }
            return View(model);
        }
    }
}

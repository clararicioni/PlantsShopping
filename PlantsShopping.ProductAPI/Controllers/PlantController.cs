using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantsShopping.ProductAPI.Data.ValueObjects;
using PlantsShopping.ProductAPI.Repository;

namespace PlantsShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        private IPlantRepository _repository;
        public PlantController(IPlantRepository repository)
        {
            _repository = repository ?? throw new 
                ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantVO>>> FindAll()
        {
            var plants = await _repository.FindAll();
            return Ok(plants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlantVO>> FindById(long id)
        {
            var plant = await _repository.FindById(id);
            if (plant == null) return NotFound();
            return Ok(plant);
        }

        [HttpPost]
        public async Task<ActionResult<PlantVO>> Create(PlantVO vo)
        {
            if (vo == null) return BadRequest();
            var plant = await _repository.Create(vo);
            return Ok(plant);
        }

        [HttpPut]
        public async Task<ActionResult<PlantVO>> Update(PlantVO vo)
        {
            if (vo == null) return BadRequest();
            var plant = await _repository.Update(vo);
            return Ok(plant);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}

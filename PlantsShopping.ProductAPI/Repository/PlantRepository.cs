using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PlantsShopping.ProductAPI.Data.ValueObjects;
using PlantsShopping.ProductAPI.Model;
using PlantsShopping.ProductAPI.Model.Context;
using System.Numerics;

namespace PlantsShopping.ProductAPI.Repository
{
    public class PlantRepository : IPlantRepository
    {
        private readonly PostgreContext _context;
        private IMapper _mapper;
        public PlantRepository(PostgreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PlantVO>> FindAll()
        {
            List<Plant> plants = await _context.Plants.ToListAsync();
            return _mapper.Map<List<PlantVO>>(plants);
        }

        public async Task<PlantVO> FindById(long id)
        {
            Plant plant = await _context.Plants.Where(p => p.Id == id).FirstOrDefaultAsync() ?? new Plant();
            return _mapper.Map<PlantVO>(plant);
        }
        public async Task<PlantVO> Create(PlantVO vo)
        {
            Plant plant = _mapper.Map<Plant>(vo);
            _context.Plants.Add(plant);
            await _context.SaveChangesAsync();
            return _mapper.Map<PlantVO>(plant);
        }
        public async Task<PlantVO> Update(PlantVO vo)
        {
            Plant plant = _mapper.Map<Plant>(vo);
            _context.Plants.Update(plant);
            await _context.SaveChangesAsync();
            return _mapper.Map<PlantVO>(plant);
        }
        public async Task<bool> Delete(long id)
        {
            try
            {
                Plant plant = await _context.Plants.Where(p => p.Id == id).FirstOrDefaultAsync() ?? new Plant();
                if (plant != null)
                {
                    _context.Plants.Remove(plant);
                    await _context.SaveChangesAsync();
                }
                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
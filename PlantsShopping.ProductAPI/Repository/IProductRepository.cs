using PlantsShopping.ProductAPI.Data.ValueObjects;

namespace PlantsShopping.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<PlantVO>> FindAll();
        Task<PlantVO> FindById(long id);
        Task<PlantVO> Create(PlantVO vo);
        Task<PlantVO> Update(PlantVO vo);
        Task Delete(long id);
    }
}

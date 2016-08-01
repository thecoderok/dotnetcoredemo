using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Data
{
    public class ProductModel
    {
        public int Id {get; set;}
        
        public string Name {get;set;}
    }

    public interface IProductsRepository
    {
        IList<ProductModel> ListAll();

        ProductModel FindById(int id);
    }

    public class MockProductsRepository : IProductsRepository
    {
        private readonly List<ProductModel> mockRepo = new List<ProductModel>()
        {
            new ProductModel()
            {
                Id = 0,
                Name = "Micorosft Surface book"
            },
            new ProductModel()
            {
                Id = 1,
                Name = "iPhone 6S"
            }
        };

        public ProductModel FindById(int id)
        {
            return this.mockRepo.FirstOrDefault(t=> t.Id == id);
        }

        public IList<ProductModel> ListAll()
        {
            return this.mockRepo;
        }
    }
}

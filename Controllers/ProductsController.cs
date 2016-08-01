using Microsoft.AspNetCore.Mvc;
using WebApplication.Data;

namespace WebApplication.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsRepository m_productsRepository;

        public ProductsController(IProductsRepository repo)
        {
            this.m_productsRepository = repo;
        }

        public IActionResult Index()
        {
            return View(this.m_productsRepository.ListAll());
        }

        public IActionResult Show(int productId)
        {
            return View(this.m_productsRepository.FindById(productId));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ViewDataFromDB.Data;

namespace ViewDataFromDB.Controllers
{
    public class ProductsController : Controller
    {
        private ProductDbContext _context;

        public ProductsController(ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.products.ToList();

            ViewBag.Products = products;
            return View();
        }
    }
}

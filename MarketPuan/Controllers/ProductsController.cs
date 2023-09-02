using MarketPuan.Data;
using Microsoft.AspNetCore.Mvc;

namespace MarketPuan.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [Route("products")]
        public IActionResult Index()
        {
            var products = _productRepository.GetProducts();
            return View(products);
        }

        [Route("products/{id}")]
        public IActionResult Details(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound(); // Display a 404 page if the product doesn't exist
            }
            return View(product);
        }

        [Route("products/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("products/store")]
        public IActionResult Store(Product newProduct)
        {
            if (ModelState.IsValid)
            {
                _productRepository.AddProduct(newProduct);
                return RedirectToAction("Index");
            }
            return View("Create", newProduct);
        }

        [Route("products/edit/{id}")]
        public IActionResult Edit(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound(); // Display a 404 page if the product doesn't exist
            }
            return View(product);
        }

        [HttpPost]
        [Route("products/update/{id}")]
        public IActionResult Update(int id, Product updatedProduct)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = _productRepository.GetProductById(id);
                if (existingProduct != null)
                {
                    existingProduct.Name = updatedProduct.Name;
                    // Update other properties as needed
                    _productRepository.UpdateProduct(existingProduct);
                    return RedirectToAction("Index");
                }
                return NotFound(); // Display a 404 page if the product doesn't exist
            }
            return View("Edit", updatedProduct);
        }

        [Route("products/delete/{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound(); // Display a 404 page if the product doesn't exist
            }
            return View(product);
        }

        [HttpPost]
        [Route("products/destroy/{id}")]
        public IActionResult Destroy(int id)
        {
            _productRepository.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}

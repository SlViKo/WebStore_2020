using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStore.DomainNew;
using WebStore.infrastructure.interfaces;
using WebStore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebStore.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductService _productService;

        public CatalogController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Shop(int? categoryId, int? brandId)
        {
            var products = _productService.GetProducts(
                new ProductFilter { BrandId = brandId, CategoryId = categoryId });

            var model = new CatalogViewModel()
            {
                BrandId = brandId,
                CategoryId = categoryId,
                Products = products.Select(p => new ProductViewModel()
                    {
                        Id = p.Id,
                        ImageUrl = p.ImageUrl,
                        Name = p.Name,
                        Order = p.Order,
                        Price = p.Price
                    }).OrderBy(p => p.Order)
                    .ToList()
            };

            return View(model);
        }

        public IActionResult ProductDetails(int id)
        {
            var product = _productService.GetProductById(id);
            var model = new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Brand = _productService.GetBrands().FirstOrDefault(x => x.Id == product.BrandId).Name ?? "Отсутствует",
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Order = product.Order,

            };
            return View(model);
        }


    }
}
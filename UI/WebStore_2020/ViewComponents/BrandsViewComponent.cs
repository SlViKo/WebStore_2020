using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.infrastructure.interfaces;
using WebStore.Models;

namespace WebStore.ViewComponents
{
    public class BrandsViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public BrandsViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var _brands = GetBrands();
            return View(_brands);
        }

        private List<BrandViewModel> GetBrands()
        {

            var brands = _productService.GetBrands().ToArray();
            var brandsViewModelList = new List<BrandViewModel>();

            foreach (var brand in brands)
            {
                brandsViewModelList.Add(new BrandViewModel()
                {
                    Id = brand.Id,
                    Name = brand.Name,
                    Order = brand.Order,
                    ProductsCount = 0
                });
            }

            brandsViewModelList = brandsViewModelList.OrderBy(c => c.Order).ToList();
            return brandsViewModelList;
        }
    }
}
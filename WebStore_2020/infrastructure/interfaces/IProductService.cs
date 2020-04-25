using System.Collections.Generic;
using WebStore.DomainNew;
using WebStore.DomainNew.Entities;

namespace WebStore.infrastructure.interfaces
{
    public interface IProductService
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Brand> GetBrands();
        IEnumerable<Product> GetProducts(ProductFilter filter);
    }
}

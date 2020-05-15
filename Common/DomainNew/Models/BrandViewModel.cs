namespace WebStore.DomainNew.Models
{
    public class BrandViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Количество товаров бренда
        /// </summary>
        public int ProductsCount { get; set; }


        public int Order { get; set; }
    }
}

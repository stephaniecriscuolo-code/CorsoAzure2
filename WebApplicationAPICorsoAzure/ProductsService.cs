namespace WebApplicationAPICorsoAzure
{
    public class ProductsService : IProducts
    {
        public IEnumerable<Products> GetAll()
        {
            return new List<Products>
            {
                new Products {Id=1, Name = "1", Category="1" },
                new Products {Id=2, Name = "2", Category="2" }
            };
        }

    }
}

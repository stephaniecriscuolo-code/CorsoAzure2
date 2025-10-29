using WebApplicationAPICorsoAzure;
namespace WebApplicationAPICorsoAzure
{
    public class Products
    {
        //public ChiaveComplessa Id { get; set; } = new ChiaveComplessa();
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;//public required string Name { get; set; } > required forza ad assegnare un valore
        public string Category  { get; set; } = string.Empty;
    }

    public class ChiaveComplessa
    {
        public int Id1 { get; set; }
        public int Id2 { get; set; }
        public int Id3 { get; set; }
    }
}

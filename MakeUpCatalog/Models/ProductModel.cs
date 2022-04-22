namespace MakeupCatalog.Model
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public string Brand { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public int MakeupTypeId { get; set; }

        public MakeupTypeModel MakeupType { get; set; }

        public ProductModel()
        {
        }

        public ProductModel(int productId, string name, string color, double price)
        {
            ProductId = productId;
            Name = name;
            Color = color;
            Price = price;
        }
    }
}
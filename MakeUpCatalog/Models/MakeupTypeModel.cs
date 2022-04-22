using System.Collections.Generic;

namespace MakeupCatalog.Model
{
    public class MakeupTypeModel
    {
        public int MakeupTypeId { get; set; }

        public string Name { get; set; }

        public List<ProductModel> Product { get; set; }

        public MakeupTypeModel()
        {
            Product = new List<ProductModel>();
        }
    }
}
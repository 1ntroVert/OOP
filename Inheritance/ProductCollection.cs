using System.Collections.Generic;

namespace Inheritance
{
    class ProductCollection
    {
        private DataStorage dataStorage;
        private List<Product> products = new List<Product>();

        public ProductCollection(DataStorage dataStorage)
        {
            this.dataStorage = dataStorage;
        }
        
        public List<Product> GetProducts()
        {
            return products;
        }

        public void LoadProducts()
        {
            products = dataStorage.LoadProducs();
        }
    }
}

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Inheritance
{
    class ProductCollection
    {
        private DataStorage dataStorage;
        private ObservableCollection<Product> products = new ObservableCollection<Product>();

        public ProductCollection(DataStorage dataStorage)
        {
            this.dataStorage = dataStorage;
        }
        
        public ObservableCollection<Product> GetProducts()
        {
            return products;
        }

        public void LoadProducts()
        {
            products = new ObservableCollection<Product>(dataStorage.LoadProducs());
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            products.Remove(product);
        }
    }
}

using System.Collections.Generic;

namespace Inheritance
{
    interface DataStorage
    {
        List<Product> LoadProducs();

        void SaveProducs(List<Product> products);
    }
}

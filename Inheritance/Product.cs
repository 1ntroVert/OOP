namespace Inheritance
{
    abstract class Product
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public string Barcode { get; set; }
        public abstract string AdditionalInfo { get; }

        public Product(string title, double price, string barcode)
        {
            Title = title;
            Price = price;
            Barcode = barcode;
        }
    }
}

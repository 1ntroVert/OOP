using System.Text;

namespace Inheritance
{
    class Book : Product
    {
        public string Author { get; set; }
        public long PagesCount { get; set; }

        public override string AdditionalInfo
        {
            get
            {
                return new StringBuilder()
                    .Append("автор - ")
                    .Append(Author)
                    .Append(", ")
                    .Append("число страниц - ")
                    .Append(PagesCount)
                    .ToString();
            }
        }

        public Book(
            string title,
            double price,
            string barcode,
            string author,
            long pagesCount) : base(title, price, barcode)
        {
            PagesCount = pagesCount;
            Author = author;
        }
    }
}

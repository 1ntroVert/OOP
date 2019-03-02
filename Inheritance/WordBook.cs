namespace Inheritance
{
    class WordBook : Book
    {
        public string SourceLanguage { get; set; }
        public string DestinationLanguage { get; set; }

        public WordBook(
            string title,
            double price,
            string barcode,
            string author,
            int pagesCount,
            string sourceLanguage,
            string destinationLanguage) : base(title, price, barcode, author, pagesCount)
        {
            SourceLanguage = sourceLanguage;
            DestinationLanguage = destinationLanguage;
        }
    }
}

namespace Inheritance
{
    class СookingBook : Book
    {
        public string MainIngredient { get; set; }

        public СookingBook(
            string title,
            double price,
            string barcode,
            string author,
            int pagesCount,
            string mainIngredient) : base(title, price, barcode, author, pagesCount)
        {
            MainIngredient = MainIngredient;
        }
    }
}

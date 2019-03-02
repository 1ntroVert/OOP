using System.Text;

namespace Inheritance
{
    class ProgrammingBook : Book
    {
        public string ProgrammingLanguage { get; set; }

        public override string AdditionalInfo
        {
            get
            {
                return new StringBuilder(base.AdditionalInfo)
                    .Append(", ")
                    .Append("язык программирования - ")
                    .Append(ProgrammingLanguage)
                    .ToString();
            }
        }

        public ProgrammingBook(
            string title,
            double price,
            string barcode,
            string author,
            int pagesCount,
            string programmingLanguage) : base(title, price, barcode, author, pagesCount)
        {
            ProgrammingLanguage = programmingLanguage;
        }
    }
}

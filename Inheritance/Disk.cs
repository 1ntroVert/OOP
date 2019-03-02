using System.Text;

namespace Inheritance
{
    class Disk : Product
    {
        public DiskType Type { get; set; }
        public string Content { get; set; }

        public override string AdditionalInfo
        {
            get
            {
                return new StringBuilder()
                    .Append("тип - ")
                    .Append(Type)
                    .Append(", ")
                    .Append("содержимое - ")
                    .Append(Content)
                    .ToString();
            }
        }

        public Disk(
            string title,
            double price,
            string barcode,
            DiskType type,
            string content) : base(title, price, barcode)
        {
            Type = type;
            Content = content;
        }
    }
}

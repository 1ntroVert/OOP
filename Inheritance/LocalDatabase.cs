using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Inheritance
{
    class LocalDatabase : DataStorage
    {
        private SQLiteConnection dbConnection;

        public LocalDatabase(string path)
        {
            dbConnection = new SQLiteConnection($"Data Source={path}; Version = 3;");
        }

        public List<Product> LoadProducs()
        {
            List<Product> products = new List<Product>();
            products.AddRange(GetBooks());
            products.AddRange(GetDisks());
            return products;
        }

        public void SaveProducs(List<Product> products)
        {
            throw new NotImplementedException();
        }

        private List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();

            dbConnection.Open();
            string sql = "SELECT * FROM book";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                long id = (long)reader["id"];
                string title = (string)reader["title"];
                double price = (double)reader["price"];
                string barcode = (string)reader["barcode"];
                string author = (string)reader["author"];
                long pagesCount = (long)reader["pages_count"];

                books.Add(new Book(title, price, barcode, author, pagesCount));
            }
            dbConnection.Close();

            return books;
        }

        private List<Disk> GetDisks()
        {
            List<Disk> disks = new List<Disk>();

            dbConnection.Open();
            string sql = "SELECT * FROM disk";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                long id = (long)reader["id"];
                string title = (string)reader["title"];
                double price = (double)reader["price"];
                string barcode = (string)reader["barcode"];
                string type = (string)reader["type"];
                string content = (string)reader["content"];

                disks.Add(new Disk(title, price, barcode, (DiskType)Enum.Parse(typeof(DiskType), type), content));
            }
            dbConnection.Close();

            return disks;
        }
    }
}

using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BookStoreAli.Models
{
    public class BookDbDapper
    {
        SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-THUOFTE\SQLEXPRESS; Initial Catalog = MVCFramework; User id=MVCProject; Password=0147");

        public async Task<IEnumerable<Book>> GetBooks()
        {
            var books = await con.QueryAsync<Book>("select * from Book");
            return books;
            //inner join

            string query;
            query = "select * from book b inner join Authors a on b.AuthorId=a.Id";
            var books1 = con.Query<Book>(query);
            var books2 = con.QueryMultiple(query);
            var books3 = con.Query<Book, Author, Book>(query,
                (a, b) =>
                {
                    Book book = a;
                    a.Author_test = b;
                    return book;

                });


           
        }

        public bool InsertBook(Book book)
        {

            string query = "insert into book(Name,Price,Category,Author,Available) values(@Name,@Price,@Category,@Author,@Available);" +
                "select cast(scope_identity() as int);";
            int res = 0;
            try
            {
                res = con.Query<int>(query, new
                {
                    @Name = book.Name,
                    @Price = book.Price,
                    @Category = book.Category,
                    @Author = book.Author,
                    @Available = Convert.ToString(book.Available)

                }).Single();

                //res   = con.Query<int>(query,  book ).Single();

            }
            catch (Exception ex)
            {
                res = 0;
            }



            //int count = 0;
            //SqlCommand cmd = new SqlCommand("sp_Book", con);
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Name", book.Name);
            //cmd.Parameters.AddWithValue("@Price", book.Price);
            //cmd.Parameters.AddWithValue("@Category", book.Category);
            //cmd.Parameters.AddWithValue("@Author", book.Author);
            //cmd.Parameters.AddWithValue("@Available", Convert.ToString(book.Available));
            //cmd.Parameters.AddWithValue("@Query", "Insert");
            //con.Open();
            //count = cmd.ExecuteNonQuery();
            //con.Close();

            return res > 0;
        }

        public Book GetBook(int Id)
        {
            string query = "Select * from book where Id=@Id";
            var book = con.Query<Book>(query, new { Id }).Single();
            //Book book = null;
            //DataTable dt = new DataTable();

            //SqlCommand cmd = new SqlCommand("sp_Book", con);
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Id", Id);
            //cmd.Parameters.AddWithValue("@Query", "SelectBook");
            //SqlDataAdapter sa = new SqlDataAdapter(cmd);
            //sa.Fill(dt);
            //foreach (DataRow item in dt.Rows)
            //{
            //    book = new Book
            //    {
            //        Id = Convert.ToInt32(item["Id"]),
            //        Name = Convert.ToString(item["Name"]),
            //        Price = Convert.ToInt32(item["Price"]),
            //        Category = Convert.ToString(item["Category"]),
            //        Author = Convert.ToString(item["Author"]),
            //        Available = Convert.ToBoolean(item["Available"])

            //    };

            //}

            return book;
        }

        public bool Update(Book book)
        {
            int count = 0;
            string query = "update book set Name=@Name,Price=@Price,Category=@Category,Author=@Author,Available=@Available where Id=@Id";
            count = con.Execute(query, new
            {
                book.Name,
                book.Price,
                book.Category,
                book.Author,
                @Available = Convert.ToString(book.Available),
                book.Id
            });

            ///  with inner join /////
            ///  





            //SqlCommand cmd = new SqlCommand("sp_Book", con);
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Id", book.Id);
            //cmd.Parameters.AddWithValue("@Name", book.Name);
            //cmd.Parameters.AddWithValue("@Price", book.Price);
            //cmd.Parameters.AddWithValue("@Category", book.Category);
            //cmd.Parameters.AddWithValue("@Author", book.Author);
            //cmd.Parameters.AddWithValue("@Available", Convert.ToString(book.Available));
            //cmd.Parameters.AddWithValue("@Query", "Update");
            //con.Open();
            //count = cmd.ExecuteNonQuery();
            //con.Close();


            return count > 0;
        }
        public bool Delete(int? Id)
        {
            int count = 0;
            string query = "delete from book where Id=@Id";
            count = con.Execute(query, new
            {
                Id
            });
            //SqlCommand cmd = new SqlCommand("sp_Book", con);
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Id", Id);

            //cmd.Parameters.AddWithValue("@Query", "Delete");
            //con.Open();
            //count = cmd.ExecuteNonQuery();
            //con.Close();


            return count > 0;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace BookStoreAli.Models
{
    public class BookDb
    {
        SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-THUOFTE\SQLEXPRESS; Initial Catalog = MVCFramework; Integrated Security=true; ");


        public IEnumerable<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand("sp_Book", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Query", "SelectBooks");

            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                Book book = new Book
                {
                    Id=Convert.ToInt32(item["Id"]),
                    Name = Convert.ToString(item["Name"]),
                    Price = Convert.ToInt32(item["Price"]),
                    Category = Convert.ToString(item["Category"]),
                    Author = Convert.ToString(item["Author"]),
                    Available = Convert.ToBoolean(item["Available"])

                };
                books.Add(book);
            }

            return books;
        }



        public bool InsertBook(Book book)
        {
           
            int count = 0;
            SqlCommand cmd = new SqlCommand("sp_Book", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", book.Name);
            cmd.Parameters.AddWithValue("@Price", book.Price);
            cmd.Parameters.AddWithValue("@Category", book.Category);
            cmd.Parameters.AddWithValue("@Author", book.Author);
            cmd.Parameters.AddWithValue("@Available",Convert.ToString( book.Available));
            cmd.Parameters.AddWithValue("@Query","Insert");
            con.Open();
            count = cmd.ExecuteNonQuery();
            con.Close();

            return count>0;
        }

        public Book GetBook(int Id)
        {
            Book book=null ;
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand("sp_Book", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id",Id);
            cmd.Parameters.AddWithValue("@Query", "SelectBook");
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                book = new Book
                {
                    Id = Convert.ToInt32(item["Id"]),
                    Name = Convert.ToString(item["Name"]),
                    Price = Convert.ToInt32(item["Price"]),
                    Category = Convert.ToString(item["Category"]),
                    Author = Convert.ToString(item["Author"]),
                    Available = Convert.ToBoolean(item["Available"])

                };
            
            }

            return book;
        }

        public bool Update(Book book)
        {
           int count = 0;

            SqlCommand cmd = new SqlCommand("sp_Book", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", book.Id);
            cmd.Parameters.AddWithValue("@Name", book.Name);
            cmd.Parameters.AddWithValue("@Price", book.Price);
            cmd.Parameters.AddWithValue("@Category", book.Category);
            cmd.Parameters.AddWithValue("@Author", book.Author);
            cmd.Parameters.AddWithValue("@Available", Convert.ToString(book.Available));
            cmd.Parameters.AddWithValue("@Query", "Update");
            con.Open();
           count = cmd.ExecuteNonQuery();
            con.Close();
          

            return count>0;
        }
        public bool Delete(int? Id)
        {
            int count = 0;

            SqlCommand cmd = new SqlCommand("sp_Book", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
           
            cmd.Parameters.AddWithValue("@Query", "Delete");
            con.Open();
            count = cmd.ExecuteNonQuery();
            con.Close();


            return count > 0;
        }
    }
}
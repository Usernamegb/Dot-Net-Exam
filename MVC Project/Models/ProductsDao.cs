using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _210940320041.Models
{
    public class ProductsDao
    {
        SqlConnection conn = new SqlConnection();
        public void OpenConnection()
        {

            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DOT-NET Exam;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn.Open();
        }
        public List<Products> getAllProducts()
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "getAllProducts";
            SqlDataReader dr= cmd.ExecuteReader();
            List<Products> listOfProducts = new List<Products>();
            while (dr.Read())
            {
                listOfProducts.Add(new Products { ProductId = (int)dr["ProductId"], ProductName = (string)dr["ProductName"], Rate = (decimal)dr["Rate"], Description = (string)dr["Description"], CategoryName = (string)dr["CategoryName"] });
            }
            dr.Close();
            conn.Close();
            return listOfProducts;
        }
        public Products getProductById(int ProductId)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "getProductById";
            cmd.Parameters.AddWithValue("@ProductId", ProductId);
            SqlDataReader dr = cmd.ExecuteReader();
            Products p = new Products();
            while (dr.Read())
            {
                p.ProductId = (int)dr["ProductId"];
                p.ProductName = (string)dr["ProductName"];
                p.Rate = (decimal)dr["Rate"];
                p.CategoryName = (string)dr["CategoryName"];
                p.Description = (string)dr["Description"];
            }
            dr.Close();
            conn.Close();
            return p;
        }
        public void updateProduct(int id,Products p)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "updateProduct";
            cmd.Parameters.AddWithValue("@ProductId", id);
            cmd.Parameters.AddWithValue("@ProductName", p.ProductName);
            cmd.Parameters.AddWithValue("@Rate", p.Rate);
            cmd.Parameters.AddWithValue("@CategoryName", p.CategoryName);
            cmd.Parameters.AddWithValue("@Description", p.Description);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
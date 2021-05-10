using RegisterAndLoginApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAndLoginApp.Services
{
    public class ProductsDAO : IProductDataService
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int Delete(ProductModel product)
        {
            int newIdNumber = -1;
            string sqlStatment = "DELETE FROM dbo.Products WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatment, connection);
               
                command.Parameters.AddWithValue("@Id", product.Id);
                try
                {
                    connection.Open();

                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            return newIdNumber;
        }

        public List<ProductModel> GetAllProduct()
        {
            List<ProductModel> foundProduct = new List<ProductModel>();
            string sqlStatment = "SELECT * FROM dbo.Products";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatment, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        foundProduct.Add(new ProductModel { Id = (int)reader[0], Name = (string)reader[1], Price = (decimal)reader[2], Description = (string)reader[3] });

                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            return foundProduct;
        }

        public ProductModel GetProductById(int Id)
        {
            ProductModel foundProduct = null;
            string sqlStatment = "SELECT * FROM dbo.Products WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatment, connection);
                command.Parameters.AddWithValue("@Id", Id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundProduct = new ProductModel { Id = (int)reader[0], Name = (string)reader[1], Price = (decimal)reader[2], Description = (string)reader[3] };

                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            return foundProduct;
        }

        public int Insert(ProductModel product)
        {
            int newIdNumber = -1;
            string sqlStatment = "INSERT INTO dbo.Products (Name, Price, Description) VALUES (@Name,@Price,@Description)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatment, connection);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Id", product.Id);
                try
                {
                    connection.Open();

                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            return newIdNumber;
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            List<ProductModel> foundProduct = new List<ProductModel>();
            string sqlStatment = "SELECT * FROM dbo.Products WHERE Name LIKE @Name";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatment, connection);
                command.Parameters.AddWithValue("@Name", '%' + searchTerm + '%');
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundProduct.Add(new ProductModel { Id = (int)reader[0], Name = (string)reader[1], Price = (decimal)reader[2], Description = (string)reader[3] });

                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            return foundProduct;
        }

        public int Update(ProductModel product)
        {
            int newIdNumber = -1;
            string sqlStatment = "UPDATE dbo.Products SET Name = @Name, Price = @Price, Description = @Description WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatment, connection);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Id", product.Id);
                try
                {
                    connection.Open();

                    newIdNumber = Convert.ToInt32( command.ExecuteScalar());

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            return newIdNumber;
        }
    }
}

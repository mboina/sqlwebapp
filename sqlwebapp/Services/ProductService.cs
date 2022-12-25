using sqlwebapp.Models;
using System.Data.SqlClient;

namespace sqlwebapp.Services
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;

        ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //private static string db_source = "mnbdbserver.database.windows.net"; 
        //private static string db_username = "mnbdbadmin";
        //private static string db_pwd = "MnboinaNov!2110";
        //private static string db_database = "mnbdb";

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("SQLConnection"));
        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();

            List<Product> _product_lst = new List<Product>();

            string statement = "SELECT ProductID, ProductName, Quantity from Products";

            conn.Open();

            SqlCommand cmd = new SqlCommand(statement, conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };
                    _product_lst.Add(product);
                }
                conn.Close();
                return _product_lst;
            }

        }
    }


}

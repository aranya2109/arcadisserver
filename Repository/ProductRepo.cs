using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DatabaseFactory;
using Model;

namespace Repository
{
    public class ProductRepo : IProductRepo
    {
        private DbFactory _dbFactory;
        private IDbConnection _connection;

        public ProductRepo()
        {
            _dbFactory = DbFactory.GetInstance();
            _connection = _dbFactory.GetConnection(DbServer.SQLSERVER);
        }

        public int AddProduct(Product product)
        {
            string sql = @"insert into product (Title, Cost, Quantity)
                            values(@title,@cost, @quantity)";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@cost", product.Cost);
            parameters.Add("@title", product.Title);
            parameters.Add("@quantity", product.Quantity);
            return _dbFactory.ExecuteNonQuery(_connection, sql, parameters);
        }

        public List<Product> GetAllProducts()
        {
            string query = @"Select * from Product";
            DynamicParameters parameters = new DynamicParameters();
            return _dbFactory.GetData<Product>(_connection, new CommandDefinition(query, parameters))?.ToList();
        }

        public int UpdateProduct(Product product)
        {
            string sql = @"update product set Cost=@cost, Title=@title, Quantity=@quantity
                            where Id=@id";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", product.Id);
            parameters.Add("@cost", product.Cost);
            parameters.Add("@title", product.Title);
            parameters.Add("@quantity", product.Quantity);
            return _dbFactory.ExecuteNonQuery(_connection, sql, parameters);
        }
    }
}

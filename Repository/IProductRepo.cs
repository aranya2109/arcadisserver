using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IProductRepo
    {
        List<Product> GetAllProducts();
        int UpdateProduct(Product product);
        int AddProduct(Product product);
    }
}

using Model;
using Repository;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ArcadisProductApi.Controllers
{
    [EnableCors("*","*","*")]
    public class ProductController : ApiController
    {
        private IProductRepo _productRepo;

        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        
        [Route("products")]
        [HttpGet]
        public HttpResponseMessage GetProducts()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { Response = _productRepo.GetAllProducts() });
        }

        [Route("addproduct")]
        [HttpPost]
        public HttpResponseMessage AddProduct(Product product)
        {
            _productRepo.AddProduct(product);
            return Request.CreateResponse(HttpStatusCode.Created, new { Response = "Product Added" });
        }

        [Route("updateproduct")]
        [HttpPost]
        public HttpResponseMessage UpdateProduct(Product product)
        {
            _productRepo.UpdateProduct(product);
            return Request.CreateResponse(HttpStatusCode.Created, new { Response = "Product Updated" });
        }
    }
}

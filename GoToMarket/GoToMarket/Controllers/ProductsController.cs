using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace GoToMarket.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public List<Product> Get() 
        { 
            return MysqlClient.GetProductsInMysql();
        }

        [HttpGet("{id}")]
        public Product Get(string id)
        {
            return MysqlClient.GetProductByIdInMysql(id);
        }

        [HttpPost]
        public void Post([FromBody] Product product)
        {
            MysqlClient.InsertNewProductInMysql(product.Name, product.ProductUrl, product.Description, product.Quantity.ToString(), product.Price.ToString(), product.OwnerId); 
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Product product)
        {
            MysqlClient.UpdateProductInMysql(id, product.Name, product.ProductUrl, product.Description, product.Quantity.ToString(), product.Price.ToString(), product.OwnerId);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            MysqlClient.DeleteProductInMysql(id);
        }
    }
}

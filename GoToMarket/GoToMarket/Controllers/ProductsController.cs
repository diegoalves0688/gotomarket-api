using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
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
            MysqlClient.InsertNewProductInMysql(product.Name, product.ImageUrl, product.Description, product.Quantity.ToString(), product.Price.ToString(), product.OwnerId); 
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Product product)
        {
            MysqlClient.UpdateProductInMysql(id, product.Name, product.ImageUrl, product.Description, product.Quantity.ToString(), product.Price.ToString(), product.OwnerId);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            MysqlClient.DeleteProductInMysql(id);
        }

        [HttpPost("upload")]
        public void upload()
        {
            var newFileName = string.Empty;

            if (HttpContext.Request.Form.Files != null)
            {
                var fileName = string.Empty;
                string PathDB = string.Empty;

                var files = HttpContext.Request.Form.Files;

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        var FileExtension = Path.GetExtension(fileName);

                        newFileName = myUniqueFileName + FileExtension;

                        fileName = $@"\gotomarket\{newFileName}";

                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                    }
                }


            }
        }
    }
}

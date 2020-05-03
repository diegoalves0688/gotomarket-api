using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;

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

        [HttpPost("upload-image")]
        public void Base64StringToBitmap(ImageContent imageContent)
        {
            try
            {
                Console.WriteLine($"Request received: " + JsonConvert.SerializeObject(imageContent));

                byte[] imgBytes = Convert.FromBase64String(imageContent.Image);

                using (var imageFile = new FileStream(@"C:\gotomarket\" + imageContent.Name + ".png", FileMode.Create))
                {
                    imageFile.Write(imgBytes, 0, imgBytes.Length);
                    imageFile.Flush();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            
        }

        [HttpGet("images/{imageId}")]
        public IActionResult GetImage(string imageId)
        {
            try
            {
                imageId = imageId.Replace(".png", "").Replace(".jpg", "");

                var path = @"C:\gotomarket\" + imageId + ".png";

                var bytes = System.IO.File.ReadAllBytes(path);

                return File(bytes, "image/png");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return null;
        }

    }
}

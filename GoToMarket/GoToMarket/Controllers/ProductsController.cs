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
                Console.WriteLine($"Uploading image.");

                byte[] imgBytes = Convert.FromBase64String(imageContent.Image);

                var path = @"C:\gotomarket";
                var filePath = Path.Combine(path, imageContent.Name + ".png");

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                using (var imageFileStream = new FileStream(filePath, FileMode.Create))
                {
                    imageFileStream.Write(imgBytes, 0, imgBytes.Length);
                    imageFileStream.Flush();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error on trying save image. Please check if : {ex.Message}");
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

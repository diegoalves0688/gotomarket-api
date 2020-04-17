using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace GoToMarket.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        public List<Order> Get()
        {
            return MysqlClient.GetOrdersInMysql();
        }

        [HttpGet("{id}")]
        public Order Get(string id)
        {
            return MysqlClient.GetOrderByIdInMysql(id);
        }

        [HttpPost]
        public void Post([FromBody] Order order)
        {
            var paymentResponse = CieloConnector.CieloClient.PostPayment(order);

            if (paymentResponse != null && paymentResponse.PaymentObj.Status == 2)
                MysqlClient.InsertNewOrderInMysql(order.Value, order.ProductName, order.OwnerId, order.BuyerId, paymentResponse.MerchantOrderId);
            else
                throw new Exception("Error on trying approve payment.");
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Order order)
        {
            MysqlClient.UpdateOrderInMysql(id, order.Value, order.ProductName, order.OwnerId, order.BuyerId);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            MysqlClient.DeleteOrderInMysql(id);
        }
    }
}

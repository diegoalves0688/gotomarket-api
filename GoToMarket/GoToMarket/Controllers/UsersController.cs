using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace GoToMarket.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public List<User> Get()
        {
            return MysqlClient.GetUsersInMysql();
        }

        [HttpGet("{email}")]
        public User GetByEmail(string email)
        {
            var user = MysqlClient.GetUserByEmailInMysql(email);
            return user;
        }

        [HttpPost]
        public void Post([FromBody] User user)
        {
            MysqlClient.InsertNewUserInMysql(user.Name,
                CryptoUtils.CryptoMD5.HashPassword(user.Password),
                user.Email,
                user.Address,
                user.Payment_id,
                user.Payment_key);
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] User user)
        {
            MysqlClient.UpdateUserInMysql(id,
                user.Name,
                user.Password,
                user.Email,
                user.Address,
                user.Payment_id,
                user.Payment_key);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            MysqlClient.DeleteUserInMysql(id);
        }
    }
}

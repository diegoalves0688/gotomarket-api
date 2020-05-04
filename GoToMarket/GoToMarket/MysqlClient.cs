using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GoToMarket
{
	public class MysqlClient
	{
        public static string connStr = "server=localhost;user=gotomarket;database=gotomarket;port=3306;password=gotomarket123;charset=utf8;";

		#region User

		public static void InsertNewUserInMysql(string user_name,string user_password, string user_email, string user_address, string user_payment_id, string user_payment_key)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "INSERT INTO users (user_name, user_password, user_email, user_address, user_payment_id, user_payment_key) " +
                    "VALUES ('" + user_name + "','" + user_password + "','" + user_email + "','" + user_address + "','" + user_payment_id + "','" + user_payment_key + "')";
                Console.WriteLine("Running query: " + sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }

        public static void UpdateUserInMysql(string id, string user_name, string user_password, string user_email, string user_address, string user_payment_id, string user_payment_key)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = 
                    $"UPDATE users SET user_name = '{user_name}', " +
                    $"user_password = '{user_password}', " +
                    $"user_email = '{user_email}', " +
                    $"user_address = '{user_address}', " +
                    $"user_payment_id = '{user_payment_id}', " +
                    $"user_payment_key = '{user_payment_key}'  " +
                    $"WHERE user_id='{id}'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }

        public static User GetUserByEmailInMysql(string email)
        {
            var user = new User();
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM users WHERE user_email='" + email + "'";
                Console.WriteLine("Running query: " + sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    long.TryParse(rdr[0].ToString(), out long id);
                    user.Id = id;
                    user.Name = rdr[1].ToString();
                    user.Password = rdr[2].ToString();
                    user.Email = rdr[3].ToString();
                    user.Address = rdr[4].ToString();
                    user.Payment_id = rdr[5].ToString();
                    user.Payment_key = rdr[6].ToString();
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            return user;
        }

        public static User GetUserByIdInMysql(string user_id)
        {
            var user = new User();
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM users WHERE user_id='" + user_id + "'";
                Console.WriteLine("Running query: " + sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    long.TryParse(rdr[0].ToString(), out long id);
                    user.Id = id;
                    user.Name = rdr[1].ToString();
                    user.Password = rdr[2].ToString();
                    user.Email = rdr[3].ToString();
                    user.Address = rdr[4].ToString();
                    user.Payment_id = rdr[5].ToString();
                    user.Payment_key = rdr[6].ToString();
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            return user;
        }

        public static List<User> GetUsersInMysql()
        {
            var userList = new List<User>();
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM users";
                Console.WriteLine("Running query: " + sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    var user = new User();
                    long.TryParse(rdr[0].ToString(), out long id);
                    user.Id = id;
                    user.Name = rdr[1].ToString();
                    user.Email = rdr[2].ToString();
                    user.Address = rdr[3].ToString();
                    user.Payment_id = rdr[4].ToString();
                    user.Payment_key = rdr[5].ToString();
                    userList.Add(user);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            return userList;
        }

        public static void DeleteUserInMysql(string user_id)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = $"DELETE FROM users WHERE user_id = '{user_id}'";
                Console.WriteLine("Running query: " + sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }

        #endregion

        #region Product

        public static void InsertNewImageInMysql(string image_name, string image_data)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "INSERT INTO images (image_name, image_data) " +
                    "VALUES ('" + image_name + "', '" + image_data + "')";
                Console.WriteLine("Running query: " + sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }

        public static ImageContent GetImageByNameInMysql(string image_name)
        {
            var imageContent = new ImageContent();
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM images WHERE image_name='" + image_name + "'";
                Console.WriteLine("Running query: " + sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    imageContent.Name = rdr[1].ToString();
                    imageContent.Image = rdr[2].ToString();
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            return imageContent;
        }

        public static void InsertNewProductInMysql(string product_name, string product_url, string product_description, string product_quantity, string product_price, string product_owner_id)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "INSERT INTO products (product_name, product_url, product_description, product_quantity, product_price, product_owner_id) " +
                    "VALUES ('" + product_name + "', '" + product_url + "', '" + product_description + "', " + product_quantity + ", " + product_price + ", '" + product_owner_id + "')";
                Console.WriteLine("Running query: " + sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }

        public static void UpdateProductInMysql(string id, string product_name, string product_url, string product_description, string product_quantity, string product_price, string product_owner_id)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql =
                    $"UPDATE products SET product_name = '{product_name}', " +
                    $"product_url = '{product_url}', " +
                    $"product_description = '{product_description}', " +
                    $"product_quantity = {product_quantity}, " +
                    $"product_price = {product_price},  " +
                    $"product_owner_id = '{product_owner_id}'  " +
                    $"WHERE product_id='{id}'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }

        public static Product GetProductByIdInMysql(string product_id)
        {
            var product = new Product();
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM products WHERE product_id='" + product_id + "'";
                Console.WriteLine("Running query: " + sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    product.Id = rdr[0].ToString();
                    product.Name = rdr[1].ToString();
                    product.ImageUrl = rdr[2].ToString();
                    product.Description = rdr[3].ToString();
                    product.Quantity = long.TryParse(rdr[4].ToString(), out long quantity) ? quantity : 0;
                    product.Price = long.TryParse(rdr[5].ToString(), out long price) ? price : 0;
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            return product;
        }

        public static List<Product> GetProductsInMysql()
        {
            var productList = new List<Product>();
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM products";
                Console.WriteLine("Running query: " + sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    var product = new Product();
                    product.Id = rdr[0].ToString();
                    product.Name = rdr[1].ToString();
                    product.ImageUrl = rdr[2].ToString();
                    product.Description = rdr[3].ToString();
                    product.Quantity = long.TryParse(rdr[4].ToString(), out long quantity) ? quantity : 0;
                    product.Price = long.TryParse(rdr[5].ToString(), out long price) ? price : 0;
                    product.OwnerId = rdr[6].ToString();

                    if (product.Quantity <= 0)
                        continue;

                    productList.Add(product);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            return productList;
        }

        public static void DeleteProductInMysql(string product_id)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = $"DELETE FROM products WHERE product_id = '{product_id}'";
                Console.WriteLine("Running query: " + sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }

        #endregion

        #region order

        public static void InsertNewOrderInMysql(long order_value, string order_product_name, long order_product_owner_id, long order_product_buyer_id, string order_reference)
        {
            var now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // 2019-12-31 23:40:10
            string sql = string.Empty;

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                sql = $"INSERT INTO orders (order_date, order_value, order_product_name, order_product_owner_id, order_product_buyer_id, order_reference) " +
                    $"VALUES ('{now}', '{order_value}', '{order_product_name}', '{order_product_owner_id}', '{order_product_buyer_id}', '{order_reference}')";
                Console.WriteLine("Running query: " + sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }

        public static void UpdateOrderInMysql(string id, long order_value, string order_product_name, long order_product_owner_id, long order_product_buyer_id)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql =
                    $"UPDATE orders SET order_value = '{order_value}', " +
                    $"order_product_name = '{order_product_name}', " +
                    $"order_product_owner_id = '{order_product_owner_id}', " +
                    $"order_product_buyer_id = '{order_product_buyer_id}' " +
                    $"WHERE order_id='{id}'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }

        public static Order GetOrderByIdInMysql(string order_id)
        {
            var order = new Order();
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM orders WHERE order_id='" + order_id + "'";
                Console.WriteLine("Running query: " + sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    order.Id = rdr[0].ToString();
                    if (DateTime.TryParse(rdr[1].ToString(), out DateTime date))
                        order.Date = date;
                    order.Value = long.TryParse(rdr[2].ToString(), out long value) ? value : 0;
                    order.ProductName = rdr[3].ToString();
                    order.OwnerId = long.TryParse(rdr[4].ToString(), out long owner) ? owner : 0;
                    order.BuyerId = long.TryParse(rdr[5].ToString(), out long buyer) ? buyer : 0;
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            return order;
        }

        public static List<Order> GetOrdersInMysql()
        {
            var orderList = new List<Order>();
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM orders";
                Console.WriteLine("Running query: " + sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    var order = new Order();
                    order.Id = rdr[0].ToString();
                    if (DateTime.TryParse(rdr[1].ToString(), out DateTime date))
                        order.Date = date;
                    order.Value = long.TryParse(rdr[2].ToString(), out long value) ? value : 0;
                    order.ProductName = rdr[3].ToString();
                    order.OwnerId = long.TryParse(rdr[4].ToString(), out long owner) ? owner : 0;
                    order.BuyerId = long.TryParse(rdr[5].ToString(), out long buyer) ? buyer : 0;
                    orderList.Add(order);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            return orderList;
        }

        public static List<Order> GetOrdersByBuyerIdInMysql(string buyerId)
        {
            var orderList = new List<Order>();
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = $"SELECT * FROM orders WHERE order_product_buyer_id = '{buyerId}'";
                Console.WriteLine("Running query: " + sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    var order = new Order();
                    order.Id = rdr[0].ToString();
                    if (DateTime.TryParse(rdr[1].ToString(), out DateTime date))
                        order.Date = date;
                    order.Value = long.TryParse(rdr[2].ToString(), out long value) ? value : 0;
                    order.ProductName = rdr[3].ToString();
                    order.OwnerId = long.TryParse(rdr[4].ToString(), out long owner) ? owner : 0;
                    order.BuyerId = long.TryParse(rdr[5].ToString(), out long buyer) ? buyer : 0;
                    orderList.Add(order);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            return orderList;
        }

        public static List<Order> GetOrdersByOwnerIdInMysql(string ownerId)
        {
            var orderList = new List<Order>();
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = $"SELECT * FROM orders WHERE order_product_owner_id = '{ownerId}'";
                Console.WriteLine("Running query: " + sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    var order = new Order();
                    order.Id = rdr[0].ToString();
                    if (DateTime.TryParse(rdr[1].ToString(), out DateTime date))
                        order.Date = date;
                    order.Value = long.TryParse(rdr[2].ToString(), out long value) ? value : 0;
                    order.ProductName = rdr[3].ToString();
                    order.OwnerId = long.TryParse(rdr[4].ToString(), out long owner) ? owner : 0;
                    order.BuyerId = long.TryParse(rdr[5].ToString(), out long buyer) ? buyer : 0;
                    orderList.Add(order);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            return orderList;
        }

        public static void DeleteOrderInMysql(string order_id)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = $"DELETE FROM orders WHERE order_id = '{order_id}'";
                Console.WriteLine("Running query: " + sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }

        #endregion
    }
}

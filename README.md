
# Gotomarket-api.
.
https://gotomarket.hopto.org/api/{resource}/{id}
.
Resource list:
- users
- orders
- products
- test
## User request examples:
-
Create new user:
``` 
curl --location \
--request POST 'https://gotomarket.hopto.org/api/users/1' \
--header 'Content-Type: application/json' \
--data-raw '{"name": "test2", "email": "lol@fmail.com", "address": "rua 1", "payment_id": "payid", "payment_key": "paykey2"}' \
--insecure
```

Edit user:
``` 
curl --location \
--request PUT 'https://gotomarket.hopto.org/api/users/1' \
--header 'Content-Type: application/json' \
--data-raw '{"name": "test2", "email": "lol@fmail.com", "address": "rua 1", "payment_id": "payid", "payment_key": "paykey2"}' \
--insecure
```

Get user by email
```
curl --location \
--request GET 'https://gotomarket.hopto.org/api/users/lol@fmail.com' \
--header 'Content-Type: application/json' \
--insecure 
```

Delete user
```
curl --location \
--request DELETE 'https://gotomarket.hopto.org/api/users/1' \
--header 'Content-Type: application/json' \
--insecure
```

Get user list
```
curl --location \
--request GET 'https://gotomarket.hopto.org/api/users' \
--header 'Content-Type: application/json' \
--insecure
```

## Product request examples:

Create new product
```
curl --location \
--request POST 'https://gotomarket.hopto.org/api/products' \
--header 'Content-Type: application/json' \
--data-raw '{"name": "prodname", "description": "prod test", "url": "https://img.com", "price": 50, "quantity": 10, "ownerId": "2"}' \
--insecure
```

Edit product
```
curl --location \
--request PUT 'https://gotomarket.hopto.org/api/products/1' \
--header 'Content-Type: application/json' \
--data-raw '{"name": "prodname2", "description": "prod test", "url": "https://img.com", "price": 50, "quantity": 10, "ownerId": "2"}' \
--insecure
```

Get product by id
```
curl --location \
--request GET 'https://gotomarket.hopto.org/api/products/1' \
--header 'Content-Type: application/json' \
--insecure
```

Get product list
```
curl --location \
--request GET 'https://gotomarket.hopto.org/api/products' \
--header 'Content-Type: application/json' \
--insecure
```

Delete product
```
curl --location \
--request DELETE 'https://gotomarket.hopto.org/api/products/1' \
--header 'Content-Type: application/json' \
--insecure
```

Upload product image
```
curl --location \
--request POST 'https://gotomarket.hopto.org/api/products/upload-image' \
--header 'Content-Type: application/json' \
--data-raw '{"image": "{base64imagecontent}", "name": "imagename"}' \
--insecure
```

Get product image
```
curl --location \
--request GET 'https://gotomarket.hopto.org/api/products/images/sample' \
--insecure
```

## Orders request examples:

Create new order
```
curl --location \
--request POST 'https://gotomarket.hopto.org/api/orders' \
--header 'Content-Type: application/json' \
--data-raw '{"value": 15, "productName": "prod test", "ownerId": 2, "buyerId": 2, "cardNumber": "4111111111111111", "expirationDate": "12/2021", "securityCode": "123"}' \
--insecure
```

Edit order
```
curl --location \
--request PUT 'https://gotomarket.hopto.org/api/orders/1' \
--header 'Content-Type: application/json' \
--data-raw '{"value": 99, "productName": "prod2 test2", "ownerId": 27, "buyerId": 21}' \
--insecure
```

Get order list
```
curl --location \
--request GET 'https://gotomarket.hopto.org/api/orders' \
--header 'Content-Type: application/json' \
--insecure
```

Get order list by owner id
```
curl --location \
--request GET 'https://gotomarket.hopto.org/api/orders/owner/1' \
--header 'Content-Type: application/json' \
--insecure
```

Get order list by buyer id
```
curl --location \
--request GET 'https://gotomarket.hopto.org/api/orders/buyer/1' \
--header 'Content-Type: application/json' \
--insecure
```

Get order by id
```
curl --location \
--request GET 'https://gotomarket.hopto.org/api/orders/1' \
--header 'Content-Type: application/json' \
--insecure
```

Delete order
```
curl --location \ 
--request DELETE 'https://gotomarket.hopto.org/api/orders/1' \
--header 'Content-Type: application/json' \
--insecure
 ```

# Sample.API
Sample REST based API implemented using of ASP Core / .NET Core

Create, Update and Delete have not currently been implemented

## Example API requests:

### Get Requests

* api/products (to get all product models)
* api/products/1 (to get product model 1)
* api/products/1?includeSalesItems=true (to get product model 1 with all of its Products)
* api/products/1/salesitems (to get all the products for product model 1)
* api/products/1/salesitems/864 (to get a specific Product for a Product Mode)

### Create (Post) Requests
(Create won't work if you use the DB as your respository)

* api/product/1/saleitem
{
   "name": "AWC Logo Cap (Simon)",
   "productNumber": "CA-1098",
   "colour": "Multi"
}

# Class Diagram

![Class Diagram](/Docs/Class.png)

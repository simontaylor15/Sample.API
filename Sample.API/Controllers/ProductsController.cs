using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.API.Services;
using Sample.API.Models;

namespace Sample.API.Controllers
{
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private IProductInfoRepository _productInfoRepository;

        public ProductsController(IProductInfoRepository productInfoRepository)
        {
            _productInfoRepository = productInfoRepository;
        }

        [HttpGet("{productId}/saleitems")]
        public IActionResult GetProducts(int productId)
        {
            //productId is actually the product model id!
            if (!_productInfoRepository.ProductModelExists(productId))
            {
                return NotFound();
            }

            var products = _productInfoRepository.GetProductsForModel(productId);
            var result = new List<ProductDto>();
            foreach (var product in products)
            {
                result.Add(new ProductDto()
                {
                    Id = product.ProductId,
                    Name = product.Name,
                    ProductNumber = product.ProductNumber,
                    Colour = product.Color
                });
            }

            return Ok(result);

            //var productModel = ProductsDataStore.Current.ProductModels.FirstOrDefault(pm => pm.Id == productId);
            //if (productModel == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    return Ok(productModel.Products);
            //}
        }

        [HttpGet("{productId}/saleitems/{saleitemId}")]
        public IActionResult GetProduct(int productId, int saleitemId)
        {
            //productID is actually the product model id, and salesitemId is the product id
            if (!_productInfoRepository.ProductModelExists(productId))
            {
                return NotFound();
            }

            var product = _productInfoRepository.GetProductForModel(productId, saleitemId);
            if (product == null)
            {
                return NotFound();
            }

            var result = new ProductDto()
            {
                Id = product.ProductId,
                Name = product.Name,
                ProductNumber = product.ProductNumber,
                Colour = product.Color
            };

            return Ok(result);
        }
    }
}

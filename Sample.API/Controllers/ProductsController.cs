using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.API.Services;
using Sample.API.Models;
using AutoMapper;

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
            var result = Mapper.Map<IEnumerable<ProductDto>>(products);

            return Ok(result);
        }

        [HttpGet("{productId}/saleitems/{saleitemId}", Name = "GetProduct")]
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

            var result = Mapper.Map<ProductDto>(product);

            return Ok(result);
        }

        [HttpPost("{productId}/saleitem")]
        public IActionResult CreateProduct(int productId, [FromBody] ProductForCreationDto saleItem)
        {
            //productID is actually the product model id, and saleItem is the product
            if (saleItem == null)
            {
                return BadRequest();
            }

            //productID is actually the product model id, and salesitem is the product id
            if (!_productInfoRepository.ProductModelExists(productId))
            {
                return NotFound();
            }

            var finalProduct = Mapper.Map<Entities.Product>(saleItem);
            _productInfoRepository.AddProductForModel(productId, finalProduct);
            if (!_productInfoRepository.Save())
            {
                return StatusCode(500, "A problem occured while handling your request.");
            }
            var productToReturn = Mapper.Map<Models.ProductDto>(finalProduct);
            return CreatedAtRoute("GetProduct", new { productId = productId, saleItemId = productToReturn.Id }, productToReturn);
        }
    }
}

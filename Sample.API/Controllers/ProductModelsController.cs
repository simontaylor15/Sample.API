using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample.API.Services;
using Sample.API.Models;

namespace Sample.API.Controllers
{
    [Route("api/products")]
    public class ProductModelsController : Controller
    {
        private ILogger<ProductModelsController> _logger;
        private IProductInfoRepository _productInfoRepository;
        
        public ProductModelsController(ILogger<ProductModelsController> logger, IProductInfoRepository productInfoRepository)
        {
            _logger = logger;
            _productInfoRepository = productInfoRepository;
        }

        [HttpGet()]
        public IActionResult GetProducts()
        {
            //return Ok(ProductsDataStore.Current.ProductModels);
            var productModels = _productInfoRepository.GetProductModels();
            var results = new List<ProductModelWithoutProductDto>();
            foreach (var productModelEntity in productModels)
            {
                results.Add(new ProductModelWithoutProductDto
                {
                    Id = productModelEntity.ProductModelId,
                    Name = productModelEntity.Name,
                    CatalogDescription = productModelEntity.CatalogDescription
                });
            };
            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id, bool includeSaleItems = false)
        {
            var productModel = _productInfoRepository.GetProductModel(id, includeSaleItems);
            if (productModel == null)
            {
                _logger.LogInformation($"Product model with id {id} was not found");
                return NotFound();
            }
            if (includeSaleItems)
            {
                var result = new ProductModelDto()
                {
                    Id = productModel.ProductModelId,
                    Name = productModel.Name,
                    CatalogDescription = productModel.CatalogDescription,
                };

                foreach (var product in productModel.Products)
                {
                    result.Products.Add(new ProductDto()
                    {
                        Id = product.ProductId,
                        Name = product.Name,
                        ProductNumber = product.ProductNumber,
                        Colour = product.Color
                    });
                }
                return Ok(result);
            }
            else
            {
                var result = new ProductModelWithoutProductDto()
                {
                    Id = productModel.ProductModelId,
                    Name = productModel.Name,
                    CatalogDescription = productModel.CatalogDescription,
                };
                return Ok(result);
            }
        }
    }
}

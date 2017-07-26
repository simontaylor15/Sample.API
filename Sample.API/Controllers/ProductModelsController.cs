using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample.API.Services;
using Sample.API.Models;
using AutoMapper;

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
            var productModels = _productInfoRepository.GetProductModels();
            var results = Mapper.Map<IEnumerable<ProductModelWithoutProductDto>>(productModels);
           
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
                var result = Mapper.Map<ProductModelDto>(productModel);
              
                return Ok(result);
            }
            else
            {
                var result = Mapper.Map<ProductModelWithoutProductDto>(productModel);
             
                return Ok(result);
            }
        }
    }
}
